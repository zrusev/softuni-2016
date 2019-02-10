const User = require('mongoose').model('User');
const Team = require('../models/Team');
const Project = require('../models/Project');
const errorHandler = require('../util/errorHandler');
const message = require('../common/message');

module.exports = {
    getCreate: (req, res) => {
        res.render('teams/createTeam');
    },
    postCreate: (req, res) => {
        const {
            name
        } = req.body;

        Team.create({
                name
            })
            .then((team) => {
                res.redirect('/teams/distribute');
            })
            .catch((err) => {
                errorHandler(err, res, 'teams/createTeam', {
                    name
                });
            })
    },
    getDistribute: async (req, res) => {
        const {
            errorMessage
        } = req.params;

        try {
            const users = await User.find({
                username: {
                    $not: {
                        $eq: "admin"
                    }
                }
            });

            const teams = await Team.find({});

            if (errorMessage) {
                res.render('teams/teams-admin', {
                    users,
                    teams,
                    globalErrors: [errorMessage]
                });
            } else {
                res.render('teams/teams-admin', {
                    users,
                    teams
                });
            }

        } catch (err) {
            errorHandler(err, res, 'teams/teams-admin');
        }
    },
    postDistribute: async (req, res) => {
        const {
            userId,
            teamId
        } = req.body;

        if (!userId || !teamId) {
            res.redirect('/');
            return;
        }

        try {
            const user = await User.findById(userId);
            const team = await Team.findById(teamId);

            if (user.teams.indexOf(teamId) > -1) {
                const errorMessage = `${user.firstName} ${user.lastName} has already been assigned to this team!`;
                res.redirect(`/teams/distribute/${encodeURIComponent(errorMessage)}`);
                return;
            }

            user.teams.push(teamId);
            await user.save();

            team.members.push(userId);
            await team.save();

            res.redirect('/');
        } catch (err) {
            errorHandler(err, res, 'teams/teams-admin');
        }
    },
    getAll: (req, res) => {
        Team.find({})
            .populate('projects')
            .populate('members')
            .then((teams) => {
                res.render('teams/teams-user', {
                    teams
                });
            })
            .catch((err) => {
                errorHandler(err, res, 'teams/teams-user');
            });
    },
    leaveTeam: async (req, res) => {
        const {
            teamId
        } = req.params;

        try {
            const team = await Team.findById(teamId);

            req.user.teams.pull(teamId);
            await req.user.save();

            team.members.pull(req.user._id);
            await team.save();

            res.redirect('/profile');

        } catch (err) {
            errorHandler(err, res, 'home/profile');
        }
    },
    search: (req, res) => {
        const {
            search
        } = req.body;

        Team.find({
                name: new RegExp(search, 'i')
            })
            .populate('projects')
            .populate('members')
            .then((teams) => {
                res.render('teams/teams-user', {
                    teams
                });
            })
            .catch((err) => {
                errorHandler(err, res, 'teams/teams-user');
            });
    }
};