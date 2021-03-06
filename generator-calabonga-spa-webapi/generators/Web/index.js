'use strict';
var Generator = require('yeoman-generator');
var chalk = require('chalk');
var yosay = require('yosay');
var mkdirp = require('mkdirp');

module.exports = Generator.extend({

  initializing: function () {
    this.props = {};
   },

  prompting: function () {
    this.log(yosay(
      chalk.yellow('Calabonga') + ' Web Project Generator!'
    ));

    return this.prompt([
      {
        type: 'input',
        name: 'sqlName',
        message: 'Connection string for DefaultConnection SQL-server [Data Source] required',
        default: "SQL"
      },
      {
        type: 'input',
        name: 'sqlDatabaseName',
        message: 'Connection string for DefaultConnection SQL-server [Initial Catalog] required',
        default: "calabonga-yeoman-template"
      }]).then((answers) => {
        this.props.sqlName = answers.sqlName;
        this.props.sqlDatabaseName = answers.sqlDatabaseName;
      });
  },

  configuring: function () { },

  default: function () { },

  writing: function () {

    var webPath = this.options.props.appName + "/" + this.options.props.appName + ".Web";
    mkdirp(webPath);

    this.fs.copy(
      this.templatePath('staticRoot/**/*.*'),
      this.destinationPath(webPath),
      { globOptions: { dot: true } }
    );
    this.fs.copyTpl(
      this.templatePath("Web.csproj"),
      this.destinationPath(webPath + "/" + this.options.props.appName + ".Web.csproj"),
      {
        globOptions: { dot: true },
        projectGuid: this.options.props.projectWebGuid.toUpperCase(),
        projectName: this.options.props.appName
      }
    );
    this.fs.copyTpl(
      this.templatePath("root/**/*.*"),
      this.destinationPath(webPath),
      {
        globOptions: { dot: true },
        projectName: this.options.props.appName,
        year: new Date().getFullYear(),
        sqlName: this.props.sqlName,
        sqlDatabaseName: this.props.sqlDatabaseName,
        assemblyGuid: this.options.props.assemblyWebGuid.toUpperCase()
      }
    );
  },
  conflicts: function () { },

  install: function () { },

  end: function () {
    this.log('Web poject was created...');
  }
});
