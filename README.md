# Detector de Ofensas

O Detector de Ofensas é uma API simples para identificação de linguagem ofensiva em textos. Utiliza algoritmos de similaridade de strings para verificar se um texto contém palavras consideradas ofensivas.

## Funcionalidade

- Detectar 118 palavras diferentes
- Calcula a pontuação de 1 a 100 do texto.
- Ultramente sensivel a ofensas mesmo com caracteres trocados:
```
  V4c@ = vaca
  t4r4d0 = tarado
  |!x0 = lixo
```

## Requisitos

- [.NET Framework 4.7.2](https://dotnet.microsoft.com/pt-br/download/dotnet-framework/net472)
- [Visual Studio](https://visualstudio.microsoft.com/pt-br/)

## API Usadas no projeto
- [SimMetrics.Net](https://www.nuget.org/packages/SimMetrics.Net) 
- [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json)


## Instalação

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
  Substitua caminho/do/seu/projeto/detector-de-ofensas pelo caminho real onde o seu projeto está localizado.

## Comandos

  1. ### Verificar um texto
```csharp
//Retorna a lista das palavras identificadas no texto
    List<string> strings = FiltroRespeitoso.VerificarTexto(texto);
```

  2. ### Calcular pontuação de ofensa do texto
```csharp
//Calcula a pontuação do texto
    double value = FiltroRespeitoso.ObterPercentual(texto);
```

## Contribuindo

Se encontrar um problema ou tiver uma sugestão, sinta-se à vontade para abrir uma issue ou enviar um pull request. Contribuições são bem-vindas!

## Licença

Este projeto é licenciado sob a [Licença MIT](LICENSE).