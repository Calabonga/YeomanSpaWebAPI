# calabonga-spa-webapi v1.0.7

This package will creates a Visual Studio 2015 solution with splitted layers. During Installation you can select your solution {YouSolutionName} name. {YouSolutionName} will contains three projects:

* {YouSolutionName}.Models (class library)
* {YouSolutionName}.Data (class library)
* {YouSolutionName}.Web (ASP.NET WebAPI)

## Installation

First, install [Yeoman](http://yeoman.io) and calabonga-spa-webapi using [npm](https://www.npmjs.com/) (we assume you have pre-installed [node.js](https://nodejs.org/)).

```bash
npm install -g yo
npm install -g calabonga-spa-webapi
```

Then generate your new project:

```bash
yo calabonga-spa-webapi
```
## Usage

After solution created, open it in Visual Studio 2015. Open Package Manager Console then execute command
```bash
update-package -reinstall
```

## Information
You can read [post](http://www.calabonga.net/blog/post/186) (russian) about framework which used in the package. Feel free to [write to author](http://www.calabonga.net/site/feedback) by feedback form.

## Versions
* 1.0.0 First release
* 1.0.7 GitHub link updated

## License

MIT © [Calabonga SOFT](http://www.calabonga.net)

[npm-url]: https://npmjs.org/package/calabonga-spa-webapi

