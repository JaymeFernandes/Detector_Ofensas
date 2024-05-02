# Offense Detector 🔍

The Offense Detector is a simple API for identifying offensive language in texts. By using string similarity algorithms, it checks if a text contains words considered offensive.

[Curious how it works?](Algorithm/README.md)

<br>

# Choose Language 🌐

<table border=1>
  <tr>
    <td><a href="https://github.com/JaymeFernandes/Detector_Ofensas/blob/main/README.md">English</a></td>
    <td><a href="https://github.com/JaymeFernandes/Detector_Ofensas/blob/main/README_pt.md">Português</a></td>
    <td><a href="https://github.com/JaymeFernandes/Detector_Ofensas/blob/main/README_es.md">Español</a></td>
  </tr>
</table>


# Performance Boost ⚡️

We recently optimized our API that used to analyze 32,681 characters in 20 seconds. Now, it completes the same task in just 2 seconds!

This achievement was made possible by utilizing parallel iterations with Parallel.ForEach.

This approach automatically divides the workload among processors, allowing each core to work simultaneously.

The result? Significantly improved performance! 🚀

<br>

# Funcionalidade 🚀

- Detects 118 different offensive words.
- Calculates a score from 1 to 100 for the text.
- Extremely sensitive to offenses, even with swapped characters:
```
  V4c@ = cow
  t4r4d0 = pervert
  |!x0 = trash
```

<br>

# Version

<table border=1>
  <tr>
    <td><a href="https://github.com/JaymeFernandes/Detector_Ofensas/tree/main/Local-Dll">Local</a></td>
    <td><a href="https://github.com/JaymeFernandes/Detector_Ofensas/tree/main/Online-Api">API</a></td>
  </tr>
</table>

<br>

# Contributing 🤝

If you find an issue or have a suggestion, feel free to open an issue or submit a pull request. Contributions are welcome!

<br>

# License 📝

This project is licensed under the [MIT License](LICENSE).