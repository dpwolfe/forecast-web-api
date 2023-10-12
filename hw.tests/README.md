# Notes on the test for the Web API project

## How to run tests

```sh
dotnet test
# with code coverage
dotnet test /p:CollectCoverage=true
```

## Commands used

```sh
dotnet new xunit -n hw.tests
cd hw.tests
dotnet add hw.tests.csproj reference ../hw/hw.csproj
# To resolve build warnings
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package coverlet.msbuild
dotnet add package Microsoft.EntityFrameworkCore.InMemory
```

## Outstanding work to fix with additional time

~~1. Warnings during compilation for conflicting EF dll versions.~~
~~2. Improve tests to go beyond a shallow coverage of the controller.~~
3. Improve tests to validate more pre and post conditions.
4. Add test cases for failure conditions and high code coverage percentage.
