# Detector de Ofensas 🔍

O Detector de Ofensas é uma API simples para a identificação de linguagem ofensiva em textos. Utilizando algoritmos de similaridade de strings, verifica se um texto contém palavras consideradas ofensivas.
Foi otimizado a API que analizava 32.681 caracteres em 20 segundos e diminuiu para 2 segundos

<br>

# Escolha o Idioma 🌐

<table border=1>
  <tr>
    <td><a href="https://github.com/JaymeFernandes/Detector_Ofensas/blob/main/README.md">English</a></td>
    <td><a href="https://github.com/JaymeFernandes/Detector_Ofensas/blob/main/README_pt.md">Português</a></td>
    <td><a href="https://github.com/JaymeFernandes/Detector_Ofensas/blob/main/README_es.md">Español</a></td>
  </tr>
</table>

<br>

# Funcionalidade 🚀

- Detecta 118 palavras ofensivas diferentes.
- Calcula uma pontuação de 1 a 100 para o texto.
- Extremamente sensível a ofensas, mesmo com caracteres trocados:
```
  V4c@ = vaca
  t4r4d0 = tarado
  |!x0 = lixo
```

<br>

# Requisitos 🛠️

- [.NET Framework 4.7.2](https://dotnet.microsoft.com/pt-br/download/dotnet-framework/net472)
- [Visual Studio](https://visualstudio.microsoft.com/pt-br/)
- [MySQL Workbench](https://dev.mysql.com/downloads/)

<br>

# Stack utilizada 🛠️

**DataBase** 

[![MySQL](https://img.shields.io/badge/MySQL-005C84?style=for-the-badge&logo=mysql&logoColor=white)](https://www.mysql.com/)

**Back-end** 

[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://dotnet.microsoft.com/pt-br/languages/csharp)

<br>

# Bibliotecas Utilizadas 📚
- [SimMetrics.Net](https://www.nuget.org/packages/SimMetrics.Net) 
- [MySQL.Data](https://www.nuget.org/packages/MySql.Data/)

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
   dotnet sln Detector-Ofensas.sln
   ```
  Substitua 'caminho/do/seu/projeto/detector-de-ofensas' pelo caminho real onde o seu projeto está localizado.

<br>

# Comandos 💬

  1. ### conectar com o banco de dados/DataBase:
```csharp
// Define a database MySQL para conectar (campo obrigatório)
DbService.Connect("server=localhost;uid=root;pwd=Sua-Senha;");
```

  2. ### Verificar um texto:
```csharp
// Define a database MySQL para conectar ou criar a database
DbService.Connect("server=localhost;uid=root;pwd=sua-Senha;");

//Retorna a lista das palavras identificadas no texto
List<string> strings = RespectfulFilter.CheckText(text);

// Calcula o percentual da ofensa
double percent = RespectfulFilter.GetPercentage(string message)
```

  4. ### Adicionar idiomas personalizados:

```csharp
// Define a database MySQL para conectar ou criar a database
DbService.Connect("server=localhost;uid=root;pwd=sua-Senha;");

// Cria a lista de Ofensas 
List<Offense> offenses = new List<Offense> 
{
    new Offense { word = "word-1", level = 100 },
    new Offense { word = "word-2", level = 80 }
};

// Adiciona ao Banco de Dados
RespectfulFilter.LoadCustomWords(offenses);(ofensas);
```

<br>

# Contribuindo 🤝

Se encontrar um problema ou tiver uma sugestão, sinta-se à vontade para abrir uma issue ou enviar um pull request. Contribuições são bem-vindas!

<br>

# Licença 📝

Este projeto é licenciado sob a [Licença MIT](LICENSE).