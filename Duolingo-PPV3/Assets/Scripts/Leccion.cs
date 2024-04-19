using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//En este scrypt se guarda la informacion de la leccion a la vez que la almacena para usarse en el juego

[System.Serializable]
public class Leccion
{
    //Este metodo crea el numero ID de leccion
    public int ID;
    //Este metodo crea la pregunta
    public string lessons;
    //Este metodo crea las respuestas
    public List<string> options;
    //Este metodo crea a las respuestas y  define la respuesta correcta
    public int correctAnswer;
}
