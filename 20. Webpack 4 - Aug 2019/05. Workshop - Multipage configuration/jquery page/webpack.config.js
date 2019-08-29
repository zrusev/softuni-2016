const path = require('path');
const glob = require('glob');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const { CleanWebpackPlugin } = require('clean-webpack-plugin');
// const CopyPlugin = require('copy-webpack-plugin');
const postCssPresetEnv = require('postcss-preset-env');
const cssnano = require('cssnano');
// const Critters = require('critters-webpack-plugin');
const autoprefixer = require('autoprefixer');
const PurgecssPlugin = require('purgecss-webpack-plugin');
// const { BundleAnalyzerPlugin } = require('webpack-bundle-analyzer');

module.exports = {
    mode: 'production',
    devtool: 'source-map',
    resolve: {
        extensions: ['.js'],
    },
    entry: {
        app: path.resolve(__dirname, 'src/app.js'),
    },
    output: {
        filename: 'scripts/bundle.min.js',
        path: path.resolve(__dirname, 'dist'),
    },
    devServer: {
        port: 9000,
        contentBase: path.resolve(__dirname, 'dist'),
        compress: true,
    },
    module: {
        rules: [
            {
                test: /\.(m?js)$/,
                exclude: /node_modules/,
                use: [
                    {
                        loader: 'babel-loader',
                    }
                ]
            },
            {
                test: /\.scss$/i,
                use: [
                    {
                        loader: MiniCssExtractPlugin.loader,
                        options: {
                            sourceMap: true,
                        }
                    },
                    // {
                    //     loder: 'style-loader',
                    // },
                    {
                        loader: 'css-loader',
                        options: {
                            sourceMap: true,
                        }
                    },
                    {
                        loader: 'postcss-loader',
                        options: {
                            ident: 'postcss-2',
                            sourceMap: true,
                            minimize: true,
                            plugins: [
                                autoprefixer(),
                                cssnano(),
                            ]
                        }
                    },
                    {
                        loader: 'sass-loader',
                        options: {
                            sourceMap: true,
                        }
                    },
                    {
                        loader: 'postcss-loader',
                        options: {
                            ident: 'postcss-1',
                            sourceMap: true,
                            plugins: [
                                postCssPresetEnv(),
                            ]
                        }
                    }
                ]
            },
            {
                test: /\.(png|jpe?g|gif)$/i,
                use: [
                  {
                    loader: 'file-loader',
                    options: {
                        name: '[name].[ext]',
                        context: path.resolve(__dirname, "src/"),
                        outputPath: 'images',
                        publicPath: '../images',
                        useRelativePaths: true,
                    },
                  },
                //   {
                //     loader: 'url-loader',
                //     options: {
                //         limit: 10000,
                //         name: '[name].[ext]',
                //     }
                //   },
                ],
            },
            {
                test: /\.(woff|woff2)$/i,
                use: [
                    {
                        loader: 'file-loader',
                        options: {
                            name: '[name].[ext]',
                            context: path.resolve(__dirname, "src/"),
                            outputPath: 'fonts',
                            publishPath: '../fonts',
                            useRelativePaths: true,
                        }
                    }
                ]
            }
        ]
    },
    plugins: [
        new CleanWebpackPlugin(),
        new PurgecssPlugin({
            paths: glob.sync(`${path.resolve(__dirname, 'src')}/*`)
        }),
        new MiniCssExtractPlugin({
            filename: 'styles/bundle.css'
        }),
        // new CopyPlugin([
        //     {
        //         from: path.resolve(__dirname, 'src', 'architecture.md'),
        //         to: path.resolve(__dirname, 'dist')
        //     }
        // ]),
        new HtmlWebpackPlugin({
            template: path.resolve(__dirname, 'src', 'index.html')
        }),
        // new Critters({
        //     preload: 'swap',
        // })
        // new BundleAnalyzerPlugin(),
    ]
};