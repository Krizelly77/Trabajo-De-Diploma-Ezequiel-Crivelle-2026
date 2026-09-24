Carpeta de proyecto
G00. DESCRIPCIÓN GLOBAL DEL PRODUCTO 
G01. Propósito :

En la empresa Insoft Cybersolutions, ubicada en la ciudad de Buenos Aires, Argentina, se desarrollan soluciones de software para empresas de diferentes sectores. La organización cuenta aproximadamente con 200 empleados, distribuidos entre las áreas de desarrollo, diseño, análisis, soporte, administración y gestión de proyectos
Debido a la cantidad de empleados y a la diversidad de áreas que componen la empresa, se busca fomentar la integración y la participación voluntaria de los trabajadores mediante diferentes actividades internas. Estas actividades pueden ser de carácter deportivo, recreativo, cultural o relacionadas con el aprendizaje y el intercambio de conocimiento

Para organizar estas actividades, la empresa permite que determinados empleados cuenten con permisos para crear y administrar grupos, mientras que el resto de los empleados puede consultar las actividades disponibles y postularse voluntariamente para participar pero actualmente, la empresa no dispone de un sistema específico para administrar este proceso, por lo que la organización de las actividades se realiza mediante diferentes medios de comunicación y herramientas independientes


Actualmente, Insoft Cybersolutions presenta dificultades para organizar y conformar grupos para las actividades internas que realizan sus empleados
Cuando un empleado autorizado desea organizar una actividad, debe comunicarla mediante medios como grupos de mensajería, correos electrónicos u otros canales internos. Los empleados interesados responden utilizando estos mismos medios, lo que provoca que la información de las actividades y de los participantes quede distribuida en diferentes lugares

Esta situación dificulta que el organizador pueda conocer de manera rápida y ordenada quiénes están interesados en participar, quiénes se han postulado y qué características o experiencia posee cada candidato
Además, la empresa no cuenta actualmente con un historial centralizado de participación. Por este motivo, resulta difícil consultar información como la cantidad de actividades en las que participó un empleado, su experiencia en determinadas actividades o las calificaciones obtenidas en participaciones anteriores

Como consecuencia, los empleados autorizados deben invertir tiempo en revisar manualmente las respuestas y organizar la información para conformar los grupos. Esto puede generar pérdida de información, errores en la selección de participantes y dificultades para completar los grupos dentro del tiempo establecido


Para solucionar esta problemática, Insoft Cybersolutions propone desarrollar un sistema interno para la gestión de actividades y conformación de grupos entre empleados

El sistema permitirá que los empleados que posean el permiso correspondiente puedan crear y publicar actividades, indicando sus características, los requisitos necesarios y la cantidad de participantes que se necesitan.
Los demás empleados podrán consultar las actividades disponibles y postularse voluntariamente a aquellas en las que estén interesados.
El sistema centralizará las postulaciones y permitirá al organizador consultar la información de los candidatos, incluyendo su experiencia, historial de participación y calificaciones obtenidas en actividades anteriores. Con esta información, el organizador podrá seleccionar a los participantes que considere más adecuados para conformar el grupo.
Asimismo, el sistema mantendrá un historial de participación y reputación de los empleados, permitiendo utilizar esta información como referencia para futuras actividades.
De esta manera, el proceso que actualmente se realiza mediante diferentes medios de comunicación podrá gestionarse desde una única herramienta interna de la empresa


La implementación del sistema permitirá a Insoft Cybersolutions mejorar la organización de sus actividades internas y facilitar la participación voluntaria de sus empleados
Entre los principales beneficios para la empresa se encuentran:

-Centralizar la información de las actividades, postulaciones y participantes en un único sistema
-Reducir el tiempo que los empleados autorizados dedican a organizar y conformar los grupos
-Facilitar la búsqueda y selección de participantes, proporcionando información sobre su experiencia e historial.
-Disminuir la pérdida de información ocasionada por el uso de diferentes canales de comunicación
-Mantener un historial de participación que pueda ser consultado para futuras actividades
-Facilitar la conformación de grupos, permitiendo conocer la cantidad de participantes aceptados y los cupos disponibles.
-Mejorar la organización de las actividades internas, permitiendo realizar un seguimiento de su estado
-Fomentar la participación voluntaria y la integración entre empleados de diferentes áreas de la empresa

En conclusión, el sistema permitirá que Insoft Cybersolutions reemplace un proceso actualmente disperso y principalmente manual por una gestión centralizada de las actividades internas, facilitando tanto el trabajo de los empleados autorizados para organizarlas como la participación voluntaria del resto de los trabajadores


G02. Descripción funcional del producto y Alcance :

RFN1: Gestión de creación y conformación de grupos:
La gestión de creación y conformación de grupos comprende las operaciones necesarias para que un usuario Organizador pueda crear y publicar una actividad grupal en el Sistema, establecer las características y cantidad de participantes requeridos, recibir postulaciones de otros usuarios, los Participante , consultar la información de los candidatos y seleccionar a los participantes que formarán parte del grupo

Este se limita a la gestión interna de las actividades y la conformación de sus grupos. No contempla la organización de actividades con personas externas a la empresa, la publicación de actividades en Internet ni la comunicación con plataformas o redes sociales externas
Asimismo, la selección de participantes queda bajo responsabilidad del organizador. El sistema proporciona la información necesaria para facilitar la decisión, pero no selecciona automáticamente a los participantes

PN1: 

 Actor que realiza la acción)
 Funcionalidad que realiza el sistema)
 Acción o intervención de una persona)
 Información que interviene en el proceso)

El organizador  decide realizar una actividad que requiere la participación de varias personas y así que desde el menú principal, presiona el botón “Mis Actividades” y allí presiona el botón “ Nueva Actividad “

El Sistema abre el formulario para dar de alta la actividad 

El organizador rellenará los campos del formulario para registrar una nueva actividad, ingresando los datos correspondientes.nombre, descripción, categoría, estado de la actividad(abierto, cerrado,caducado, completado, cancelado), fecha de la actividad, fecha de caducidad, lugar de reunion, Minimo de participantes, Maximo de participantes, nivel requerido(Principiante, Veterano, Profesional, Indistinto) 

El sistema verificará que los datos obligatorios hayan sido completados y que la información ingresada sea válida

El sistema si la información no es válida, marcará el problema con un mensaje para que el Organizador modifique los datos y vuelva a intentar 

El sistema registrará la actividad con un  código de actividad,y devolverá al Organizador a la pantalla de Mis Actividades, mostrando la nueva actividad en las grillas 

Si el estado de la actividad es abierto, Los participantes Interesados podrán visualizar la actividad publicada en la pantalla de Actividades Disponibles y enviar sus postulaciones para formar parte del grupo 

El sistema registrará las postulaciones recibidas asociando cada participante candidato con la actividad correspondiente. usuario, actividad, fecha de postulación, estado de postulación(postulado, aceptado, rechazado, retirado)

El organizador consultará mediante el sistema los candidatos que se hayan postulado y analizará la información disponible de cada uno. nombre, experiencia, historial de participación, calificación(0 a 10), cantidad de actividades realizadas

El organizador seleccionará los candidatos que considere adecuados para completar el grupo

El sistema registrará la selección de los participantes y actualizará el estado de las postulaciones correspondientes. usuario, actividad, estado de postulación( postulado, aceptado, rechazado, retirado)

El sistema verificará si se alcanzó la cantidad de participantes mínima requerida y, en caso afirmativo, avisara que el grupo puede conformarse al organizador 

El organizador , en todo momento puede modificar el estado de la actividad (abierto, cerrado,caducado, completado, cancelado),  decidirá si establecer el grupo como completado

El sistema, en caso de que la cantidad de participantes no se alcanzara para la fecha de caducidad, actualizará el estado de la actividad a caducado 

RFN2: Gestión de participación en grupos:
La gestión de participación en grupos comprende las operaciones necesarias para que los usuarios Participantes puedan consultar actividades disponibles en el Sistema, conocer sus características y postularse para formar parte de aquellas que sean de su interés

Este se limita a la participación voluntaria de empleados de la empresa en actividades internas. No contempla la participación de personas externas a la organización ni la búsqueda de participantes mediante Internet, redes sociales u otras plataformas externas
La postulación realizada por un empleado no implica su aceptación automática en el grupo, ya que la decisión final corresponde al organizador de la actividad


G03. Definiciones, Acrónimos, y Abreviaciones 
Definiciones:

Definición
Descripción
Organizador
Usuario que posee los permisos necesarios para crear y gestionar actividades grupales dentro del sistema
Participante
Usuario que manifiesta interés y se postula para formar parte de una actividad grupal
Actividad
	Evento o propuesta organizada dentro de la empresa que requiere la participación de uno o más empleados
Grupo
Conjunto de participantes seleccionados para participar en una determinada actividad, el organizador inclusive
Candidato
Participante que se ha postulado a una actividad y que puede ser considerado por el organizador para formar parte del grupo
Nivel
Grado de experiencia o conocimiento que posee un Usuario respecto de una determinada actividad. Los niveles contemplados son Principiante, Veterano y Profesional
Historial de participación
Registro de las actividades en las que un Usuario participó anteriormente
Reputación
Información obtenida a partir de la experiencia e historial de participación de un usuario, incluyendo las calificaciones recibidas en actividades anteriores
Cupo
Cantidad de participantes que pueden formar parte de una actividad según los límites establecidos por el organizador
Estado de actividad
Situación en la que se encuentra una actividad durante su ciclo de gestión. Puede ser abierto, cerrado, caducado, completado o cancelado
Estado de postulación
Situación en la que se encuentra la postulación de un empleado. Puede ser interesado, postulado, aceptado o rechazado


Acrónimos:

Acrónimo
Descripción
I.C.S.
Insoft Cybersolutions


Abreviaciones:

Abreviación
Descripción
Act.
Actividad
Part.
Participante
Post.
Postulación
Org.
Organizador
Cant.
Cantidad
Min.
Mínimo
Máx.
Máximo


G04. Descripción de las personas participantes en el desarrollo del sistema de información y los usuarios (Roles)

Personal
Rol (descripción)
Acceso
Victor Organ
Organizador: Usuario que posee los permisos necesarios para crear y gestionar actividades grupales, consultar candidatos y seleccionar participantes
RF1
Patricio Parteli
Participante: Usuario que puede consultar las actividades disponibles y postularse voluntariamente para formar parte de ellas
RF2
Ana Elisa Funes
Analista funcional: se encarga de entender las necesidades del proyecto para transformarlas en requisitos y especificaciones para el desarrollo.
RF1- RF2 
Emanuel Provensal
Analista programador: A partir de los requisitos y del diseño va a desarrollar el software. 
RF1- RF2 
Manrique Gerbasi
Project manager: Se responsabiliza de la gestión del sistema y de diseñarlo. 
RF1- RF2 


G05. Otros Requisitos 

Del Producto: 

Estándares Aplicables:
El sistema deberá seguir los principios establecidos por la norma ISO/IEC 25010, considerando aspectos de calidad como funcionalidad, fiabilidad, usabilidad, eficiencia de desempeño, seguridad y mantenibilidad.
El sistema deberá contar con una interfaz intuitiva y sencilla que permita a los usuarios navegar entre las diferentes funcionalidades sin dificultades.
La información presentada al usuario deberá ser clara y consistente, utilizando una terminología acorde a las definiciones establecidas en el sistema.
El sistema deberá validar los datos ingresados por los usuarios antes de registrarlos, informando los errores mediante mensajes claros.

Requisitos de Sistema:
El sistema deberá ejecutarse en equipos con sistema operativo Windows 10 o superior.
El sistema deberá contar con .NET compatible con la versión utilizada durante el desarrollo de la aplicación.
El equipo deberá contar con un procesador de al menos 2 GHz.
El equipo deberá contar con un mínimo de 4 GB de memoria RAM.
El sistema deberá disponer de espacio suficiente para la instalación de la aplicación y el almacenamiento de los datos.
El sistema deberá utilizar una base de datos SQL Server para almacenar la información correspondiente a usuarios, actividades, postulaciones, participantes e historial de participación.

Requisitos de Desempeño:
El sistema deberá responder a las acciones realizadas por los usuarios en un tiempo razonable, evitando demoras innecesarias.
Las consultas de actividades, postulaciones y participantes deberán mostrar información actualizada almacenada en la base de datos.
Las operaciones de registro, modificación y consulta de información deberán realizarse de manera consistente, evitando la pérdida o duplicación de datos.

Requisitos de Entorno:
El sistema estará destinado al uso interno de los empleados de Insoft Cybersolutions.
El sistema no requerirá comunicación con redes sociales, plataformas externas ni personas ajenas a la empresa.
El sistema deberá permitir el acceso según los permisos correspondientes a cada usuario, diferenciando las funcionalidades disponibles para Organizadores y Participantes.

Requisitos de Documentación:
Se deberá proporcionar un manual de usuario que explique las principales funcionalidades del sistema.
Se deberá proporcionar una guía de instalación de la aplicación.
La documentación deberá utilizar un lenguaje claro y comprensible para los usuarios.


De Documentación: 

Manual de Usuario:
El sistema deberá contar con un manual de usuario de fácil comprensión.
El manual deberá explicar el acceso al sistema y las funcionalidades disponibles según el rol del usuario.
Se deberá explicar el procedimiento para consultar actividades y realizar postulaciones.
Se deberá explicar el procedimiento para crear y gestionar actividades para los usuarios con rol de Organizador.
Se deberá explicar el procedimiento para consultar candidatos y seleccionar participantes.
El manual deberá incluir explicaciones sobre los diferentes estados de las actividades y postulaciones.


Ayuda en Línea:
El sistema deberá proporcionar mensajes de ayuda y orientación durante la utilización de sus funcionalidades.
Los mensajes de error deberán indicar de manera clara el problema detectado y, cuando sea posible, la forma de solucionarlo.
Se deberá proporcionar un medio de contacto interno para comunicar problemas o solicitar asistencia relacionada con el sistema.


Guía de Instalación, Configuración y Fichero Léame:
Se deberá proporcionar una guía con los pasos necesarios para instalar la aplicación en un equipo compatible.
La guía deberá indicar los requisitos mínimos necesarios para ejecutar el sistema.
Se deberán especificar los pasos necesarios para configurar la conexión con la base de datos SQL Server.
Se deberá incluir información sobre la configuración inicial requerida para comenzar a utilizar el sistema.
El fichero README deberá contener una descripción general del sistema, los requisitos necesarios, instrucciones básicas de instalación y configuración, y cualquier consideración importante para su utilización.

G06. Diagrama de clases parcial de todos los módulos implementado 
G07. Modelo de datos parcial de todos los módulos implementados 

N00. PROCESOS DE NEGOCIO 
N01. Especificación funcional por proceso de negocio 
N02. Especificaciones de Casos de Uso 

T00. DOCUMENTOS DE ASPECTOS TÉCNICOS QUE PROVEE EL SISTEMA DE INFORMACIÓN
T01. Arquitectura Base 
T02. Gestión de Log In / Log Out del Sistema 
T03. Gestión de Encriptado 
T04. Gestión de Perfiles de Usuario 
T05. Gestión de Múltiples Idiomas 
T06. Gestión de Bitácora y Control de cambios 
T06a. Gestión de bitácora 
T06b. Control de cambios 
T07. Gestión de Backup 
T08. Gestión de Dígitos Verificadores 

A00. CARACTERÍSTICAS Y FUNCIONALIDADES ADICIONALES 
A01. Instalador 
A02. Informe y exportación en PDF
A03. Serialización

D00. DOCUMENTACIÓN ADICIONAL
D01. Manual de Instalación
D02. Ayuda en línea
D03. Material de apoyo al usuario final
