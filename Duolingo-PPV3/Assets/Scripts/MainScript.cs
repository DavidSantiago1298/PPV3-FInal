using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Contiene todas las funciones necesarias para la escena Main, desde una ventana emergente, la interaccion de botones para aparecer: 
/// creditos, cambiar la aparencia de un cofre, seleccionar las lecciones e incluso cambiar de escena
/// </summary>
public class MainScript : MonoBehaviour
{
    public static MainScript instance;
    public string SelectedLesson = "dummy";

    [Header("External GameObject Configuration")]
    //esta es nuestra imagen principal que contiene la UI 
    public GameObject creditos;
    public GameObject cofre;
    public GameObject uno;
    public GameObject dos;

    /// <summary>
    ///Verificará que solo haya una instancia de MainScript
    /// </summary>

    private void Awake()
    {
        if(instance != null)
        {
            return;
        }
        else
        {
            instance = this;
        }
    }

    /// <summary>
    /// Establece la leccion y la almacena en PlayerPrefs 
    /// </summary>
    /// <param name="lesson"></param>
    public void SetSelectedLesson(string lesson)
    {
        SelectedLesson = lesson;
        PlayerPrefs.SetString("SelectedLesson", SelectedLesson);
    }

    /// <summary>
    /// Este metodo esta ligado al boton de la ventana emergente de las lecciones, nos ayuda a cambiar de la escena donde nos encontramos (Main) a la de las lecciones (Lessons)
    /// </summary>
    public void BeginGame()
    {
        SceneManager.LoadScene("Lesson");
    }

    /// <summary>
    /// Este metodo está ligado al boton con la imagen de un foco, al cliquear  nos llevará a la escena de Novedades
    /// </summary>
    public void DatesInteresting()
    {
        SceneManager.LoadScene("Novedades");
    }

    /// <summary>
    /// Este metodo esta ligado al boton con imagen de una casa, al interactuar con este te llevará a la escena Main, que es la principal escena del proyecto
    /// </summary>
    public void GoToMenu()
    {
        SceneManager.LoadScene("Main");
    }


    /// <summary>
    /// Este metodo nos ayuda a aparecer y desaparecer la ventana que nos despliega la opcion para ir a nuestra leccion
    /// </summary>
    public void EnableWindow()
    {
        //activeSelf es si está activado
        if (creditos.activeSelf)
        {
            //desactiva el objeto si está activo
            creditos.SetActive(false);
        }
        else
        {
            //activa el objeto si está desactivado
            creditos.SetActive(true);
            //MainScript.instance.SetSelectedLesson(LessonName);
        }
    }
    /// <summary>
    /// Aparece y desaparece la imagen del primer boton de los datos interesantes
    /// </summary>
    public void One()
    {
        //activeSelf es si está activado
        if (uno.activeSelf)
        {
            //desactiva el objeto si está activo
            uno.SetActive(false);
        }
        else
        {
            //activa el objeto si está desactivado
            uno.SetActive(true);
            //MainScript.instance.SetSelectedLesson(LessonName);
        }
    }
    /// <summary>
    /// Aparece y desaparece la imagen del segundo boton de los datos interesantes
    /// </summary>
    public void Dos()
    {
        //activeSelf es si está activado
        if (dos.activeSelf)
        {
            //desactiva el objeto si está activo
            dos.SetActive(false);
        }
        else
        {
            //activa el objeto si está desactivado
            dos.SetActive(true);
            //MainScript.instance.SetSelectedLesson(LessonName);
        }
    }

    /// <summary>
    /// Este metodo activa y desactiva la imagen del cofre ligada en el Canva
    /// </summary>
    public void Cofre()
    {
        //activeSelf es si está activado
        if (cofre.activeSelf)
        {
            //desactiva el objeto si está activo
            cofre.SetActive(false);
        }
        else
        {
            //activa el objeto si está desactivado
            cofre.SetActive(true);
            //MainScript.instance.SetSelectedLesson(LessonName);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
