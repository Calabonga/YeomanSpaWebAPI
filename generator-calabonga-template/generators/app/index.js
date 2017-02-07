'use strict';
var Generator = require('yeoman-generator');
var chalk = require('chalk');
var _ = require('lodash');
var uuid = require('uuid');
var yosay = require('yosay');
var mkdirp = require('mkdirp');

module.exports = Generator.extend({

  initializing: function () {
    this.props = {};
    this.props.solutionGuid = uuid.v4();
    this.props.projectWebGuid = uuid.v4();
    this.props.assemblyWebGuid = uuid.v4();
    this.props.projectModelsGuid = uuid.v4();
    this.props.assemblyModelsGuid = uuid.v4();
    this.props.projectDataGuid = uuid.v4();
    this.props.assemblyDataGuid = uuid.v4();
  },

  prompting: function () {
    this.log(yosay(
      'Welcome to the ' + chalk.yellow('Calabonga') + ' generator!'
    ));

    return this.prompt([{
      type: 'input',
      name: 'name',
      message: 'Your project name',
      default: this.appname // Default to current folder name
    }, {
      type: 'confirm',
      name: 'useGit',
      message: 'Would you like to use git repository?',
      default: false
    }]).then((answers) => {
      this.props.appName = _.upperFirst(answers.name);
      this.log('app name', answers.name);

      this.props.useGit = answers.useGit;
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

    this.composeWith(require.resolve('../Models'), { props: this.props });
    this.composeWith(require.resolve('../Data'), { props: this.props });
    this.composeWith(require.resolve('../Web'), { props: this.props });

    this.fs.copy(
      this.templatePath('.gitignore'),
      this.destinationPath(".gitignore")
    );

    this.fs.copyTpl(
      this.templatePath("solution.sln"),
      this.destinationPath(this.props.appName + ".sln"),
      {
        globOptions: { dot: true },
        solutionGuid: this.solutionGuid,
        assemblyWebGuid : this.props.assemblyWebGuid,
        assemblyDataGuid: this.props.assemblyDataGuid,
        assemblyModelsGuid: this.props.assemblyModelsGuid
       }
    );
  },
  conflicts: function () { },

  install: function () { },

  end: function () {
    this.log(yosay('Good boy!'));
  }
});
