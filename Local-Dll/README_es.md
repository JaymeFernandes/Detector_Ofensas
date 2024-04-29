# Selector de Idioma 🌐

<table border=1>
  <tr>
    <td><a href="https://github.com/JaymeFernandes/Detector_Ofensas/blob/main/Local-Dll/README.md">English</a></td>
    <td><a href="https://github.com/JaymeFernandes/Detector_Ofensas/blob/main/Local-Dll/README_pt.md">Português</a></td>
    <td><a href="https://github.com/JaymeFernandes/Detector_Ofensas/blob/main/Local-Dll/README_es.md">Español</a></td>
  </tr>
</table>

# Requisitos 🛠️

- [.NET Framework 4.7.2](https://dotnet.microsoft.com/pt-br/download/dotnet-framework/net472)
- [Visual Studio](https://visualstudio.microsoft.com/pt-br/)
- [MySQL Workbench](https://dev.mysql.com/downloads/)

<br>

# Tecnologías Utilizadas 🛠️

**DataBase** 

[![MySQL](https://img.shields.io/badge/MySQL-005C84?style=for-the-badge&logo=mysql&logoColor=white)](https://www.mysql.com/)

**Back-end** 

[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://dotnet.microsoft.com/pt-br/languages/csharp)

<br>

# Bibliotecas Utilizadas 📚
- [SimMetrics.Net](https://www.nuget.org/packages/SimMetrics.Net) 
- [MySQL.Data](https://www.nuget.org/packages/MySql.Data/)

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
   dotnet sln Detector-Ofensas.sln
   ```

Sustituye 'ruta/de/tu/proyecto/detector-de-ofensas' por la ruta real donde se encuentra tu proyecto.

<br>

# Comandos 💬

  1. ### conectar com o banco de dados/DataBase:
```csharp
// Define la base de datos MySQL para conectar (campo obligatorio)
DbService.Connect("server=localhost;uid=root;pwd=Sua-Senha;");
```

  2. ### Verificar um texto:
```csharp
// Define la base de datos MySQL para conectar o crear la base de datos
DbService.Connect("server=localhost;uid=root;pwd=sua-Senha;");

// Devuelve la lista de palabras identificadas en el texto
List<string> strings = RespectfulFilter.CheckText(text);

// Calcula el porcentaje de ofensas
double percent = RespectfulFilter.GetPercentage(string message)
```

  4. ### Adicionar idiomas personalizados:

```csharp
// Define la base de datos MySQL para conectar o crear la base de datos
DbService.Connect("server=localhost;uid=root;pwd=sua-Senha;");

// Crea la lista de Ofensas
List<Offense> offenses = new List<Offense> 
{
    new Offense { word = "word-1", level = 100 },
    new Offense { word = "word-2", level = 80 }
};

// Agrega a la base de datos
RespectfulFilter.LoadCustomWords(offenses);(ofensas);
```