## LyyCMS
Address book management system based on ABP | [中文文档](README.zh-CN.md)

---
#### About Abp
[Abp website](https://aspnetboilerplate.com/)

#### Start

- Open your solution in Visual Studio 2019 (v16.4)+ and build the solution.

- Select the 'LyyCMS.Web.Mvc' project as the startup project.

- Check the connection string in the appsettings.json file of the Web.Mvc project, change it if you want.

- Open Package Manager Console and run the Update-Database command to create your database (ensure that the Default project is selected as LyyCMS.EntityFrameworkCore in the Package Manager Console window).

- Since it uses libman, go to Web.Mvc project. Right click to libman.json file. Then click to Restore Client-Side Libraries.

- (If you are not using Visual Studio and/or you are on a mac you can use Libman CLI . After installing it while in Web.Mvc folder run libman restore)

- Run the application.


#### swagger

[local swagger url](http://localhost:62114/swagger/index.html)

