'use strict';
var Generator = require('yeoman-generator');
var chalk = require('chalk');
var yosay = require('yosay');
var uuid = require('uuid');
var mkdirp = require('mkdirp');

module.exports = Generator.extend({

  initializing: function () {
    this.props = {};
    this.props.projectGuid = uuid.v4();
  },

  prompting: function () { },

  configuring: function () { },

  default: function () { },

  writing: function () {

    var webPath = this.options.appName + "/" + this.options.appName + ".Web";
    mkdirp(webPath);

    this.fs.copy(
      this.templatePath('staticRoot/*.*'),
      this.destinationPath(webPath),
      { globOptions: { dot: true } }
    );
    this.fs.copyTpl(
      this.templatePath(this.options.appName + ".Web.csproj"),
      this.destinationPath(webPath + "/" + this.options.appName + ".Web.csproj"),
      { globOptions: { dot: true }, projectGuid: this.props.projectGuid.toUpperCase() }
    );
  },
  conflicts: function () { },

  install: function () { },

  end: function () {
    this.log(yosay('Web was created...'));
  }
});
