using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// Aquie se almacenan la informacion de las leccione con Lesson definiendo cuantas lecciones hay y lessonList que define donde se almacenan
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
