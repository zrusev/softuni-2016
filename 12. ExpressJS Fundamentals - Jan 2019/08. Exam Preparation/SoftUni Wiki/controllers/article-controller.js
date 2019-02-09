const Article = require('../models/Article');
const Edit = require('../models/Edit');
const errorHandler = require('../util/errorHandler');

module.exports = {
    getCreate: (req, res) => {
        res.render('articles/create');
    },
    postCreate: async (req, res) => {
        const {
            title,
            content
        } = req.body;

        try {
            let edit = await Edit.create({
                author: req.user._id,
                content
            });

            const article = await Article.create({
                title,
                edits: [edit._id]
            });

            edit.article = article._id;
            await edit.save();

            res.redirect('/');
        } catch (err) {
            errorHandler(err, res, 'articles/create', {
                title,
                content
            });
        }
    },
    getAll: (req, res) => {
        Article
        .find({})
        .sort('title')
        .then((articles) => {
            res.render('articles/all-articles', { articles });
        })
        .catch((err) => {
            errorHandler(err, res, 'home/index');
        });
    },
    getOne: (req, res) => {
        const articleId = req.params.id;

        Article
            .findById(articleId)
            .populate('edits')
            .sort('edits.creationDate')
            .then((article) => {
                article.latestEdit = article.edits.pop();
                res.render('articles/article', article );
            })
            .catch((err) => {
                errorHandler(err, res, 'home/index');
            });
    },
    getEdit: (req, res) => {
        const latestEdit = req.params.id;

        Edit
            .findById(latestEdit)
            .populate('article')
            .then((edit) => {               
                res.render('articles/edit', edit);
            })
            .catch((err) => {
                errorHandler(err, res, 'home/index');
            });
    },
    postEdit: async (req, res) => {
        //isAdmin check

        const articleId = req.params.id;

        const {
            title,
            content
        } = req.body;
        
        try {
            let edit = await Edit.create({
                author: req.user._id,
                content,
                article: articleId
            });

            const article = await Article.findById(articleId);

            article.title = title;
            article.edits.push(edit._id);
            await article.save();

            res.redirect('/');
        } catch (err) {
            errorHandler(err, res, 'articles/create', {
                title,
                content
            });
        }
    },
    getHistory: (req, res) => {
        const articleId = req.params.id;

        Article
            .findById(articleId)
            .populate({
                path: 'edits',
                populate: {
                    path: 'author'
                }
            })
            .then((article) => {
                res.render('articles/history', { edits: article.edits });
            })
            .catch((err) => {
                errorHandler(err, res, 'home/index');
            });
    },
    //getOneByEditId TBA
    lockUnlock: (req, res) => {
        const articleId = req.params.id;

        Article
        .findById(articleId)
        .then((article) => {
            if (article.lockedStatus) {                
                article.lockedStatus = false;
            } else {
                article.lockedStatus = true;
            }

            article.save()
                .then((article) => {
                    //sort edits and get the latest
                    res.redirect(`/edit/${articleId}`);
                })
                .catch((err) => {
                    errorHandler(err, res, 'home/index');
                });        
        })
        .catch((err) => {
            errorHandler(err, res, 'home/index');
        });
    }
    //Search TBA
};