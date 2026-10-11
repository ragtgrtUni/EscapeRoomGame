# Escape Room 3D

Proyecto colaborativo de laboratorio de Git + GitHub + Visual Studio Code + Unity.

## Integrantes
- Aaron (A)
- Grover (B)
- Mariana (C)
- Cristhian (D)
- Alan (E)

## Ramas
- main
- Dev
- Feature_PlayerMovement
- Feature_Interaction
- Feature_Animation
- Feature_Puzzle
- Feature_UI
Flujo: Feature → Dev → main. Guarda el archivo.

## Configuración
- Unity: 6000.5.5f1
- Active Input Handling: Both (los scripts usan Input.GetAxis)
- El proyecto Unity está en la carpeta EscapeRoom/

## Objetivo
Explorar una habitación, resolver un código, abrir un cofre, obtener una llave y abrir la puerta de salida.

## Bitacora

Caso 1:
1 ¿Por qué no conviene subir Library/?
R. Porque es una carpeta que Unity regenera sola en cada PC (caché, importaciones). Pesa mucho, cambia constantemente y causaría conflictos inútiles en cada commit. Lo que hay que compartir es Assets, Packages y ProjectSettings.
2 ¿Qué diferencia existe entre un archivo ignorado y un archivo que ya está siendo seguido por
Git?
R. .gitignore solo evita que Git empiece a seguir archivos nuevos. Si un archivo ya fue commiteado, Git sigue rastreándolo aunque lo añadas al .gitignore.
3 ¿Qué información representa un commit?
R. Una foto del proyecto en un momento dado: los cambios incluidos, el autor, la fecha, un mensaje y un identificador único (hash) que lo enlaza con el commit anterior.
4 ¿Qué función cumple el repositorio remoto?
R. Es la copia compartida (GitHub) donde el equipo sincroniza su trabajo, hace respaldo y revisa cambios con Pull Requests.