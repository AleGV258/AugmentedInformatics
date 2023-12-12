# Aplicación Móvil de Realidad Aumentada para visualizar Profesores y Salones 📱

_La aplicación móvil con la funcionalidad de realidad aumentada, sirve y ayuda a los alumnos de la facultad de informática a visualizar datos de profesores y salones, con esto en mente se facilita su reconocimiento alrededor de las instalaciones de la facultad_

## Comenzando 🚀

_Para obtener el proyecto en local y que se permita la edición, mejora e innovación, se debe clonar en la máquina local para poder acceder a estos archivos, este proyecto fue realizado con el apoyo de ```Centro de Desarrollo```_

Mira **Despliegue** para conocer como desplegar el proyecto.

### Pre-requisitos ✏️

_Antes de inicializar el proyecto y ejecutarlo, debes tener en cuenta los siguientes puntos_

- La aplicación móvil de realidad aumentada hace uso de dos ```API```, la primera para el inicio de sesión y la segunda para recabar los datos de los profesores y salones

- Al no contar con estas ```API``` debido a sus actualizaciones, el inicio de sesión para la aplicación móvil se encuentra sin ningún dato, se puede acceder sin ingresar nada

- Al no contar con estas ```API``` debido a sus actualizaciones, la información desplegada en los paneles de realidad aumentada e interfaces son recabados de una ```API``` externa para llevar a cabo las pruebas

## Construido con 🛠️

_Herramientas, lenguajes de programación y demás recursos usados para su construcción_

* [Unity Hub](https://unity.com/download) – Aplicación para centralizar y descargar las versiones de ```Unity```
* [Unity](https://unity.com/download) - (2021.3.24f1 o superior) Motor gráfico de desarrollo para aplicaciones 2D o 3D
* [Vuforia](https://developer.vuforia.com/downloads/sdk) - (10.13 o superior) Plataforma de desarrollo de aplicaciones de realidad aumentad y realidad mixta
* [Blender](https://www.blender.org/download/) - Aplicación para la construcción de modelos 3D
* [Illustrator](https://www.adobe.com/products/illustrator/free-trial-download.html) - Aplicación de edición de imágenes vectoriales para generar y editar los targets 

## Despliegue 📦

_Se demuestra cómo se debe desplegar el proyecto para su correcto funcionamiento_

1. Descarga o clona el proyecto localmente

2. Una vez instalado ```Unity Hub``` se debe configurar tu cuenta para generar una licencia de uso personal

3. Una vez teniendo esta licencia en ```Unity Hub``` se debe instalar la versión recomendada de ```Unity``` aquí establecida, con soporte para ```Windows```, ```WebGL```, ```iOS``` y ```Android```, y con soporte para ```Visual Studio``` y ```C#```

4. Con esto listo, se debe crear un nuevo proyecto en 3D desde 0 y esperar a que abra, y muestre la escena principal vacía

5. Una vez generado el proyecto, se cierra, y posteriormente se debe navegar hasta la del directorio del proyecto recién creado, una vez ahí, se elimina la carpeta ```Assets```, una vez eliminada se sustituye con la carpeta ```Assets``` clonada del repositorio

NOTA: Se debe eliminar la carpeta ```Assets``` y no solo sustituir, ya que puede generar errores

6. Una vez puesta la nueva carpeta de ```Assets``` en el proyecto, se debe volver a iniciar para que cargue todos los recursos del proyecto

NOTA: Si saltan avisos de incompatibilidad o de que se debe abrir en modo seguro, se recomienda saltar estas notificaciones

7. Se debe descargar el ```SDK Vuforia``` compatible para ```Unity``` y ejecutarlo con el IDE abierto de ```Unity``` con el proyecto, dándole a instalar

8. Dentro del portal de desarrollo de ```Vuforia``` se debe generar una licencia en el ```License Manager``` y copiar esta licencia dentro de la opción ```Open Vuforia Engine Configuration``` en la cámara ```ARCamera``` dentro del IDE de Unity, y esta licencia pegarla en el apartado de ```App License Key```

9. Una vez abierto el proyecto con todos los recursos de la aplicación, se puede dar al botón de ```Play``` en el IDE de ```Unity``` para empezar a interactuar y llevar a cabo su funcionalidad

### Notas Adicionales 📋

_Se colocan notas que son de utilidad para la manipulación del proyecto y/o sistema_

- Para poder visualizar las interfaces de realidad aumentada se debe escanear con la cámara del dispositivo móvil los ```ImageTargets``` para que se sobrepongan los paneles

- En el directorio ```Resources/``` se encuentran archivos adicionales para la modificación del proyecto

## Recursos Adicionales 💥

_Documentos, enlaces y más información referente a la construcción del proyecto, sistema o aplicación_

* [Figma](https://www.figma.com/file/eB1sM2WRFoxO0z3lxOYNyb/Realidad-Aumentada?type=design&node-id=0%3A1&mode=design&t=hZYHKyo8hOAdiyFS-1) – Modelos y prototipos creados para la aplicación móvil
* [LucidChart](https://lucid.app/lucidchart/0453420d-8d5e-4ae6-b2f1-2ab4bc83cbf4/edit?invitationId=inv_71370062-0dd9-4cb7-910d-233bd9d23182) – Diagrama de uso de como debe ser la funcionalidad de la API
* [Drive](https://drive.google.com/drive/folders/1sgZC_MqbQFH97jfCJC7TkOpRbCAq_Utu?usp=sharing) – Releases de la aplicación, pruebas de funcionamiento
* [Drive](https://drive.google.com/drive/folders/1xn5PaztmI_Nfc6jI31nC7FH2vm3DWsFv?usp=sharing) – Copias de seguridad del proyecto, en versiones estables
* [Docx](https://1drv.ms/w/s!Asco3l25FKG-gQMORbyjQJv8RUwN?e=uaIdaX) – Manual técnico de la aplicación móvil
* [Docx](https://1drv.ms/w/s!Asco3l25FKG-gVPDCsqAjQ-eDUW3?e=qXdLXP) – Manual de usuario de la aplicación móvil

## Autores ✒️

_Las personas implicadas en el desarrollo del proyecto_

* **Michell García** - [AleGV258](https://github.com/AleGV258)
* **Daniel León** - [DanielLeonP](https://github.com/DanielLeonP)
* **Carlos Mendieta** - [CarlosAbrahamMR](https://github.com/CarlosAbrahamMR)
* **Juan Almaguer** - [JCAlmaguer](https://github.com/JCAlmaguer)