using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Esta clase esta encargada de gestionar las lecciones: agarra el contenido de las preguntas y respuestas anteriormente guardadas
/// y se encarda de lo que va a aparecer en la UI
/// </summary>
public class LessonContainer : MonoBehaviour
{
    // Variables para configurar la lección:
    //Header= nos ayuda a clasificar y separar nuestras variables en el inspector por medio de etiquetas 
    [Header("GameObject Configuration")]
    //aquí vamos a personalizar desde el inspector toda nuestra informacion que va a aparecer en el UI
    public int lection = 0;
    public int currentLession = 0;
    public int totalLession = 0;
    public bool areAllLessonsComplete = false;

    // Variables para configurar la interfaz de usuario
    [Header("UI Configuration")]
    //estas variables TMP_Text ya están creadas en el canva, esas se enlazarán con estas
    public TMP_Text stageTitle;
    public TMP_Text lessonStage;

    [Header("External GameObject Configuration")]
    //esta es nuestra imagen principal que contiene las UI de los textos y el boton
    public GameObject lessonContainer;

    [Header("Lesson Data")]
    public ScriptableObject lessonData;
    public string LessonName;


    /// <summary>
    /// Verifica si enlazamos el gameObject o nuestra imagen de lessonContainer, donde nos da la informacion de que leccion es,
    /// si no está enlazado, en la consola nos avisará que está vacío el contenedor con un mensaje de advertencia
    /// </summary>
    void Start()
    {
        //este va a verificar si nuestra imagen UI principal con toda nuestra infomacion está ligada en el inspector
        if(lessonContainer != null)
        {
            OnUpdateUI();
        }
        else
        {
            Debug.LogWarning("GameObject Nulo, revisa las variables de tipo GameObject lessonContainer");
        }
    }

    /// <summary>
    /// Este metodo verifica si están enlazados a nuestro contenedor de la variable los textos, 
    /// <c>
    /// 1. Que nos comunica la Leccion principal y actual seleccionada 
    /// 2. En cual de los niveles nos encontramos y si llevamos algun avance
    /// estos se ligan a otras variables que le informa que botón fue seleccionado para saber que imprimir en la UI
    /// </c>
    /// 
    /// En caso contrario, tenemos un else que nos avisa que tenemos le ligar nuestros textos, ya que actualmente se encuentran vacíos
    /// </summary>
    public void OnUpdateUI()
    {
        //este va a verificar que nuestros textos estan ligados a nuestro inspector en sus variables correspondientes
        if(stageTitle != null || lessonContainer != null) 
        {
            //Los .text solo funcionan con variables TMP_Stage
            stageTitle.text = "Leccion " + lection;
            lessonStage.text = "Leccion " + currentLession + " de " + totalLession;
        }
        else
        {
            Debug.LogWarning("GameObject Nulo, revisa las variable de tipo TMP_Text");
        }
    }

    /// <summary>
    /// A la hora de jugar, este se encarga de aparecer y desparecer nuestra ventana de lecciones
    /// detecta si se interactuo con el boton, al hacer clic: se activa o se desactiva la ventana
    /// </summary>
    //Esta es una funcion o metodo que nosotros creamos para personalizar por nuestra cuenta un evento
    //este metodo especificamente activa/desactiva la ventana de lessonContainer
    public void EnableWindow()
    {
        OnUpdateUI();
                            //activeSelf es si está activado
        if(lessonContainer.activeSelf)
        {
            //desactiva el objeto si está activo
            lessonContainer.SetActive(false);
        }
        else
        {
            //activa el objeto si está desactivado
            lessonContainer.SetActive(true);
            MainScript.instance.SetSelectedLesson(LessonName);
        }
    }
}
