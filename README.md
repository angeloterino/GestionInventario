# GestionInventario
Prueba de Global Systems
Estructura de la aplicación:

El diseño de la aplicación se ha realizado por capas, con el objeto de facilitar su mantenimiento y el despliegue de nuevas funcionalidades.

Dicho diseño se puede resumir de la siguiente forma:

	- Capa de cliente: GestionInventario.UI
	En esta capa se despliega toda la parte visual de la aplicación. Para ello se utiliza la tecnología MVC de .NET con algunas peculiaridades para asemejar la aplicación a una aplicación de tipo SPA (Single Page Application), que le otorga características de fluidez y dinamismo propias de dicha arquitectura.
	Por regla general, este tipo de aplicaciones establece una comunicación entre la parte cliente y el servidor mediante tecnología REST basada en JSON, pero para el desarrollo de la prueba he optado por realizar llamadas de tipo HTTP con respuesta HTML mezcladas con llamadas REST y JSON, para poder acelerar el proceso de creación de la misma.
	- Capa de servicios: GestionInventario.Services
	En esta capa se desarrollan los métodos necesarios para establecer la comunicación entre la parte visual y la lógica de negocio de la aplicación. En este caso, para abreviar el desarrollo, la lógica de negocio se ha integrado en esta capa.
	- Capa de manejo de datos: GestionInventario.Data
	Esta capa es la encargada de gestionar todo el acceso a datos por parte de la aplicación, lo que permite centralizar el desarrollo de la conexión con los datos. Aquí podríamos crear una serie de clases a modo de repositorio de datos que permitan fácilmente tratar los datos como objetos, e implementar las funcionalidades CRUD (Create, Read, Update and Delete) que se necesitan a la hora de trabajar con bases de datos. Nuevamente, para simplificar este desarrollo, se ha optado por no crear una clase exclusiva de repositorio para el modelo utilizado.
	- Capa de modelo de datos: GestionInventario.Models
	En esta capa se despliegan los modelos necesarios tanto para tratar los datos como para visualizar los mismos. Al desplegar esta capa en un proyecto independiente, se puede compartir entre los distintos proyectos sin necesidad de compartir partes más conflictivas, como podría ser la capa de datos.

Para la realización de la prueba se han simplificado algunas de estas características. Las llamadas dinámicas al servidor se han resuelto con vistas parciales, a fin de agilizar el desarrollo, y se ha utilizado jQuery siempre que ha sido necesario por el mismo motivo.
