const Article = require('../models/Article');

module.exports = {
    getCreate: (req, res) => {
        res.render('article/create');
    },
    postCreate: (req, res) => {
        let { title, content } = req.body;
        let author = req.user._id;
        let user = req.user;

        Article.create({ title, content, author })
            .then((result) => {
                user.articles.push(result._id);
                
                return user.save();
            })
            .then(() => {                
                res.redirect('/');
            })
            .catch(console.log);
    },
    getDetails: (req, res) => {
        let articleId = req.params.id;

        Article.findById(articleId)
            .populate('author')
            .then((article) => {
                let isAuthor = false;
                if (req.user) {
                    isAuthor = req.user.isAuthor(article);
                }
                res.render('article/details', { article, isAuthor });
            })
            .catch(console.log);
    },
    getEdit: (req, res) => {
        let articleId = req.params.id;

        Article.findById(articleId)
            .then((article) => {
                res.render('article/edit', article);
            })
            .catch(console.log);
    },
    postEdit: (req, res) => {
        let { title, content } = req.body;
        let articleId = req.params.id;

        Article.findById(articleId)
            .then((article) => {
                const isAuthor = req.user.isAuthor(article);
                const isAdmin = req.user.isInRole('Admin');
                
                if (!isAuthor || !isAdmin) {
                    res.redirect('/');
                    return;
                }

                article.title = title;
                article.content = content;
                return article.save();                
            })
            .then(() => {
                res.redirect('/');
            })
            .catch(console.log);
    },
    getDelete: (req, res) => {
        let articleId = req.params.id;

        Article.findById(articleId)
            .then((article) => {
                res.render('article/delete', article);
            })
            .catch(console.log);
    },
    postDelete: (req, res) => {
        let articleId = req.params.id;
        let user = req.user;

        Article.findById(articleId)
        .then((article) => {
            const isAuthor = req.user.isAuthor(article);
            const isAdmin = req.user.isInRole('Admin');

            if (!isAuthor || !isAdmin) {
                res.redirect('/');
                return;
            }

            return Article.remove({ _id: articleId });
        })
        .then(() => {
            let artIndex = user.articles.indexOf(articleId);
            user.articles.splice(artIndex);
            return user.save();
        })
        .then(() => {
            res.redirect('/');
        })
        .catch(console.log);
    },
}