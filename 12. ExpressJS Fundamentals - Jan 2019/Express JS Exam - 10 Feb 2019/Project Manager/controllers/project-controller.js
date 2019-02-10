const User = require('mongoose').model('User');
const Team = require('../models/Team');
const Project = require('../models/Project');
const errorHandler = require('../util/errorHandler');
const message = require('../common/message');

module.exports = {
    getCreate: (req, res) => {
        res.render('projects/createProject');
    },
    postCreate: (req, res) => {
        const { name, description } = req.body;

        Project.create({
            name,
            description
        })
        .then((project) => {
            res.redirect('/projects/distribute');
        })
        .catch((err) => {
            errorHandler(err, res, 'projects/createProject', { name, description });
        })
    },
    getDistribute: async (req, res) => {
        try {
            const teams = await Team.find({});
            const projects = await Project.find({
                team: { $exists: false }
            });
    
            res.render('projects/projects-admin', { teams, projects });            
        } catch (err) {
            errorHandler(err, res, 'projects/createProject');            
        }
    },
    postDistribute: async (req, res) => {
        const { teamId, projectId } = req.body;

        if (!teamId || !projectId) {
            res.redirect('/');
            return;
        }

        try {
            const team = await Team.findById(teamId);
            const project = await Project.findById(projectId);
            
            team.projects.push(projectId);
            await team.save();
    
            project.team = teamId;
            await project.save();
    
            res.redirect('/');    
        } catch (err) {
            errorHandler(err, res, 'projects/projects-admin');            
        }
    },
    getAll: (req, res) => {
        Project.find({})
            .populate('team')
            .then((projects) => {                
                res.render('projects/projects-user', { projects });
            })
            .catch((err) => {
                errorHandler(err, res, 'projects/projects-user');            
            })
    },
    search: (req, res) => {
        const { search } = req.body;

        Project.find({
                name: new RegExp(search, 'i')
            })
            .populate('team')
            .then((projects) => {
                res.render('projects/projects-user', { projects });
            })
            .catch((err) => {
                errorHandler(err, res, 'projects/projects-user');      
            });     
    }
};