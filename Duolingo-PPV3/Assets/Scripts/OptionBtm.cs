using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Esta clase está encargada de almacenar la respuesta correcta tanto en ID y en su nombre
/// </summary>
public class OptionBtm : MonoBehaviour
{
    //Almacena la respuesta individual de cada boton
    public int OptionID;
    //Almacena el nombre de la respuesta
    public string OptionName;

    /// <summary>
    /// Es esta seccion estamos inicializando nuestra variable del nombre del boton
    /// en la interfaz del usuario
    /// </summary>
    void Start()
    {
        transform.GetChild(0).GetComponent<TMP_Text>().text = OptionName;
    }

    /// <summary>
    /// Este metodo está encargado de actualizar manualmente, el nombre visible en UI de las opciones
    /// Este metodo se llama cada vez que se cambia a la siguiente pregunta
    /// </summary>
    public void UpdateText()
    {
        transform.GetChild(0).GetComponent<TMP_Text>().text = OptionName;
    }

    /// <summary>
    /// Este metodo esta encargado de detectar si el jugador selecciona la opcion,
    /// si es así, el levelManager actualizará la información de la respuesta del jugador 
    /// y hará interactuable o no el botón de comprobar.
    /// 
    /// Este metodo, se utiliza en el mismo gameObject, en el componente Button como un evento de click
    /// </summary>
    public void SelectionOption()
    {
        LevelManager.Instance.SetPlayerAnswer(OptionID);
        LevelManager.Instance.CheckPlayerState();
    }
}
