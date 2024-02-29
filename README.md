# Detector de Ofensas

O Detector de Ofensas é uma API simples para a identificação de linguagem ofensiva em textos. Utilizando algoritmos de similaridade de strings, verifica se um texto contém palavras consideradas ofensivas.
Foi otimizado a API que analizava 32681 caracteres em 20 segundos e diminuiu para 2 segundos

# Funcionalidade

- Detecta 118 palavras ofensivas diferentes.
- Calcula uma pontuação de 1 a 100 para o texto.
- Extremamente sensível a ofensas, mesmo com caracteres trocados:
```
  V4c@ = vaca
  t4r4d0 = tarado
  |!x0 = lixo
```

# Requisitos

- [.NET Framework 4.7.2](https://dotnet.microsoft.com/pt-br/download/dotnet-framework/net472)
- [Visual Studio](https://visualstudio.microsoft.com/pt-br/)
- [MySQL Workbench](https://dev.mysql.com/downloads/)

# Stack utilizada

**DataBase:** [MySQL](https://www.mysql.com/)

**Back-end:** [C#](https://dotnet.microsoft.com/pt-br/languages/csharp)

# Bibliotecas Utilizadas
- [SimMetrics.Net](https://www.nuget.org/packages/SimMetrics.Net) 
- [MySQL.Data](https://www.nuget.org/packages/MySql.Data/)

# Segurança

### Proteção contra SQL Injection

Este projeto implementa medidas para prevenir SQL injection. Algumas das práticas de segurança incluem:

- **Parâmetros em Consultas SQL:** Utilizamos parâmetros em consultas SQL para evitar a concatenação direta de strings com dados fornecidos pelo usuário.

- **Validação de Entrada:** Validamos e sanitizamos todas as entradas do usuário para garantir que apenas dados válidos sejam utilizados nas consultas SQL.

- **Uso de Prepared Statements:** O código utiliza prepared statements, o que contribui para a prevenção automática de SQL injection.

Essas práticas foram adotadas para garantir a integridade e segurança do sistema contra potenciais ataques de SQL injection.

### Outras Medidas de Segurança

Além da proteção contra SQL injection, o projeto também implementa outras medidas de segurança, como [lista de outras práticas de segurança adotadas, se aplicável].

Lembramos que a segurança é um esforço contínuo, e incentivamos a revisão regular das práticas de segurança conforme necessário.

# Instalação

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

# Comandos

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
List<string> strings = FiltroRespeitoso.VerificarTexto(texto);

// Calcula o percentual da ofensa
double percentual = FiltroRespeitoso.ObterPercentual(string mensagem)
```

  4. ### Adicionar idiomas personalizados:

```csharp
// Define a database MySQL para conectar ou criar a database
DbService.Connect("server=localhost;uid=root;pwd=sua-Senha;");

// Cria a lista de Ofensas 
List<Ofensa> ofensas = new List<Ofensa> 
{
    new Ofensa { palavra = "palavra-1", nivel = 100 },
    new Ofensa { palavra = "palavra-2", nivel = 80 }
};

// Adiciona ao Banco de Dados
FiltroRespeitoso.CarregarPalavrasPersonalizadas(ofensas);
```

# Contribuindo

Se encontrar um problema ou tiver uma sugestão, sinta-se à vontade para abrir uma issue ou enviar um pull request. Contribuições são bem-vindas!

# Licença

Este projeto é licenciado sob a [Licença MIT](LICENSE).