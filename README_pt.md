# Detector de Ofensas 🔍

O Detector de Ofensas é uma API simples para a identificação de linguagem ofensiva em textos. Utilizando algoritmos de similaridade de strings, verifica se um texto contém palavras consideradas ofensivas.

[Está curioso como funciona?](Algorithm/README.md)

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

# Melhoria de Desempenho ⚡️

Recentemente, otimizamos nossa API que analisava 32.681 caracteres em 20 segundos. Agora, ela conclui a mesma tarefa em apenas 2 segundos!

Isso foi possível graças ao uso das iterações em paralelo com Parallel.ForEach.

Essa abordagem divide a tarefa entre os processadores, permitindo que cada núcleo trabalhe simultaneamente.
 
O resultado? Um desempenho muito mais rápido! 🚀

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

# Versão

<table border=1>
  <tr>
    <td><a href="https://github.com/JaymeFernandes/Detector_Ofensas/tree/main/Local-Dll">Local</a></td>
    <td><a href="https://github.com/JaymeFernandes/Detector_Ofensas/tree/main/Online-Api">API</a></td>
  </tr>
</table>

<br>

# Contribuindo 🤝

Se encontrar um problema ou tiver uma sugestão, sinta-se à vontade para abrir uma issue ou enviar um pull request. Contribuições são bem-vindas!

<br>

# Licença 📝

Este projeto é licenciado sob a [Licença MIT](LICENSE).