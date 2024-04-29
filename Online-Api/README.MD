# Selector de Idioma 🌐

<table border=1>
  <tr>
    <td><a href="https://github.com/JaymeFernandes/Detector_Ofensas/blob/main/Local-Dll/README.md">English</a></td>
    <td><a href="https://github.com/JaymeFernandes/Detector_Ofensas/blob/main/Local-Dll/README_pt.md">Português</a></td>
    <td><a href="https://github.com/JaymeFernandes/Detector_Ofensas/blob/main/Local-Dll/README_es.md">Español</a></td>
  </tr>
</table>

# Requirements 🛠️

- [Visual Studio](https://visualstudio.microsoft.com/pt-br/)
- [ASP.NET Core](https://dotnet.microsoft.com/pt-br/apps/aspnet)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)

<br>

# Used Stack 🛠️

**DataBase** 

<a href="https://www.microsoft.com/pt-br/sql-server/sql-server-downloads">
    <img height="60px" src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/microsoftsqlserver/microsoftsqlserver-original-wordmark.svg"/>
</a>

**Back-end** 

[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://dotnet.microsoft.com/pt-br/languages/csharp)

<br>

# Used Libraries 📚
- [SimMetrics.Net](https://www.nuget.org/packages/SimMetrics.Net) 
- [Microsoft.EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore)

<br>

# Security 🔒

### Protection against SQL Injection 💉

This project implements measures to prevent SQL injection. Some security practices include:

- **Parameters in SQL Queries** We use parameters in SQL queries to avoid direct concatenation of strings with user-provided data.

- **Input Validation:** We validate and sanitize all user inputs to ensure that only valid data is used in SQL queries.

- **Use of Prepared Statements:**  The code uses prepared statements, which contributes to the automatic prevention of SQL injection.

These practices have been adopted to ensure the integrity and security of the system against potential SQL injection attacks.

### Other Security Measures 🔒

In addition to protection against SQL injection, the project also implements other security measures, such as [list any other security practices adopted, if applicable].

We remind you that security is an ongoing effort, and we encourage regular review of security practices as needed.

<br>

# Installation 💻

1. ### Clone the repository to your local environment:

   ```bash
   git clone https://github.com/seu-usuario/detector-de-ofensas.git

2. ### Navigate to the project directory and Restore NuGet dependencies:
   ```bash
   # Navigate to the path:
   cd path/to/your/project/offense-detector

   # Restore NuGet dependencies:
   dotnet restore

   #Open the project in Visual Studio
   dotnet sln Offense-Detector.API.sln
   ```
  Replace 'path/to/your/project/offense-detector' with the actual path where your project is located.


