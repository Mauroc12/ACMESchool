HORAS DEDICADAS: 25

El proyecto consiste en una solucion usando Clean Arhitecture con patron CQRS, se divide en 4 capas:
API que es una API RESTFull para el ingreso de informacion a la aplicacion 
Aplication es la capa que se encarga de realizar la logica de los casos de uso 
Domain contiene todas las entidades de dominio y su logica 
Infraestrucutra contempla la comunicacion con servicios de terceros (External Services) y la persistencia de datos (Persistencies), en este caso use SQL Server con entity Core 

Tambien se agregaron proyectos de test correspondientes a cada capa



Cosas que me hubiera gustado hacer pero no las hice por cuestion de tiempo:

-Crear los dominios con enfoque DDD   
-Abstraer las entidades de dominio agregando interfaces   
-Crear unit test de toda las clases  
-Agregar mas manejo de excepciones  
-Agregar mas validaciones al modelo   
-Crear un generic repository para no repetir tanto codigo  
-Agregar autenticacion al API   
-Manejar mejor los codigos de respuestas en la capa API 

 

