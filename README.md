# ABP Framework

![build and test](https://github.com/abpframework/abp/workflows/build%20and%20test/badge.svg)
[![NuGet](https://img.shields.io/nuget/v/Volo.Abp.Core.svg?style=flat-square)](https://www.nuget.org/packages/Volo.Abp.Core)
[![MyGet (with prereleases)](https://img.shields.io/myget/abp-nightly/vpre/Volo.Abp.svg?style=flat-square)](https://docs.abp.io/en/abp/latest/Nightly-Builds)
[![NuGet Download](https://img.shields.io/nuget/dt/Volo.Abp.Core.svg?style=flat-square)](https://www.nuget.org/packages/Volo.Abp.Core)

<<<<<<< HEAD
## abp模块自定义

了解官方信息 [web site (abp.io)](https://abp.io/).

### 文档

查看官方文档 <a href="https://docs.abp.io/" target="_blank"></a>.

### 开发环境

- Visual Studio 2019 16.4.0+

#### 框架

不会更改Abp基础框架代码

#### 模块/模板

[Modules](模块/) and [Templates](模板/) 有自己的解决方案，并且有**本地引用**到框架和彼此。
=======
ABP is an **open source application framework** focused on ASP.NET Core based web application development, but also supports developing other type of applications.

## Links

* <a href="https://abp.io/" target="_blank">Official Web Site</a>
  * <a href="https://abp.io/get-started" target="_blank">Get Started</a>
  * <a href="https://abp.io/features" target="_blank">Features</a>
  * <a href="https://docs.abp.io/" target="_blank">Documentation</a>
  * <a href="https://docs.abp.io/en/abp/latest/Samples/Index" target="_blank">Samples</a>
  * <a href="https://blog.abp.io/" target="_blank">Blog</a>
* <a href="https://stackoverflow.com/questions/tagged/abp" target="_blank">Stack overflow</a>
* <a href="https://twitter.com/abpframework" target="_blank">Twitter</a>

## Contribution
>>>>>>> 8f7d0e6fa83cbb562a8b420c103157d7b56809e0

从解决方案文件夹中取出本地引用时，Visual Studio无法正常工作。当您在Visual Studio中打开一个模块/示例解决方案时，您可能会得到一些与依赖关系相关的错误。在这种情况下，在命令提示符上运行相关解决方案文件夹的“dotnet restore”。您需要在第一次打开解决方案或更改依赖项后运行它。
