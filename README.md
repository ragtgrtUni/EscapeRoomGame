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
| 04 | Cambios locales y Stash | C — Mariana | ⬜ |
| 05 | Push rechazado porque Dev avanzó | A — Aaron | ⬜ |
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

<!-- ZONA 2: DETALLE POR CASO. Copia el bloque de abajo para cada caso nuevo. -->

### Caso 01 — Crear el repositorio y primer commit

**Evidencia:** <!-- ![Captura 01](evidencias/caso-01/captura.png) -->

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

**Evidencia:** <!-- ![Captura 02](evidencias/caso-02/captura.png) -->

**1. ¿Desde qué commit nació tu Feature?**
> Mi rama `Feature_Puzzle` nació desde el commit en el que agregué la línea del flujo de trabajo en el README.md (`docs: add branch workflow`), creado justo después de crear la rama `Dev`.

**2. ¿Por qué una Feature no debería nacer directamente de `main` en este laboratorio?**
> Porque en la estrategia de ramas de este proyecto, `main` se reserva para versiones estables y entregas finales validadas mediante Pull Requests. Si una Feature nace de `main`, se salta el entorno de integración intermedio (`Dev`), lo que rompe el flujo de colaboración, provoca mezclas prematuras de código sin probar y dificulta detectar errores antes de llegar a `main`.

---

### Caso 03 — Commit en la rama equivocada

**Evidencia:** <!-- ![Captura 03](evidencias/caso-03/captura.png) -->

**1. ¿Qué significa que una rama apunte a un commit?**
> Una rama es solo una etiqueta que señala un commit. Al hacer un commit nuevo, la etiqueta de la rama actual se mueve a él. Por eso se puede crear otra rama en ese mismo punto y conservar el trabajo.

**2. ¿Por qué no se debe copiar manualmente el archivo a otra rama y borrar el original como solución de Git?**
> Porque se pierde la historia (autor, mensaje, fecha), se pueden perder cambios y no se corrige el error en Git: el commit equivocado sigue en `Dev`. Lo correcto es mover la referencia o hacer Revert.

---

### Caso 04 — Cambios locales y Stash

**Evidencia:** <!-- ![Captura 04](evidencias/caso-04/captura.png) -->

**1. ¿Qué problema resuelve Stash?**
> Resuelve la necesidad de guardar temporalmente cambios de código a medio terminar para limpiar tu espacio de trabajo sin perder nada, permitiéndote cambiar de rama rápidamente para solucionar una urgencia o actualizar tu proyecto.

**2. ¿Por qué Stash no reemplaza a Commit?**
> Porque el stash es solo un borrador local y temporal que no guarda un historial permanente ni se puede compartir en GitHub, mientras que un commit crea un punto de control definitivo e inmutable en el historial que se sincroniza con todo el equipo.

**3. ¿Qué puede ocurrir al aplicar un stash sobre una rama que cambió?**
> Pueden generarse conflictos de fusión (merge conflicts) si el código que guardaste en el stash intenta modificar las mismas líneas de un archivo que fueron cambiadas en la rama mientras estabas ausente, obligándote a resolver las diferencias a mano.
