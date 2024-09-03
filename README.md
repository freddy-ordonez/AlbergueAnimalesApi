# **Administración de Albergue de Animales Rescatados**

Este proyecto implementa un conjunto de endpoints para administrar un albergue de animales rescatados, enfocado en la gestión de perros y gatos. La API proporciona funcionalidades para llevar un control integral de los animales, los voluntarios que trabajan en el albergue, las personas que adoptan, y el seguimiento de las adopciones.

## **Funcionalidades**

  ### **Gestión de Animales Rescatados:**

  Registro de perros y gatos rescatados en el albergue.  
  Actualización del estado de los animales (adoptado, en adopción, en espera de adopción, etc.).  
  Búsqueda y listado de animales disponibles para adopción.
  
  ### **Gestión de Voluntarios:**
  
  Registro y administración de voluntarios que trabajan en el albergue.  
  Información almacenada: nombre, apellido, correo electrónico, contraseña, y estado (activo, inactivo, etc.).  
  Capacidad para activar o desactivar voluntarios según su disponibilidad.
  
  ### **Gestión de Adoptantes:**
  
  Registro y administración de personas interesadas en adoptar animales.  
  Información almacenada: nombre, apellido, correo electrónico, contraseña, y estado (activo, inactivo, etc.).  
  Capacidad para activar o desactivar adoptantes según el estado del proceso de adopción.
  
  ### **Gestión de Adopciones:**
  
  Registro de las adopciones realizadas, con detalles sobre la fecha de entrega del animal.  
  Asociación de la adopción con el animal, el voluntario que gestionó la adopción, y la persona que adoptó.  
  Seguimiento del estado de la adopción (finalizado, en proceso, etc.).
  
## **Tecnologías Utilizadas**
Lenguaje de Programación: C#  
Framework: ASP.NET Core  
Base de Datos: Microsoft SQLServer  
ORM: Entity Framework  
Autenticación y Seguridad: JWT
