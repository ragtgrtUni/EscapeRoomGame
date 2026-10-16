# 🔐 Escape Room 3D

Proyecto colaborativo de laboratorio de **Git + GitHub + Visual Studio Code + Unity**.

**Objetivo del juego:** explorar una habitación, resolver un código, abrir un cofre, obtener una llave y abrir la puerta de salida.

---

## 👥 Integrantes

| Letra | Integrante | Rama propia |
|:-----:|------------|-------------|
| A | Aaron | `Feature_PlayerMovement` |
| B | Grover | `Feature_Interaction` |
| C | Mariana | `Feature_Animation` |
| D | Cristhian | `Feature_Puzzle` |
| E | Alan | `Feature_UI` |

## 🌿 Ramas

```
main
└── Dev
    ├── Feature_PlayerMovement
    ├── Feature_Interaction
    ├── Feature_Animation
    ├── Feature_Puzzle
    └── Feature_UI
```

**Flujo:** `Feature → Dev → main`

## ⚙️ Configuración

| Elemento | Valor |
|----------|-------|
| Versión de Unity | 6000.5.5f1 |
| Active Input Handling | Both (los scripts usan `Input.GetAxis`) |
| Carpeta del proyecto Unity | `EscapeRoom/` |

---

## 📓 Bitácora

<!-- ZONA 1: TABLA RESUMEN. Cambia ⬜ por ✅ cuando termines cada caso. -->

| Caso | Tema | Responsable de evidencia | Estado |
|:----:|------|--------------------------|:------:|
| 01 | Crear el repositorio y primer commit | E — Alan | ✅ |
| 02 | Crear Dev y ramas Feature | D — Cristhian | ✅ |
| 03 | Commit en la rama equivocada | E — Alan | ✅ |
| 04 | Cambios locales y Stash | C — Mariana | ✅ |
| 05 | Push rechazado porque Dev avanzó | A — Aaron | ✅ |
| 06 | Conflicto en PlayerController.cs | E — Alan | ⬜ |
| 07 | Conflicto en Player.prefab | B — Grover | ⬜ |
| 08 | Conflicto en MainScene.unity | D — Cristhian | ⬜ |
| 09 | Archivo eliminado vs. modificado | B — Grover | ⬜ |
| 10 | Dos alumnos crean PuzzleManager.cs | C — Mariana | ⬜ |
| 11 | Cambios en ProjectSettings | D — Cristhian | ⬜ |
| 12 | Commit incorrecto | A — Aaron | ⬜ |
| 13 | Archivo que debía estar en .gitignore | B — Grover | ⬜ |
| 14 | Feature desactualizada respecto a Dev | C — Mariana | ⬜ |
| 15 | Conflicto en varios archivos | D — Cristhian | ⬜ |
| 16 | Accept Both rompe el juego | D — Cristhian | ⬜ |
| 17 | Revert de un cambio compartido | C — Mariana | ⬜ |
| 18 | Recuperar trabajo aparentemente perdido | E — Alan | ⬜ |
| 19 | Cherry-pick de una corrección | A — Aaron | ⬜ |
| 20 | Pull Request y entrega final | C — Mariana | ⬜ |

<!-- ZONA 2: DETALLE POR CASO. Para responder un caso, reemplaza *(pendiente)* por tu respuesta. -->

### Caso 01 — Crear el repositorio y primer commit

**1. ¿Por qué no conviene subir `Library/`?**
> Porque es una carpeta que Unity regenera sola en cada PC (caché, importaciones). Pesa mucho, cambia constantemente y causaría conflictos inútiles en cada commit. Lo que hay que compartir es `Assets`, `Packages` y `ProjectSettings`.

**2. ¿Qué diferencia existe entre un archivo ignorado y un archivo que ya está siendo seguido por Git?**
> `.gitignore` solo evita que Git empiece a seguir archivos nuevos. Si un archivo ya fue commiteado, Git sigue rastreándolo aunque lo añadas al `.gitignore`.

**3. ¿Qué información representa un commit?**
> Una foto del proyecto en un momento dado: los cambios incluidos, el autor, la fecha, un mensaje y un identificador único (hash) que lo enlaza con el commit anterior.

**4. ¿Qué función cumple el repositorio remoto?**
> Es la copia compartida (GitHub) donde el equipo sincroniza su trabajo, hace respaldo y revisa cambios con Pull Requests.

---

### Caso 02 — Crear Dev y ramas Feature

**1. ¿Desde qué commit nació tu Feature?**
> Mi rama `Feature_Puzzle` nació desde el commit en el que agregué la línea del flujo de trabajo en el README.md (`docs: add branch workflow`), creado justo después de crear la rama `Dev`.

**2. ¿Por qué una Feature no debería nacer directamente de `main` en este laboratorio?**
> Porque en la estrategia de ramas de este proyecto, `main` se reserva para versiones estables y entregas finales validadas mediante Pull Requests. Si una Feature nace de `main`, se salta el entorno de integración intermedio (`Dev`), lo que rompe el flujo de colaboración, provoca mezclas prematuras de código sin probar y dificulta detectar errores antes de llegar a `main`.

---

### Caso 03 — Commit en la rama equivocada

**1. ¿Qué significa que una rama apunte a un commit?**
> Una rama es solo una etiqueta que señala un commit. Al hacer un commit nuevo, la etiqueta de la rama actual se mueve a él. Por eso se puede crear otra rama en ese mismo punto y conservar el trabajo.

**2. ¿Por qué no se debe copiar manualmente el archivo a otra rama y borrar el original como solución de Git?**
> Porque se pierde la historia (autor, mensaje, fecha), se pueden perder cambios y no se corrige el error en Git: el commit equivocado sigue en `Dev`. Lo correcto es mover la referencia o hacer Revert.

---

### Caso 04 — Cambios locales y Stash

**1. ¿Qué problema resuelve Stash?**
> Resuelve la necesidad de guardar temporalmente cambios de código a medio terminar para limpiar tu espacio de trabajo sin perder nada, permitiéndote cambiar de rama rápidamente para solucionar una urgencia o actualizar tu proyecto.

**2. ¿Por qué Stash no reemplaza a Commit?**
> Porque el stash es solo un borrador local y temporal que no guarda un historial permanente ni se puede compartir en GitHub, mientras que un commit crea un punto de control definitivo e inmutable en el historial que se sincroniza con todo el equipo.

**3. ¿Qué puede ocurrir al aplicar un stash sobre una rama que cambió?**
> Pueden generarse conflictos de fusión (merge conflicts) si el código que guardaste en el stash intenta modificar las mismas líneas de un archivo que fueron cambiadas en la rama mientras estabas ausente, obligándote a resolver las diferencias a mano.

---

### Caso 05 — Push rechazado porque Dev avanzó

**1. ¿Qué diferencia hay entre Fetch y Pull?**
> Fetch solo descarga los nuevos commits e información del servidor remoto a tu computadora sin modificar ni tocar tu código actual, mientras que Pull descarga esa misma información e intenta fusionarla (merge) de inmediato con tu rama de trabajo activa.

**2. ¿Por qué Git rechaza un Push no fast-forward?**
> Lo rechaza por seguridad para evitar que subas una versión de la historia que ignore o sobrescriba los commits que otros compañeros ya habían publicado en el servidor remoto mientras tu copia local estaba desactualizada.

**3. ¿Qué riesgo existiría si el remoto pudiera ser sobrescrito automáticamente?**
> El riesgo principal sería la pérdida permanente de trabajo del equipo, ya que cualquier integrante podría borrar o reemplazar accidentalmente los avances de sus compañeros con un simple push, desorganizando todo el proyecto.

---

### Caso 06 — Conflicto en PlayerController.cs

**1. ¿Qué diferencia existe entre resolver texto y resolver software?**
> Resolver texto es decidir qué líneas quedan. Resolver software es lograr que el código funcione: conservar la intención de ambos autores, que compile y que el juego se comporte bien.

**2. ¿Qué significa Current?**
> Es la versión de la rama en la que uno está parado (la que recibe el merge). Incoming es la que viene de la otra rama.

**3. ¿Por qué siempre se prueba Unity después?**
> Porque un merge sin errores de Git puede compilar mal o romper el comportamiento. Solo ejecutar el juego confirma que el resultado es correcto.

---

### Caso 07 — Conflicto en Player.prefab

**1. ¿Por qué un Prefab es más delicado que un script?**
> Estructura YAML compleja: A diferencia de un script de código plano (.cs) donde los conflictos de texto se resuelven de forma lineal y predecible, un Prefab almacena una estructura jerárquica serializada muy densa basada en identificadores únicos (fileID y GUID). Alto riesgo de corrupción total: Un pequeño error al fusionar bloques de texto en un Prefab puede corromper el archivo por completo, impidiendo que Unity logre leerlo y provocando que el objeto desaparezca o falle en el proyecto.

**2. ¿Qué tipo de referencias pueden romperse?**
> Referencias a scripts y componentes (Missing Script): Se pierde el enlace que conecta al GameObject con el código o componente que le otorga su funcionalidad. Referencias a Assets externos: Enlaces rotos hacia texturas, materiales, animaciones, prefabs hijos o archivos de audio debido a alteraciones en los identificadores de los archivos. Modificaciones anidadas (Prefab Overrides): Conexiones alteradas entre un Prefab principal y sus instancias o variantes, haciendo que pierdan los cambios personalizados aplicados en la escena.

---

### Caso 08 — Conflicto en MainScene.unity

**1. ¿Por qué conviene evitar editar la misma escena simultáneamente?**
> Es fácil romper la escena: Unity guarda las escenas en archivos de texto (YAML) muy complejos. Un fallo al resolver un conflicto a mano puede corromper la escena o romper las referencias de los componentes (Missing). Git no entiende los cambios de Unity: Unity modifica datos invisibles de la escena con solo mover la cámara o hacer clic, provocando conflictos accidentales que complican el merge.

**2. ¿Cómo organizarías el trabajo del equipo para reducir estos conflictos?**
> Trabajar con Prefabs: Que cada integrante edite objetos por separado dentro de sus propios Prefabs y no directamente en la escena principal. Dividir en Subescenas: Usar escenas pequeñas e independientes (ej. una para la interfaz, otra para el mapa y otra para la jugabilidad). Comunicación o Bloqueo de archivos: Avisar al equipo antes de tocar la escena compartida o usar herramientas con bloqueo de archivos (Git LFS Locking).

---

### Caso 09 — Archivo eliminado vs. modificado

**1. ¿Git puede decidir arquitectura?**
> No. Git solo detecta que una rama borró el archivo y la otra lo modificó, pero no sabe si ese archivo todavía es necesario. Eso lo decide el equipo según el diseño: si su responsabilidad se movió a otra clase o si sigue siendo útil.

**2. ¿Qué riesgo hay en conservar un archivo solo para evitar el conflicto?**
> Se deja código muerto u obsoleto, con lógica duplicada que confunde al equipo y puede romper referencias. Además se acumula deuda técnica y se ignora la decisión de diseño de quien lo eliminó.

---

### Caso 10 — Dos alumnos crean PuzzleManager.cs

**1. ¿Por qué "el último commit gana" no es una regla válida?**
> Porque solo depende de quién subió primero o después, no de qué versión es mejor. Esa regla sobrescribe el trabajo del otro compañero y se pierde funcionalidad que el juego necesita.

**2. ¿Qué principio de diseño debe guiar la integración?**
> Responsabilidad única y fuente única de verdad: debe existir un solo `PuzzleManager` que combine lo necesario de ambas versiones, evitando duplicar lógica. Antes de integrar, se acuerda con el equipo qué hace cada parte.

---

### Caso 11 — Cambios en ProjectSettings

**1. ¿Por qué no se debe aceptar ProjectSettings a ciegas?**
> Porque esos archivos controlan la configuración global del proyecto (input, capas, tags, build, calidad). Un cambio aceptado sin revisar puede romper el juego para todo el equipo, y a veces Unity los modifica solo por abrir el proyecto en otra PC.

**2. ¿Qué configuración consideras especialmente sensible?**
> *Active Input Handling*. Nuestros scripts usan `Input.GetAxis`, así que si alguien lo cambia a solo "Input System Package", el movimiento deja de funcionar. También son sensibles las capas/tags y el Build Settings (escenas incluidas).

---

### Caso 12 — Commit incorrecto

**1. ¿Cuándo conviene Amend?**
> Cuando el error está en el último commit y todavía no se ha subido al remoto, por ejemplo para corregir el mensaje o añadir un archivo que se olvidó. Así se evita llenar el historial de commits de corrección.

**2. ¿Por qué reescribir historia compartida puede afectar a otros?**
> Porque Amend cambia el hash del commit. Si otros ya descargaron el original, sus historias divergen del remoto y obligan a forzar el push, lo que puede borrar trabajo ajeno o duplicar commits y causar conflictos.

---

### Caso 13 — Archivo que debía estar en .gitignore

**1. ¿Por qué `.gitignore` no borró el historial?**
> Porque `.gitignore` solo afecta a archivos que Git aún no sigue. Lo que ya fue commiteado queda en la historia y sigue rastreado; hay que dejar de seguirlo con `git rm --cached` y hacer un nuevo commit.

**2. ¿Qué diferencia hay entre Working Tree e Index?**
> El Working Tree son los archivos reales en tu carpeta, tal como los editas. El Index (staging area) es la lista de cambios que preparaste con `git add` y que entrarán en el próximo commit.

---

### Caso 14 — Feature desactualizada respecto a Dev

**1. ¿Por qué conviene resolver el conflicto en la Feature?**
> Porque así `Dev` se mantiene estable: el conflicto se resuelve y se prueba en la rama propia antes de integrar. Cuando la Feature llega a `Dev`, ya entra limpia y el Pull Request es más fácil de revisar.

**2. ¿Qué diferencia conceptual existe entre merge y rebase?**
> Merge une dos ramas con un commit de fusión y conserva la historia tal como ocurrió. Rebase reaplica tus commits encima del último commit de `Dev`, reescribiéndolos (nuevos hashes) para lograr una historia lineal.

---

### Caso 15 — Conflicto en varios archivos

**1. ¿Cómo organizaste la resolución?**
> Primero listé todos los archivos en conflicto y los resolví uno por uno, empezando por los scripts (.cs), luego los prefabs y por último la escena. Coordiné con los dueños de cada cambio para conservar la intención de ambos y guardé cada resolución antes de pasar a la siguiente.

**2. ¿Por qué conviene validar Unity después de resolver todos?**
> Porque los archivos dependen entre sí: un script, un prefab y la escena se referencian. Aunque cada uno parezca bien, solo abrir Unity confirma que compila, que no hay *Missing* y que el juego funciona.

---

### Caso 16 — Accept Both rompe el juego

**1. ¿Por qué Accept Both no garantiza corrección?**
> Porque solo junta ambos bloques de texto sin entender el código. Puede dejar variables o métodos duplicados, o dos lógicas que se contradicen (por ejemplo, el movimiento aplicado dos veces), y eso causa errores de compilación o comportamientos raros.

**2. ¿Qué pruebas detectaron el problema?**
> La consola de Unity mostró errores de compilación y, al ejecutar el juego en Play Mode, el comportamiento no era el esperado (por ejemplo, el jugador no se movía bien). Revisar el código resultante línea por línea confirmó la duplicación.

---

### Caso 17 — Revert de un cambio compartido

**1. ¿Por qué no borrar el commit original?**
> Porque el commit ya está compartido y otros compañeros lo tienen. Borrarlo reescribe la historia, obliga a un force push y puede dejar los repositorios de todos desincronizados.

**2. ¿Qué ventaja tiene Revert en una historia compartida?**
> Crea un commit nuevo que deshace el cambio sin tocar el pasado. La historia queda intacta y trazable (se ve qué se hizo y por qué se deshizo), es seguro para el equipo y se puede volver a aplicar si hace falta.

---

### Caso 18 — Recuperar trabajo aparentemente perdido

**1. ¿Qué registra reflog?**
> Registra localmente todos los movimientos de `HEAD` y de las ramas (commits, checkouts, resets, merges), incluyendo commits que ya no son alcanzables desde ninguna rama.

**2. ¿Por qué guardar el hash fue importante?**
> Porque con el hash se puede recuperar el commit exacto (`git branch recuperada <hash>` o `git reset`) sin buscarlo entre muchas entradas del reflog, que además expiran con el tiempo.

---

### Caso 19 — Cherry-pick de una corrección

**1. ¿Por qué no hacer merge?**
> Porque un merge traería todos los commits de la otra rama, incluyendo funciones incompletas o no deseadas. Solo se necesitaba la corrección puntual.

**2. ¿Qué diferencia hay entre cherry-pick y merge?**
> Cherry-pick copia un commit específico a la rama actual (con un hash nuevo). Merge integra la historia completa de una rama dentro de otra.

---

### Caso 20 — Pull Request y entrega final

**1. ¿Qué ventaja tiene revisar antes de integrar?**
> Permite detectar errores, conflictos y malas prácticas antes de que lleguen a la rama compartida. Además, el equipo conoce los cambios y se mejora la calidad del código.

**2. ¿Qué diferencia hay entre Dev y main?**
> `Dev` es la rama de integración donde se juntan y prueban las Features. `main` guarda solo versiones estables y validadas, listas para entregar.

**3. ¿Qué problema evita el Pull Request?**
> Evita que cambios sin revisar o con errores entren directamente a una rama principal, y que se sobrescriba el trabajo de otros. Deja una revisión formal antes de fusionar.

**4. ¿Qué evidencia demuestra mejor que el trabajo fue colaborativo?**
> El historial de commits con distintos autores, las ramas Feature de cada integrante, y los Pull Requests con revisiones y comentarios. Todo junto muestra quién aportó qué y cómo se integró.