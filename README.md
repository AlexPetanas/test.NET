# test.NET
un test realizado en .net

basicamente es una api rest con .net 8 que tiene los suiguientes endpoint

![image](https://github.com/user-attachments/assets/7ff0b421-bb62-4a23-bd92-9b7e38aed2c1)

El primer endpoint es un OCR que recive una imagen como request y devuelve un jsson con el texto de la imagen en español


El segundo endpoint se puede obtener el texto de un pdf en formato json


El OCR utiliza la libreria Tesseract OCR que hay que descargar los paquetes de los distinto idiomas hay una carpeta creada en el proyecto por si se quiere sumar algun idioma la ruta es configurable desde el appseting

En el caso de testint deje unos archivos pdf para una prueba unitaria la ruta se encuentra en el mismo servicio en caso de querer ejecutar los test modificar el servicio con la ruta del pdf que quieras probar.
