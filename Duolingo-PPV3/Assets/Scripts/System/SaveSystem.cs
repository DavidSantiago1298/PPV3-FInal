using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// SaveSystem: ahorita verifica con la instancia si no existe otro de su mismo tipo, CreateFile: es capaz de crear documentos especificando su nombre y extension,
/// ReadFile: nos ayuda a reflejar en consola la informacion de algun archivo que hayamos creado, busca el archivo en RESOURCES
/// JSON: nos va a ayudar a crear un grupo que podamos guardar, para su uso a futuro
/// </summary>
public class SaveSystem : MonoBehaviour
{
    //Creamos una instancia (la instancia es para referirce a un objeto ya existente, para así no tener que crear un nuevo objeto para todo)
    public static SaveSystem Instance;

    public Leccion data;
    public SubjectContainer subject;

    /// <summary>
    /// Patrón Singleton:
    /// Verificará que solo haya una instancia de SaveSystem
    /// </summary>
    private void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        else
        {
            Instance = this;
        }
        subject = LoadFromJSON<SubjectContainer>(PlayerPrefs.GetString("SelectedLesson"));
    }

    void Start()
    {
        //SaveToJSON("LeccionDummy", data);

        //CreateFile("Luis", ".data");
        //Debug.Log(ReadFile("Luis", ".data"));

        //subject = LoadFromJSON<SubjectContainer>("SegundoCompendio");
    }

    public void CreateFile(string _name, string _extension)
    {
        //1. Definir el path del archivo
        string path = Application.dataPath + "/" + _name + _extension;
        //2. Revisamos, si, el archivo en el path NO existe
        if(!File.Exists(path))
        {
            //3. Creamos el contenido
            string content = "Loging Date: " + System.DateTime.Now + "\n";

            //Fernando: Posicion del objeto
            string position = "x: " + transform.position.x + "y: " + transform.position.y;

            //4. Almacenamos la informacion
            //File.AppendAllText(path, content);
            File.AppendAllText(path, position);

        }
        else
        {
            Debug.LogWarning("Atencion: Estas tratando de crear un archivo con el mismo nombre [" + _name + _extension + "], verifica tu informacion");
        }
    }

    public string ReadFile(string _fileName, string _extension)
    {
        //1) Acceder al path del archivo
        string path = Application.dataPath + "/Resources/" + _fileName + _extension;
        //2) Si el archivo existe, dame su info
        string data = "";
        if(File.Exists(path))
        {
            data = File.ReadAllText(path);
        }
        return data;
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveToJSON(string _fileName, object _data)
    {
        if(_data != null)
        {
            string JSONData = JsonUtility.ToJson(_data, true);

            if (JSONData.Length != 0)
            {
                Debug.Log("JSON STRING: " + JSONData);
                string fileName = _fileName + ".json";
                string filePath = Path.Combine(Application.dataPath + "/Resources/JSONS/", fileName);
                File.WriteAllText(filePath, JSONData);
                Debug.Log("JSON almacenado en la direccion: " + filePath);
            }
            else
            {
                Debug.LogWarning("ERROR - FileSystem: JSONData is empty, check for local variable [string JSONData]");
            }
        }
        else
        {
            Debug.LogWarning("ERRROR - FileSystem: _data is null, check for param [object _data]");
        }
    }

    public T LoadFromJSON<T>(string _fileName) where T : new()
    {
        T Dato = new T();
        string path = Application.dataPath + "/Resources/JSONS/" + _fileName + ".json";
        string JSONData = "";
        if(File.Exists(path))
        {
            JSONData = File.ReadAllText(path);
            Debug.Log("JSON STRING: " + JSONData);
        }
        if(JSONData.Length != 0)
        {
            JsonUtility.FromJsonOverwrite(JSONData, Dato);
        }
        else
        {
            Debug.LogWarning("ERROR - FileSystem: JSONData is empty, check for local variable [string] JSONData");
        }
        return Dato;
    }
}
