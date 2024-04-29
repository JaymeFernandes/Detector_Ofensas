# Selector de Idioma 🌐

<table border=1>
  <tr>
    <td><a href="https://github.com/JaymeFernandes/Detector_Ofensas/blob/main/Online-Api/README.md">English</a></td>
    <td><a href="https://github.com/JaymeFernandes/Detector_Ofensas/blob/main/Online-Api/README_pt.md">Português</a></td>
    <td><a href="https://github.com/JaymeFernandes/Detector_Ofensas/blob/main/Online-Api/README_es.md">Español</a></td>
  </tr>
</table>

# Requisitos 🛠️

- [Visual Studio](https://visualstudio.microsoft.com/pt-br/)
- [ASP.NET Core](https://dotnet.microsoft.com/pt-br/apps/aspnet)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)

<br>

# Tecnologías Utilizadas 🛠️

**DataBase** 

<a href="https://www.microsoft.com/pt-br/sql-server/sql-server-downloads">
    <img height="60px" src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/microsoftsqlserver/microsoftsqlserver-original-wordmark.svg"/>
</a>

**Back-end** 

[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://dotnet.microsoft.com/pt-br/languages/csharp)

<br>

# Bibliotecas Utilizadas 📚
- [SimMetrics.Net](https://www.nuget.org/packages/SimMetrics.Net) 
- [Microsoft.EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore)

<br>

# Seguridad 🔒

### Protección contra Inyección SQL

Este proyecto implementa medidas para prevenir la inyección SQL. Algunas de las prácticas de seguridad incluyen:

- **Parámetros en Consultas SQL:** Utilizamos parámetros en consultas SQL para evitar la concatenación directa de cadenas con datos proporcionados por el usuario.

- **Validación de Entrada:** Validamos y sanitizamos todas las entradas del usuario para garantizar que solo se utilicen datos válidos en las consultas SQL.

- **Uso de Sentencias Preparadas:** El código utiliza sentencias preparadas, lo que contribuye a la prevención automática de la inyección SQL.

### Otras Medidas de Seguridad

Además de la protección contra la inyección SQL, el proyecto también implementa otras medidas de seguridad, como [lista de otras prácticas de seguridad adoptadas, si corresponde].

Recordamos que la seguridad es un esfuerzo continuo, y recomendamos revisar regularmente las prácticas de seguridad según sea necesario.

<br>

# Instalación ⚙️

1. ### Clona el repositorio en tu entorno local:

   ```bash
   git clone https://github.com/seu-usuario/detector-de-ofensas.git

2. ### Navega hasta el directorio del proyecto y restaura las dependencias de NuGet:
   ```bash
   # Abre el directorio:
   cd ruta/de/tu/proyecto/detector-de-ofensas

   # Restaura las dependencias de NuGet:
   dotnet restore

   # Abre el proyecto en Visual Studio
   dotnet sln Detector-Ofensas.API.sln
   ```

Sustituye 'ruta/de/tu/proyecto/detector-de-ofensas' por la ruta real donde se encuentra tu proyecto.


3. ### Crie a migração
    ```bash
    # instalar dotnet-ef
    dotnet tool install --global dotnet-ef

    # crear la migración
    dotnet ef migrations add NombreDeLaMigración
    dotnet ef database update
    ```