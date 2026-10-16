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
| Escena principal | `Assets/00_Scenes/MainScene.unity` |
| Versión entregada | `main` (`5df30aa`) · etiqueta `v1.0` |

### Cómo abrir el proyecto

1. Clonar el repositorio y abrir la carpeta `EscapeRoom/` desde Unity Hub con Unity 6000.5.5f1.
2. Abrir `Assets/00_Scenes/MainScene.unity` y darle Play.
3. Controles: **WASD** para moverse y **E** para interactuar. Hay que tomar la llave y luego ir a la puerta.

---

## 📓 Bitácora

Formato de la sección 6 de la guía. El detalle de cada caso, con capturas, está en el PDF de evidencias.

| Caso | Problema | ¿Provocado? | ¿Resuelto? | Evidencia | Responsables |
|:----:|----------|:-----------:|:----------:|-----------|--------------|
| 01 | Más de 10 000 cambios sin `.gitignore`; carpetas vacías no se subían | Sí | Sí | `55a9f81`, `f594348` | Aaron |
| 02 | Crear Dev y Features; `Feature_UI` nació de main | Sí | Sí | `c506846` | Cristhian |
| 03 | Commit en la rama equivocada (Dev) | Sí | Sí | `8927097`, `7b5e24c` | Aaron |
| 04 | Checkout bloqueado por cambios locales | Sí | Sí, con Stash | `13bdea9` | Grover |
| 05 | Push rechazado; conflicto en README | Sí | Sí | `f002d29` | Alan, Cristhian |
| 06 | Conflicto en `Update()` de PlayerController | Sí | Sí | `464dccf` | Mariana, Grover, Cristhian |
| 07 | Cambios simultáneos en `Player.prefab` | Sí | Sí | `40f8e5b` | Mariana, Cristhian, Alan, Grover |
| 08 | Conflicto en la escena (Chest y Door) | Sí | Sí | `40a5755` | Grover, Alan, Mariana |
| 09 | Delete/modify de `OldDoorController` | Sí | Sí, se elimina | `770fb35` | Mariana, Cristhian, Alan |
| 10 | Add/add de `PuzzleManager.cs` | Sí | Sí | `927cb81` | Cristhian, Mariana |
| 11 | Conflicto en ProjectSettings | Sí | Sí | `df7534e` | Alan, Mariana, Grover |
| 12 | Commit con un archivo de prueba | Sí | Sí, con Amend | `c31f007` | Aaron |
| 13 | `TempLaboratorio/` seguido por Git | Sí | Sí | `610211e` | Aaron |
| 14 | `Feature_Puzzle` desactualizada | Sí | Sí | `c56a518` | Cristhian |
| 15 | Tres archivos en conflicto | Sí | Sí | `a32ab4f` | Grover, Mariana, Alan |
| 16 | Accept Both duplica `Initialize()` | Sí | Sí | `385af7b` | Alan, Grover, Mariana |
| 17 | La puerta no abre con la llave | Sí | Sí, con Revert | `c2a67ac` | Alan, Grover |
| 18 | Commit perdido con `reset --hard` | Sí | Sí, con reflog | `dc30ddb` | Aaron |
| 19 | Dev necesita solo una corrección | Sí | Sí, con Cherry Pick | `f961181` | Aaron |
| 20 | La revisión del PR pidió cambios | Sí | Sí | `85eac46`, `5df30aa` | Cristhian, Grover, Alan |
| R | La escena de Dev no tenía Player | No | Sí | `8351df9` | Alan |

### Preguntas de reflexión

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
> No. Git solo ve que un lado borró y otro modificó. Decidir si el archivo sigue siendo necesario lo hace el equipo.

**2. ¿Qué riesgo hay en conservar un archivo solo para evitar el conflicto?**
> Queda código muerto o duplicado. En nuestro caso, `OldDoorController` incluso rompía la compilación por definir otra clase `DoorController`.

---

### Caso 10 — Dos alumnos crean PuzzleManager.cs

**1. ¿Por qué "el último commit gana" no es una regla válida?**
> Porque el orden de llegada no dice cuál código es mejor. Se perdería trabajo útil del otro integrante.

**2. ¿Qué principio de diseño debe guiar la integración?**
> Que quede una sola clase con una responsabilidad clara, que cubra lo que necesitaban los dos y que el resto del juego la pueda usar.

---

### Caso 11 — Cambios en ProjectSettings

**1. ¿Por qué no se debe aceptar ProjectSettings a ciegas?**
> Porque un solo archivo guarda decenas de configuraciones. Aceptar un lado entero puede revertir sin querer otra configuración del proyecto.

**2. ¿Qué configuración consideras especialmente sensible?**
> La versión del editor, el pipeline de render, la plataforma de destino y las escenas del Build Settings.

---

### Caso 12 — Commit incorrecto

**1. ¿Cuándo conviene Amend?**
> Solo cuando el commit todavía no se subió. Sirve para corregir el último commit sin dejar uno extra en la historia.

**2. ¿Por qué reescribir historia compartida puede afectar a otros?**
> El Amend cambia el hash. Si otro ya tenía el commit viejo, su historia y la del remoto ya no coinciden y obligan a un Force Push.

---

### Caso 13 — Archivo que debía estar en .gitignore

**1. ¿Por qué `.gitignore` no borró el historial?**
> El `.gitignore` solo afecta a archivos que todavía no se siguen. Lo que ya está en commits anteriores se queda en la historia.

**2. ¿Qué diferencia hay entre Working Tree e Index?**
> El Working Tree son los archivos en disco. El Index (stage) es lo que va a entrar en el próximo commit. `git rm --cached` lo saca del Index sin borrarlo del disco.

---

### Caso 14 — Feature desactualizada respecto a Dev

**1. ¿Por qué conviene resolver el conflicto en la Feature?**
> Así Dev nunca queda roto. Cuando la Feature vuelve a Dev ya está al día y el merge es limpio.

**2. ¿Qué diferencia conceptual existe entre merge y rebase?**
> Merge une dos historias y deja un commit de merge que lo registra. Rebase reescribe los commits de la Feature como si hubieran nacido del Dev actual; por eso no se usa en ramas compartidas.

---

### Caso 15 — Conflicto en varios archivos

**1. ¿Cómo organizaste la resolución?**
> Primero el script, porque es texto legible; después el Prefab y al final la escena. Cada uno se guardó y se puso en stage antes de pasar al siguiente.

**2. ¿Por qué conviene validar Unity después de resolver todos?**
> Porque los tres archivos dependen entre sí. Probar con uno solo resuelto da un resultado que no es el final.

---

### Caso 16 — Accept Both rompe el juego

**1. ¿Por qué Accept Both no garantiza corrección?**
> Solo pega los dos bloques uno debajo del otro. Si los dos hacían lo mismo, el resultado lo hace dos veces.

**2. ¿Qué pruebas detectaron el problema?**
> Darle Play en Unity y leer la Console: el contador de `Initialize()` mostró "Veces: 1" y "Veces: 2".

---

### Caso 17 — Revert de un cambio compartido

**1. ¿Por qué no borrar el commit original?**
> Ya estaba en GitHub y otros lo tenían. Borrarlo obliga a reescribir historia compartida y a usar Force Push.

**2. ¿Qué ventaja tiene Revert en una historia compartida?**
> Deshace el efecto con un commit nuevo. Nadie pierde nada, todos hacen Pull normal y queda registrado qué se deshizo.

---

### Caso 18 — Recuperar trabajo aparentemente perdido

**1. ¿Qué registra reflog?**
> Cada movimiento de HEAD en el repositorio local: commits, checkouts, resets y merges. Por eso muestra commits que ninguna rama apunta ya.

**2. ¿Por qué guardar el hash fue importante?**
> Porque permitió identificar sin dudas el commit correcto (`dc30ddb`) entre todas las entradas del reflog.

---

### Caso 19 — Cherry-pick de una corrección

**1. ¿Por qué no hacer merge?**
> Un merge habría llevado a Dev los tres commits de la Feature, incluido el temporizador, que todavía no estaba listo.

**2. ¿Qué diferencia hay entre cherry-pick y merge?**
> Merge trae toda la historia de una rama. Cherry-pick copia un solo commit como uno nuevo, con distinto hash.

---

### Caso 20 — Pull Request y entrega final

**1. ¿Qué ventaja tiene revisar antes de integrar?**
> Otra persona ve el cambio antes de que llegue a Dev. En el PR #2 la revisión pidió cambios y se corrigieron en la misma rama, sin romper Dev.

**2. ¿Qué diferencia hay entre Dev y main?**
> Dev es donde se integra y se prueba. `main` solo recibe versiones revisadas y estables, como la `v1.0`.

**3. ¿Qué problema evita el Pull Request?**
> Evita que se integre código sin revisión o sin probar, y deja registro de quién aprobó y qué se discutió.

**4. ¿Qué evidencia demuestra mejor que el trabajo fue colaborativo?**
> El historial: commits de los cinco integrantes, merges hechos por distintas personas y el PR revisado por otro integrante.

---

## 🧩 Conflictos más difíciles

**Caso 16 · Accept Both.** El archivo quedó sin marcadores y compiló, así que parecía resuelto. El error solo apareció al darle Play: `Initialize()` se ejecutaba dos veces. Se dejó una sola llamada en `Start()`. Resolver el texto no es lo mismo que tener el juego funcionando.

**Casos 08 y 15 · Escena y varios archivos.** La escena y el Prefab son YAML generado por Unity, difíciles de leer en el Merge Editor. En el 15 había tres archivos dependientes entre sí y hubo que resolverlos todos antes de probar. En esta etapa se descubrió que la escena de Dev no tenía al Player, lo que llevó a la Reparación (`8351df9`).

**Caso 09 · Delete/modify.** Git no podía decidir si `OldDoorController` debía existir. La decisión salió de abrir Unity, ver el error por la clase duplicada y confirmar que nadie usaba el archivo.

## 📝 Decisiones del equipo

- El campo Animator de la puerta y el cofre queda vacío a propósito: el código usa `if (animator != null)` y la guía no pide animaciones.
- Algunos mensajes de commit tienen errores de tipeo (`feet: add player movementt`, `docss`, `x`). No se reescribieron porque ya estaban en GitHub y eso exigía Force Push.

