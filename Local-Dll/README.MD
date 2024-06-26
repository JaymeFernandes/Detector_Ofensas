# Selector de Idioma 🌐

<table border=1>
  <tr>
    <td><a href="https://github.com/JaymeFernandes/Detector_Ofensas/blob/main/Local-Dll/README.md">English</a></td>
    <td><a href="https://github.com/JaymeFernandes/Detector_Ofensas/blob/main/Local-Dll/README_pt.md">Português</a></td>
    <td><a href="https://github.com/JaymeFernandes/Detector_Ofensas/blob/main/Local-Dll/README_es.md">Español</a></td>
  </tr>
</table>

# Requirements 🛠️

- [.NET Framework 4.7.2](https://dotnet.microsoft.com/pt-br/download/dotnet-framework/net472)
- [Visual Studio](https://visualstudio.microsoft.com/pt-br/)
- [MySQL Workbench](https://dev.mysql.com/downloads/)

<br>

# Used Stack 🛠️

**DataBase** 

[![MySQL](https://img.shields.io/badge/MySQL-005C84?style=for-the-badge&logo=mysql&logoColor=white)](https://www.mysql.com/)

**Back-end** 

[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://dotnet.microsoft.com/pt-br/languages/csharp)

<br>

# Used Libraries 📚
- [SimMetrics.Net](https://www.nuget.org/packages/SimMetrics.Net) 
- [MySQL.Data](https://www.nuget.org/packages/MySql.Data/)

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
   dotnet sln Offense-Detector.sln
   ```
  Replace 'path/to/your/project/offense-detector' with the actual path where your project is located.

<br>

# Comandos 💬

  1. ### conectar com o banco de dados/DataBase:
```csharp
// Defines the MySQL database to connect (required field)
DbService.Connect("server=localhost;uid=root;pwd=Your-Password;");
```

  2. ### Verificar um texto:
```csharp
// Defines the MySQL database to connect or create the database
DbService.Connect("server=localhost;uid=root;pwd=your-Password;");

//Returns the list of identified words in the text
List<string> strings = RespectFilter.CheckText(text);

// Calculate the offense percentage
double percentage = RespectFilter.GetPercentage(string message)
```

  4. ### Add custom languages:

```csharp
// Defines the MySQL database to connect or create the database
DbService.Connect("server=localhost;uid=root;pwd=your-Password;");

// Create the Offenses list 
List<Offense> offenses = new List<Offense> 
{
    new Offense { word = "word-1", level = 100 },
    new Offense { word = "word-2", level = 80 }
};

// Add to the Database
RespectFilter.LoadCustomWords(offenses);
```
