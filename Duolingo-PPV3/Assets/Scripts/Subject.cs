using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//Este metodo permite rellenar en el inspector las preguntas, respuestas e identificar la respuesta correcta en una lista


[CreateAssetMenu(fileName = "Name Subject", menuName = "ScriptableObjects/New_Lesson", order = 1)]
public class Subject : ScriptableObject
{
  
    //Este header establece la leccion
   
    [Header("GameObject Configuration")]
    public int Lesson = 0;

    //Este header establece la lista

    [Header("Lession Quest Configuration")]
    public List<Leccion> leccionList;
}
