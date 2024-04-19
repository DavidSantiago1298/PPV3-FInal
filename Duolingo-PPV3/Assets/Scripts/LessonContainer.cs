using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


//Este scrypt gestiona las lecciones, genera el contenido de las preguntas y respuestas anteriormente guardadas en los JSON
//y permite que aparezcan en la UI

public class LessonContainer : MonoBehaviour
{
    //Variables para configurar la lección:
    //Header = Crea etiquetas que nos ayudan a separar la leccion 
    [Header("GameObject Configuration")]
    //Estas variables definen toda la configuracion del scrypt, numero de lecciones, en que leccion te encuentras, el total de lecciones
    // y verifica cuando las hayas terminado
    public int lection = 0;
    public int currentLession = 0;
    public int totalLession = 0;
    public bool areAllLessonsComplete = false;

    // Variables para configurar la interfaz de usuario
    [Header("UI Configuration")]
    //Estas variables TMP_Text  sirven para conectar el scrypt con el canvas correspondiente
    public TMP_Text stageTitle;
    public TMP_Text lessonStage;

    [Header("External GameObject Configuration")]
    //Esta variable genera el gameobject que contendra todo el lessoncontainer
    public GameObject lessonContainer;

    [Header("Lesson Data")]
    public ScriptableObject lessonData;
    public string LessonName;

    /// Este metodo verifica si se  enlazo correctamente el gameObject al lessonContainer, que a la vez permite que nos diga que leccion es,
    /// si no está enlazado, en la consola saldra e siguiente mensaje de advertencia:
    /// </summary>
    void Start()
    {
        //Este if verifica si efectivamente la imagen esta conectada al LessonContainer
        if(lessonContainer != null)
        {
            OnUpdateUI();
        }
        //En caso de que no, el else lanza el mensaje
        else
        {
            Debug.LogWarning("GameObject Nulo, revisa las variables de tipo GameObject lessonContainer");
        }
    }

    /
    //Este metodo verifica que esten conectanadaos los contenedores a las lecciones, definiendo en que leccion estamos y el avance
    //pero si no estan conenctados el else qlanza la alerta para verificar que esten bien conectados
   
    public void OnUpdateUI()
    {
        //Esta linea verifica que los textos estan ligados al inspector en sus variables correspondientes
        if(stageTitle != null || lessonContainer != null) 
        {
          
            stageTitle.text = "Leccion " + lection;
            lessonStage.text = "Leccion " + currentLession + " de " + totalLession;
        }
        else
        {
            Debug.LogWarning("GameObject Nulo, revisa las variable de tipo TMP_Text");
        }
    }

   
    //A la hora de jugar, este se encarga de aparecer y desparecer nuestra ventana de lecciones
    //detecta si se interactuo con el boton, al hacer clic: se activa o se desactiva la ventana
    
    //Esta es una funcion o metodo que nosotros creamos para personalizar por nuestra cuenta un evento
    //este metodo especificamente activa/desactiva la ventana de lessonContainer
    public void EnableWindow()
    {
        OnUpdateUI();
        //En caso de que este activado...
        if(lessonContainer.activeSelf)
        {
            //Desactiva el objeto si está activo
            lessonContainer.SetActive(false);
        }
        else
        {
            //Zctiva el objeto si está desactivado
            lessonContainer.SetActive(true);
            MainScript.instance.SetSelectedLesson(LessonName);
        }
    }
}
