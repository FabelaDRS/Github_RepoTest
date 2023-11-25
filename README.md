# FabelaExam


Parte 1: Backend (.NET Core C# 7 o Posterior)

1. Ejecutar los Scripts en el orden de cada archivo de la ruta (https://github.com/FabelaDRS/Github_RepoTest/tree/master/DataBase).
2. Descargar y abrir el proyecto en Visual Studio (https://github.com/FabelaDRS/Github_RepoTest/tree/master/FabelaExam.Api)
3. Cambiar cadena de conexion [Nombre del servidor de BD] del archivo  appsettings.json, que esta dentro del proyecto FabelaExam.Api
4. Agregar el archivo collecion [FabelaTest.postman_collection.json] al postman en la opcion de Import.
5. Agregar el archivo Environment [FabelaExam.postman_environment.json] al postman en la opcion de Import.
6. Ejecutar el proyecto, si llega a marcar error, click derecho y buscar la opcion de [Restore NuGet Packages]
7. Volver a compilar y ejecutar.

Bonus:
Nota: Actualmente los metodos del controlador de usuario requieren Token por lo que se debera generar el Token siguiendo estos pasos:
1. Ejecutar el metodo en postman => api/v1/Authorizer/auth
   El request lleva usuario por defaul, que fue creado previamente al ejecutar los scripts de BD.
2. Ya que se aya importado los archivos en Postman, cuando desee consumir un metodo desde postman, no olvide seleccionar el Environment [FabelaExam] en postman   
3. Una vez que tenga el token, puede ejecutar los siguientes metodos:
   [Post] api/v1/User
   [Put] api/v1/User
   [Get] api/v1/User
   [Get] api/v1/User/user/7
   [Delete] api/v1/User?userId=2
 
Nota: Si no desea consumir los  metodos con autenticacion, en el codigo del controllador de usuario, commente la linea [ [Authorize] ] y 
vueva a ejecutar el api. 