using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


//Contiene todas las funciones necesarias para el menu principal como la  ventana emergente,el poder aparecer e interactuar con los botones 
//de los creditos y seleccionar las lecciones o cambiar de escena

public class MainScript : MonoBehaviour
{
    public static MainScript instance;
    public string SelectedLesson = "dummy";

    [Header("External GameObject Configuration")]
    //esta es nuestra imagen principal que contiene la UI 
    public GameObject creditos;
  
    
    //Singleton que verifica que solo haya una instancia de MainScript
   

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

    
    //Establece la leccion que eligio el usuario y la gaurda en playerprefs
    
    public void SetSelectedLesson(string lesson)
    {
        SelectedLesson = lesson;
        PlayerPrefs.SetString("SelectedLesson", SelectedLesson);
    }

   
    //Este metodo es el que permite que se puedan elegir lecciones, n
    //permite cambiar la escena donde nos encontramos a la de las lecciones
    
    public void BeginGame()
    {
        SceneManager.LoadScene("Lesson");
    }


    
    //Este metodo permite aparecer o desaparecer la ventana que despliega la opcion para ir a una leccion
   
    public void EnableWindow()
    {
        //En caso de que este activado...
        if (creditos.activeSelf)
        {
            //Desactiva el objeto si está activo
            creditos.SetActive(false);
        }
        else
        {
            //o Activa el objeto si está desactivado
            creditos.SetActive(true);

        }
    }
  