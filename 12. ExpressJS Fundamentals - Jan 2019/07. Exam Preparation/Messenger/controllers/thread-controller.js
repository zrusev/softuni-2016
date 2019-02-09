const encryption = require('../util/encryption');
const User = require('mongoose').model('User');
const Thread = require('../models/Thread');
const Message = require('../models/Message');
const errorHandler = require('../util/errorHandler');
const message = require('../common/message');

module.exports = {
    find: async (req, res) => {
        const user = req.body;

        try {
            if (!user.username) {
                errorHandler(message.requiredFields, res, 'home/index');
                return;
            }

            const targetUser = await User.findOne({
                username: user.username
            });

            if (!targetUser) {
                res.render('home/index', {
                    globalErrors: [`User "${req.body.username}" ${message.invalidUserName}`]
                });
                return;
            }

            const thread = await Thread.findOne({
                $or: [{ users: [req.user._id, targetUser._id]}, 
                      { users: [targetUser._id, req.user._id] }]
            });

            if (thread) {
                res.redirect(`/thread/:${targetUser._id}`);
            } else {
                Thread.create({
                        users: [req.user._id, targetUser._id],
                    })
                    .then((thread) => {
                        res.redirect(`/thread/:${targetUser._id}`);
                    })
                    .catch((err) => {
                        errorHandler(err, res, 'home/index');
                    });
            }
        } catch (err) {
            errorHandler(err, res, 'home/index');
        }
    },
    getThread: async (req, res) => {
        const targetUserId = req.params.otherUser.slice(1);
        try {
            const targetUser = await User.findById(targetUserId);

            const thread = await Thread.findOne({
                users: { $in: [req.user._id, targetUser._id] }
            });
            
            const isBlocked = targetUser.blockedUsers.includes(req.user.id);
            const isTargetUserBlocked = req.user.blockedUsers.includes(targetUser.id);

            const messages = await Message.find({
                thread
            }).populate('user');

            messages.forEach(message => {
                if (message.user.username !== req.user.username) {
                    message.right = true;
                }

                if ((/(http(s?):)([/|.|\w|\s|-])*\.(?:jpg|gif|png)/g).test(message.content)) {
                    message.img = true;
                }                

            });

            res.render('chatroom/chatroom', {
                messages,
                targetUserId,
                targetUserName: targetUser.username,
                isTargetUserBlocked,
                threadId: thread._id,
                isBlocked
            });
        } catch (err) {
            errorHandler(err, res, 'home/index');
        }
    },
    postThread: (req, res) => {
        const otherUser = req.params.otherUser.slice(1);
        const {
            message,
            threadId
        } = req.body;

        Message.create({
                content: message,
                user: otherUser,
                thread: threadId
            })
            .then((message) => {
                res.redirect(`/thread/:${otherUser}`);
            })
            .catch((err) => {
                errorHandler(err, res, 'home/index');
            })
    },
    block: (req, res) => {
        const username = req.params.username;

        User.findOne({ username })
            .then((user) => {
                req.user.blockedUsers.push(user.id);

                req.user.save()
                    .then(() => {
                        res.redirect(`/thread/:${user.id}`);
                    })
                    .catch((err) => {
                        errorHandler(err, res, 'home/index');
                    });
            })
            .catch((err) => {
                errorHandler(err, res, 'home/index');
            });
    },
    unBlock: (req, res) => {
        const username = req.params.otherUser;

        User.findById(username)
            .then((user) => {
                req.user.blockedUsers.pull(user.id);

                req.user.save()
                    .then(() => {
                        res.redirect(`/thread/:${user.id}`);
                    })
                    .catch((err) => {
                        errorHandler(err, res, 'home/index');
                    });        
            })
            .catch((err) => {
                errorHandler(err, res, 'home/index');
            });
    },
    deleteThread: async (req, res) => {
        const threadId = req.params.threadId;

        try {
            const thread = await Thread.findById(threadId);

            await Message.deleteMany({ thread: thread._id });

            await thread.delete();            
    
            res.redirect('/');
        } catch (err) {
            errorHandler(err, res, 'home/index');   
        }
    }
}