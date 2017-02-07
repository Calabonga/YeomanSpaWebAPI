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
    // Have Yeoman greet the user.
    this.log(yosay(
      'Welcome to the luminous ' + chalk.yellow('Calabonga') + ' generator!'
    ));

    return this.prompt([{
      type: 'input',
      name: 'name',
      message: 'Your project name',
      default: this.appname // Default to current folder name
    }, {
      type: 'confirm',
      name: 'useSpa',
      message: 'Would you like to use Calabonga.Owin.Application.SPA nuget-package?',
      default: false
    }]).then((answers) => {
      this.props.appName = answers.name;
      this.log('app name', answers.name);

      this.props.useSpa = answers.useSpa;
      this.log('user SPA', answers.useSpa);
      this.props.root = this.destinationRoot();
    });


    var prompts = [{
      type: 'confirm',
      name: 'useOwinPackage',
      message: '',
      default: true
    }, {
      type: "input",
      name: "applicationName",
      message: "Enter solution name?",
      default: "Calabonga.Template"
    }];

    return this.prompt(prompts).then(function (props) {
      // To access props later use this.props.useOwinPackage;
      this.props = props;
    }.bind(this));
  },

  configuring: function () { },

  default: function () { },

  writing: function () {

    mkdirp(this.props.root + "/" + this.props.appName);

    this.composeWith(require.resolve('../Models'), { appName: this.props.appName });
    this.composeWith(require.resolve('../Data'), { appName: this.props.appName });
    this.composeWith(require.resolve('../Web'), { appName: this.props.appName });

    this.fs.copy(
      this.templatePath('.gitignore'),
      this.destinationPath(".gitignore")
    );
  },
  conflicts: function () { },

  install: function () { },

  end: function () {
    this.log(yosay('Good boy!'));
  }
});
