using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Almacena la informacion de la leccion, Lesson: Almacena el número de leccion y lessonList: es la lista donde almacena las lecciones creadas
/// </summary>
[System.Serializable]
public class SubjectContainer 
{
    [Header("GameObject Configuration")]
    [SerializeField]
    public int Lesson = 0;

    [Header("Lession Quest Configuration")]
    [SerializeField]
    public List<Leccion> leccionList;
}
