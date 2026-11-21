# Student Course Registration System (ASP.NET Core MVC)

## How to run
Requires the .NET SDK 8.0 or later (https://dotnet.microsoft.com/download).

    cd StudentCourseRegistration
    dotnet run

Open http://localhost:5080 in the browser (or the URL shown in the terminal).
In Visual Studio: open StudentCourseRegistration.csproj and press F5.

## Pages
- Home            -> /
- Student List    -> /Student
- Register        -> /Student/Create   (GET + POST, validated)
- Student Details -> /Student/Details/1
