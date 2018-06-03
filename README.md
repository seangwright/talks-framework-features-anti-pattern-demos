# asp-net-core-mvc framework / features examples

This repository contains two ASP.NET Core MVC projects

**ASPNETCoreMVC.FrameworkFocus.Web**

This project takes a traditional MVC 'New Project'/'Framework Features' approach to file structure.

**ASPNETCoreMVC.FeatureFocus.Web**

This project takes a business or domain 'Features' approach to file structure.

## Developing

### Requirements

* [ASP.NET Core 2.1+](https://www.microsoft.com/net/learn/get-started/windows)
  * .NET Core 2.1 [Release notes](https://blogs.msdn.microsoft.com/webdev/2018/05/30/asp-net-core-2-1-0-now-available/)
* Latest [Visual Studio](https://www.visualstudio.com/thank-you-downloading-visual-studio/?sku=community&rel=15)

## Running

* Open the solution
* Build projects and run/debug one from within Visual Studio

`/customersadmin` loads the admin page. You must have a cookie for the current domain with the following key/value to be authorized

    key: isAdmin
    value: true

`/myaccount` loads the current customer's account page. You must have a cookie for the current domain with following key/value to be authorized

    key: customerId
    value: 1