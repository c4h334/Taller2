# Análisis de Capas de Arquitectura del Backend

## Taller 2 | IF0009 - Desarrollo de Software IV

### 1. Domain
Es el núcleo de la aplicación. Contiene las entidades principales (como `User` o `Product`) que representan los conceptos del negocio y su estructura de datos fundamental. Esta capa es completamente independiente y no debe tener referencias a bases de datos, APIs o frameworks externos.

### 2. Infrastructure
Se encarga de la comunicación con el mundo exterior, principalmente la base de datos.
* **DbContext:** Gestiona la sesión con la base de datos utilizando herramientas como Entity Framework Core, mapeando las entidades a tablas.
* **Repositories:** Abstraen el acceso a los datos. Contienen las consultas directas (ej. `ToListAsync()`) para que el resto de la aplicación no tenga que lidiar con sentencias SQL o configuraciones de Entity Framework.

### 3. DomainService
Contiene la lógica y las reglas de negocio de la aplicación. Si una operación requiere validaciones complejas o involucra múltiples entidades, esta lógica reside aquí. Se comunica con los repositorios para obtener o guardar datos una vez aplicadas las reglas.

### 4. Facade
Actúa como un orquestador o coordinador. Su objetivo es simplificar el acceso a sistemas complejos. Agrupa llamadas a uno o varios servicios de dominio, procesa la información y la convierte en objetos de transporte (DTOs) para entregar una respuesta lista y digerida a las capas superiores.

### 5. API Controller
Es el punto de entrada principal para el cliente web o móvil. Recibe las peticiones HTTP (GET, POST, etc.), valida parámetros básicos de entrada, delega el procesamiento a la Facade, y devuelve los códigos de estado HTTP correspondientes (ej. `200 OK`, `404 Not Found`) junto con la respuesta.

### 6. DTO (Data Transfer Object)
Son objetos planos que no contienen lógica de negocio ni comportamiento. Su único propósito es transportar datos entre las diferentes capas del sistema, aislando y protegiendo a las entidades de dominio para que no sean expuestas directamente o alteradas desde el exterior.

* **RequestModel:** Un tipo de objeto diseñado exclusivamente para capturar y estructurar los datos entrantes que el cliente envía hacia la API (por ejemplo, el JSON enviado para crear un usuario).
* **ResponseModel:** Un tipo de objeto diseñado para dar formato final a los datos que la API devuelve al cliente, asegurando que solo se exponga la información requerida de manera segura (evitando exponer contraseñas u otros datos sensibles).

### 7. Mappers
Son clases utilitarias encargadas de transformar o "mapear" propiedades de un tipo de objeto a otro. Su función principal es trasladar valores, por ejemplo, tomando un `UserDto` que viene del Facade y convirtiéndolo en un `UserResponseModel` en la capa del controlador.