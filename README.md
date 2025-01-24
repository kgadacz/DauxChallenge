DauxChallenge - Kevin Gadacz

Consigna:

Armar una solución de Visual Studio con la versión de .net core LTS que prefieras o tengas instalada.
La idea es que sea un proyecto MVC con una vista (por ejemplo: Test/Index) con un pequeño formulario para ingresar Nombre y Apellido.
Se debe validar que los campos estén completos y que ambos campos tengan una longitud mínima de 3 caracteres.
Dentro de otro proyecto (por ejemplo: Services), crear un servicio desde donde se debe llamar vía HTTP al método https://daux.com.ar/api/test-encrypt para obtener el resultado de la solicitud.
Ese valor de respuesta se debe mostrar en la vista del punto anterior.
El formulario debe tener un mínimo de estilos basados en Bootstrap. Nada en particular, sentite libre de hacer lo que consideres mejor.
El servicio anterior recibe y devuelve JSON, y espera un Header Authorization. El resultado será "OK" siempre y cuando el valor del header antes mencionado coincida con la codificación en base64 de la concatenación de nombre y apellido (sin espacios y en ese orden).

Observaciones técnicas:

Se utilizo la version .NET 8 para desarrollar el challenge
