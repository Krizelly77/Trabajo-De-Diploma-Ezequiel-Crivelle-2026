SAPA — Sistema para Armar y Participar en Actividades
📌 Descripción
SAPA (Sistema para Armar y Participar en Actividades) es una aplicación de escritorio desarrollada para gestionar actividades y facilitar la interacción entre organizadores que buscan participantes y personas interesadas en participar de dichas actividades.

El sistema busca centralizar la gestión de las actividades, permitiendo administrar la información relacionada con ellas y sus participantes.

El proyecto fue desarrollado utilizando C#, Windows Forms y .NET Framework, siguiendo una arquitectura de cinco capas para separar las responsabilidades de la aplicación.

🎯 Objetivo
El objetivo principal de SAPA es proporcionar una herramienta que permita gestionar de manera organizada las actividades ofrecidas por distintos organizadores y facilitar la participación de personas interesadas en ellas.

La aplicación busca separar las distintas responsabilidades del sistema para favorecer su mantenimiento, organización y escalabilidad.

🏗️ Arquitectura
El proyecto utiliza una arquitectura de 5 capas, compuesta por:

UI (User Interface): encargada de la interacción con el usuario y la presentación de la información.
APP / BLL (Application / Business Logic Layer): contiene la lógica de negocio y las reglas que debe cumplir el sistema.
DAL (Data Access Layer): responsable de la comunicación y acceso a la base de datos.
BE (Business Entities / Dominio): contiene las entidades y objetos que representan los elementos del dominio de la aplicación.
SL (Services Layer): contiene los servicios utilizados por la aplicación.
La separación en capas permite mantener las responsabilidades organizadas y reducir el acoplamiento entre los distintos componentes del sistema.

Diagrama de arquitectura
┌─────────────────────────────┐
│             UI              │
│       Windows Forms         │
│     Interfaz de usuario     │
└──────────────┬──────────────┘
               │
               ▼
┌─────────────────────────────┐
│          APP / BLL          │
│       Lógica de negocio     │
└──────────────┬──────────────┘
               │
               ▼
┌─────────────────────────────┐
│             DAL             │
│       Acceso a datos        │
└──────────────┬──────────────┘
               │
               ▼
┌─────────────────────────────┐
│         SQL Server          │
│          Base de datos      │
└─────────────────────────────┘

        ┌─────────────────┐
        │       BE        │
        │     Dominio     │
        │    Entidades    │
        └─────────────────┘

        ┌─────────────────┐
        │       SL        │
        │    Servicios    │
        └─────────────────┘

El diagrama representa de manera general la separación de responsabilidades del sistema. Las dependencias concretas entre proyectos pueden detallarse y ajustarse según la implementación final.

🛠️ Tecnologías utilizadas
Lenguaje: C#
Framework: .NET Framework
Interfaz gráfica: Windows Forms
IDE: Visual Studio 2022
Base de datos: SQL Server
Gestión de base de datos: SQL Server Management Studio 20
📂 Estructura del proyecto
La solución se encuentra dividida en diferentes proyectos, correspondientes a las capas de la arquitectura:

SAPA
│
├── UI
│   └── Interfaz gráfica y formularios
│
├── APP / BLL
│   └── Lógica de negocio
│
├── DAL
│   └── Acceso a datos
│
├── BE
│   └── Entidades del dominio
│
└── SL
    └── Servicios

Esta organización permite mantener cada componente del sistema dentro de una responsabilidad específica.

🗄️ Base de datos
SAPA utiliza SQL Server como sistema gestor de base de datos.

La base de datos almacena la información necesaria para el funcionamiento de la aplicación, incluyendo los datos relacionados con las actividades, usuarios y participantes.

Esta sección será ampliada posteriormente con el modelo de datos, las principales tablas y las instrucciones necesarias para crear y configurar la base de datos.

⚙️ Requisitos
Para ejecutar el proyecto se requiere:

Windows
Visual Studio 2022
.NET Framework
SQL Server
SQL Server Management Studio 20
Los requisitos específicos de versiones y configuración se detallarán en una versión posterior del proyecto.

🚀 Instalación y ejecución
Actualmente, para ejecutar el proyecto se debe:

Clonar o descargar el repositorio.
Abrir la solución de SAPA utilizando Visual Studio 2022.
Configurar la conexión con la base de datos de SQL Server.
Verificar que la base de datos se encuentre disponible.
Compilar la solución.
Ejecutar el proyecto correspondiente a la interfaz de usuario.
Las instrucciones detalladas para configurar la base de datos y la cadena de conexión serán incorporadas posteriormente.

📋 Estado del proyecto
🚧 En desarrollo

El proyecto se encuentra actualmente en desarrollo. Algunas funcionalidades y aspectos de la documentación pueden encontrarse sujetos a cambios.

👨‍💻 Autor
Krizelly77

Proyecto desarrollado como parte de [materia / curso / institución].

📄 Licencia
Este proyecto fue desarrollado con fines académicos.

La información relacionada con la licencia y los permisos de uso podrá ser incorporada posteriormente.