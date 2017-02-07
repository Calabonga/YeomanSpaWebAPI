'use strict';
var Generator = require('yeoman-generator');
var chalk = require('chalk');
var yosay = require('yosay');
var mkdirp = require('mkdirp');

module.exports = Generator.extend({

  initializing: function () {
    this.props = {};
  },

  prompting: function () { },

  configuring: function () { },

  default: function () { },

  writing: function () {

    mkdirp(this.options.appName +"/" +this.options.appName + '.Web');

    // this.fs.copy(
    //   this.templatePath('dummyfile.txt'),
    //   this.destinationPath('dummyfile.txt')
    // );
  },
  conflicts: function () { },

  install: function () { },

  end: function () {
    this.log(yosay('Web was created...'));
  }
});
