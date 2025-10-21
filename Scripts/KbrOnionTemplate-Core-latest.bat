@echo off
set /p "app=Enter application name: "
rem echo Are You Sure?
choice /c YN /M "Are You Sure?"
if %errorlevel%==1 goto yes
if %errorlevel%==2 goto no
:yes
echo Creating %app%

if not exist %app% mkdir %app%
cd %app%

rem dotnet new mvc -au Individual -uld -o %app%.Mvc
dotnet new blazor -au None -o %app%.WebUi
dotnet new classlib -o %app%.Application
dotnet new classlib -o %app%.Domain
dotnet new nunit -o %app%.Domain.Test
dotnet new classlib -o %app%.Infrastructure

dotnet add %app%.WebUi reference %app%.Application
dotnet add %app%.WebUi reference %app%.Domain
dotnet add %app%.WebUi reference %app%.Infrastructure
dotnet add %app%.Domain.Test reference %app%.Domain
dotnet add %app%.Application reference %app%.Domain
dotnet add %app%.Infrastructure reference %app%.Domain
dotnet add %app%.Infrastructure reference %app%.Application

dotnet new sln -n %app%
dotnet sln %app%.sln add %app%.WebUi/%app%.WebUi.csproj
dotnet sln %app%.sln add %app%.Application/%app%.Application.csproj
dotnet sln %app%.sln add %app%.Domain/%app%.Domain.csproj
dotnet sln %app%.sln add %app%.Domain.Test/%app%.Domain.Test.csproj
dotnet sln %app%.sln add %app%.Infrastructure/%app%.Infrastructure.csproj

dotnet add %app%.WebUi/%app%.WebUi.csproj package Microsoft.EntityFrameworkCore
dotnet add %app%.WebUi/%app%.WebUi.csproj package Microsoft.EntityFrameworkCore.SqlServer
dotnet add %app%.WebUi/%app%.WebUi.csproj package Microsoft.EntityFrameworkCore.Tools

dotnet add %app%.Infrastructure/%app%.Infrastructure.csproj package Microsoft.EntityFrameworkCore
dotnet add %app%.Infrastructure/%app%.Infrastructure.csproj package Microsoft.EntityFrameworkCore.SqlServer
dotnet add %app%.Infrastructure/%app%.Infrastructure.csproj package Microsoft.EntityFrameworkCore.Tools


dotnet add %app%.Domain.Test/%app%.Domain.Test.csproj package Moq
@echo off
echo Update nuget packages
rem "https://www.reddit.com/r/dotnet/comments/1757s1o/upgrading_multiple_nuget_packages_in_jetbrains/?rdt=62769"
dotnet tool install --global dotnet-outdated-tool 
dotnet outdated --upgrade
:no