using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


//Esta clase almacena el ID de la respuesta correcta y su nombre

public class OptionBtm : MonoBehaviour
{
    //Almacena el ID de la respuesta unica de cada boton
    public int OptionID;
    //Almacena el nombre de la respuesta
    public string OptionName;

}
    //Aqui se ubica el boton por su nombre en la UI
  
    void Start()
    {
        transform.GetChild(0).GetComponent<TMP_Text>().text = OptionName;
    }


    //Este metodo permite actualizar el nombre visible en UI de las preguntas para pasar a la siguiente cada vez que se requiera
  
  
    public void UpdateText()
    {
        transform.GetChild(0).GetComponent<TMP_Text>().text = OptionName;
    }

    
    //Este metodo detecta si el jugador selecciona alguna opcion,al hacerlo el levelManager actualizará la información de la respuesta del jugador 
    //y activa el boton de comprobar.
   
    /// Este metodo permite a el boton ser seleccionable
    
    public void SelectionOption()
    {
        LevelManager.Instance.SetPlayerAnswer(OptionID);
        LevelManager.Instance.CheckPlayerState();
    }
}
