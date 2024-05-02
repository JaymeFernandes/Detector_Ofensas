# Detector de Ofensas 🔍

El Detector de Ofensas es una API simple para identificar lenguaje ofensivo en textos. Utilizando algoritmos de similitud de cadenas, verifica si un texto contiene palabras consideradas ofensivas.

[¿Curioso sobre cómo funciona?](Algorithm/README.md)

<br>

# Selector de Idioma 🌐

<table border=1>
  <tr>
    <td><a href="https://github.com/JaymeFernandes/Detector_Ofensas/blob/main/README.md">English</a></td>
    <td><a href="https://github.com/JaymeFernandes/Detector_Ofensas/blob/main/README_pt.md">Português</a></td>
    <td><a href="https://github.com/JaymeFernandes/Detector_Ofensas/blob/main/README_es.md">Español</a></td>
  </tr>
</table>

# Mejora de Rendimiento ⚡️

Recientemente optimizamos nuestra API que solía analizar 32.681 caracteres en 20 segundos.
¡Ahora completa la misma tarea en solo 2 segundos!

Esto fue posible gracias al uso de iteraciones en paralelo con Parallel.ForEach.

Esta técnica divide automáticamente la carga de trabajo entre los procesadores, permitiendo que cada núcleo trabaje simultáneamente.

¡El resultado es un rendimiento significativamente mejorado! 🚀

<br>

# Funcionalidades 🚀

- Detecta 118 palabras ofensivas diferentes.
- Calcula una puntuación del 1 al 100 para el texto.
- Es extremadamente sensible a las ofensas, incluso con caracteres alterados, como por ejemplo:
```
  V4c@ = vaca
  t4r4d0 = tarado
  |!x0 = lixo
```

# Versión

<table border=1>
  <tr>
    <td><a href="https://github.com/JaymeFernandes/Detector_Ofensas/tree/main/Local-Dll">Local</a></td>
    <td><a href="https://github.com/JaymeFernandes/Detector_Ofensas/tree/main/Online-Api">API</a></td>
  </tr>
</table>

<br>

# Contribuciones 🤝

Se encontrar um problema ou tiver uma sugestão, sinta-se à vontade para abrir uma issue ou enviar um pull request. Contribuições são bem-vindas!

<br>

# Licencia 📝

Este proyecto está bajo la [Licencia MIT](LICENSE).