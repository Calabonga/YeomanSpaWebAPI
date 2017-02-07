'use strict';
var Generator = require('yeoman-generator');
var chalk = require('chalk');
var yosay = require('yosay');
var mkdirp = require('mkdirp');

module.exports = Generator.extend({

  initializing: function () { },

  prompting: function () { },

  configuring: function () { },

  default: function () { },

  writing: function () {

    var webPath = this.options.props.appName + "/" + this.options.props.appName + ".Models";
    mkdirp(webPath);

    this.fs.copyTpl(
      this.templatePath("Models.csproj"),
      this.destinationPath(webPath + "/" + this.options.props.appName + ".Models.csproj"),
      {
        globOptions: { dot: true },
        projectGuid: this.options.props.projectDataGuid.toUpperCase(),
        projectName: this.options.props.appName
      }
    );
    this.fs.copy(
      this.templatePath('staticRoot/**/*.*'),
      this.destinationPath(webPath),
      { globOptions: { dot: true } }
    );
    this.fs.copyTpl(
      this.templatePath("root/**/*.*"),
      this.destinationPath(webPath),
      {
        globOptions: { dot: true },
        projectName: this.options.props.appName,
        year: new Date().getFullYear(),
        assemblyGuid: this.options.props.assemblyWebGuid.toUpperCase()
      }
    );
  },
  conflicts: function () { },

  install: function () { },

  end: function () {
    this.log('Models project was created...');
  }
});
