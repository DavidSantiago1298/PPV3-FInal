using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Este es nuestro ScriptableObject: Nos va a permitir rellenar en el inspector nuestras preguntas, respuestas y designar cual es la respuesta correcta
/// Lo anterior en forma de lista
/// </summary>
[CreateAssetMenu(fileName = "Name Subject", menuName = "ScriptableObjects/New_Lesson", order = 1)]
public class Subject : ScriptableObject
{
    /// <summary>
    /// Lesson: aquí guardaremos en el Inspector el numero de la leccion
    /// leccionList: Nos va a servir para generar una lista idividual por cada leccion
    /// </summary>
    [Header("GameObject Configuration")]
    public int Lesson = 0;

    [Header("Lession Quest Configuration")]
    public List<Leccion> leccionList;
}
