using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//Este script permite a salir cerrar la app

public class Exit : MonoBehaviour
{
    
    //Este metodo reacciona al dar  clic encima del boton padre y cierra la app
    
    public void ExitGame()
    {
        // Si el editor de Unity
#if UNITY_EDITOR
       
        UnityEditor.EditorApplication.isPlaying = false;
       
#else
            // Cierra la aplicación
            Application.Quit();
#endif
    }
}
