# TP Segundo Parcial de Laboratorio de Programación II - 2022

La esctructura del programa se puede ver en los siguientes diagramas de clases:

![Cartuchera](https://user-images.githubusercontent.com/76565736/203666377-ad2913b4-9d57-4cd0-a75b-a755c0475fdc.png)

Cartuchera es una Clase Genérica que recibe un tipo de útil. 
Tiene Excepciones propias como miembros y Eventos para disparar ante ciertos sucesos.

![diagramaDeClase](https://user-images.githubusercontent.com/76565736/203666395-176cb359-e788-4160-961a-a7343ebb8afc.png)

Los útiles heredan de la Clase Abstracta Util e implementan sus propios métodos y atributos. 
La clase Lapiz implementa dos interfaces: ISerializa e IDeserializa que le permiten serializar y deserializar la instancia a JSON o XML.
