
# Escolha o Idioma 🌐

<table border=1>
  <tr>
    <td><a href="https://github.com/JaymeFernandes/Detector_Ofensas/blob/main/Local-Dll/README.md">English</a></td>
    <td><a href="https://github.com/JaymeFernandes/Detector_Ofensas/blob/main/Local-Dll/README_pt.md">Português</a></td>
    <td><a href="https://github.com/JaymeFernandes/Detector_Ofensas/blob/main/Local-Dll/README_es.md">Español</a></td>
  </tr>
</table>

# Requisitos 🛠️

- [Visual Studio](https://visualstudio.microsoft.com/pt-br/)
- [ASP.NET Core](https://dotnet.microsoft.com/pt-br/apps/aspnet)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)

<br>

# Stack utilizada 🛠️

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

# Segurança 🔒

### Proteção contra SQL Injection 💉

Este projeto implementa medidas para prevenir SQL injection. Algumas das práticas de segurança incluem:

- **Parâmetros em Consultas SQL:** Utilizamos parâmetros em consultas SQL para evitar a concatenação direta de strings com dados fornecidos pelo usuário.

- **Validação de Entrada:** Validamos e sanitizamos todas as entradas do usuário para garantir que apenas dados válidos sejam utilizados nas consultas SQL.

- **Uso de Prepared Statements:** O código utiliza prepared statements, o que contribui para a prevenção automática de SQL injection.

Essas práticas foram adotadas para garantir a integridade e segurança do sistema contra potenciais ataques de SQL injection.

### Outras Medidas de Segurança 🔒

Além da proteção contra SQL injection, o projeto também implementa outras medidas de segurança, como [lista de outras práticas de segurança adotadas, se aplicável].

Lembramos que a segurança é um esforço contínuo, e incentivamos a revisão regular das práticas de segurança conforme necessário.

<br>

# Instalação 💻

1. ### Clone o repositório para o seu ambiente local:

   ```bash
   git clone https://github.com/seu-usuario/detector-de-ofensas.git

2. ### Navegue até o diretório do projeto e Restaure as dependências do NuGet:
   ```bash
   # Abre o caminho:
   cd caminho/do/seu/projeto/detector-de-ofensas

   # Restaura as dependências do NuGet:
   dotnet restore

   #Abre o projeto no Visual Studio
   dotnet sln Detector-Ofensas.API.sln
   ```
  Substitua 'caminho/do/seu/projeto/detector-de-ofensas' pelo caminho real onde o seu projeto está localizado.

3. ### Create the migration
    ```bash
    # install dotnet-ef
    dotnet tool install --global dotnet-ef

    # Create the migration
    dotnet ef migrations add NombreDeLaMigración
    dotnet ef database update
    ```
