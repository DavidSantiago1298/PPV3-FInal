using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Aqui guardaremos la informacion de la leccion, se almacenarán y despues se podrá hacer uso de ellos
/// </summary>
[System.Serializable]
public class Leccion
{
    //Aqui guardamos el numero de leccion
    public int ID;
    //Aqui almacenamos nuestra pregunta
    public string lessons;
    //Aqui almacenamos nuestras respuestas
    public List<string> options;
    //aqui se almacena la respuesta correcta
    public int correctAnswer;
}
