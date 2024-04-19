using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


//Este scrypt controla el manejo de las lecciones permintiendo cambiar las preguntas sus respuestas y  nos indicará
//si esta es correcta o incorrecta al presionas comprobar

public class LevelManager : MonoBehaviour
{
    //Instancia de la clase de la leccion
    public static LevelManager Instance;
    [Header("Level Data")]
    public SubjectContainer subject;

    //Un header que define la interfaz y sus colores ya acciones
    [Header("User Interface")]
    public TMP_Text QuestionTxt;
    public TMP_Text livesTxt;
    public List<OptionBtm> Options;
    public GameObject CheckButton;
    public GameObject AnswerContainer;
    public Color Green;
    public Color Red;

    [Header("Game Configuration")]
    public int questionAmount = 0;
    public int currentQuestion = 0;
    public string question;
    public string correctAnswer;
    public int answerFromPlayer;
    public int lives = 5;

    [Header("Current Lesson")]
    public Leccion currentLesson;

    //Patron Singleton: Es un patrón de diseño, encargado, de crear una instancia de la clase para ser referenciada en otra clase sin la necesidad de declarar una variables.
    
    //El singleton verificará que solo haya una instancia de LevelManager
    
    private void Awake()
    {
        if(Instance != null)
        {
            return;
        }
        else
        {
            Instance = this;
        }
    }

    
    /// Este metodo es el que permite al tache regresar al menu principal
  
    public void GoToMenu()
    {
        SceneManager.LoadScene("Main");
    }


  
    //Esta cargará la primera pregunta de la leccion y registra la respuesta,
    //para despues habilitar el botón de comprobar
    
    
    void Start()
    {
        subject = SaveSystem.Instance.subject;
        //Establece la cantidad de preguntas en la leccion
        questionAmount = subject.leccionList.Count;
        //Cargar la 1er pregunta
        LoadQuestion();
       //Revisa que esta haciendo el jugador
        CheckPlayerState();
    }

    //Está encargado de buscar las preguntas, aquí esta la logica sobre lo que aparecera para la leccion, la pregunta y sus respuestas correspondientes
    //llamará la informacion para verificar la respuesta correcta y las opciones guardadas
    //na vez que se acaben las preguntas guardadas o asignadas, en consola aparecera un mensaje indicandolo
 
    private void LoadQuestion()
    {
        //Aseguramos que la pregunta actual esta dentro de los limites
        if(currentQuestion < questionAmount) 
        {
            //Establece la leccíon actual
            currentLesson = subject.leccionList[currentQuestion];
            //Genera la pregunta
            question = currentLesson.lessons;
            //Establece cual es la respuesta correcta
            correctAnswer = currentLesson.options[currentLesson.correctAnswer];
            //Manda la pregunta a la  UI
            QuestionTxt.text = question;
            //Genera las demas Opciones
            Options[0].GetComponent<OptionBtm>().OptionName = currentLesson.options[0];
            for(int i = 0; i < currentLesson.options.Count; i++)
            {
                Options[i].GetComponent<OptionBtm>().OptionName = currentLesson.options[i];
                Options[i].GetComponent<OptionBtm>().OptionID = i;
                Options[i].GetComponent<OptionBtm>().UpdateText();
            }
        }
        else
        {
            //Y al termianr la leccion manda el mensaje de final de las preguntas a la consola
            Debug.Log("Fin de las preguntas");
           
        }
    }

    
    //Este metodo es el que permite que, al verificar la respuesta, si es correcta aparecerá una ventana emergente verde, 
    //en caso contrario sera roja, y pasa a la siguiente pregunta
    public void NextCuestion()
    {
        if(CheckPlayerState())
        {
            if (currentQuestion < questionAmount)
            {
                //Revisa si la respuesta es correcta o no
                bool isCorrect = currentLesson.options[answerFromPlayer] == correctAnswer;

                AnswerContainer.SetActive(true);

                if(isCorrect)
                {
                    AnswerContainer.GetComponent<Image>().color = Green;
                    Debug.Log("Respuesta correcta. " + question + ": " + correctAnswer);
                }
                else
                {
                    lives--;
                    AnswerContainer.GetComponent<Image>().color = Red;
                    Debug.Log("Respuesta incorrecta. " + question + ": " + correctAnswer);

                }
                //Actualiza  el contador de vida
                livesTxt.text = lives.ToString();

                //Incrementa el indice de la pregunta 
                currentQuestion++;

                //Mostrar el resultado durante un tiempo para que el usuario se corrija
                StartCoroutine(ShowResultAndLoadQuestion(isCorrect));

                //reinicia el proceso
                answerFromPlayer = 9;
            }
            else
            {
                //Cambia de escena
            }
        }
    }

    
    //Este metodo se encarga de mostrara la respuesta correcta a la pregunta, despues de 1.5 segundos
    //se ocultará y seguira con la siguiente pregunta
  
    private IEnumerator ShowResultAndLoadQuestion(bool isCorrect)
    {
        //Define el tiempo en el que se muestra el resultado
        yield return new WaitForSeconds(1.5f); 

        //Oculta el contenedor de respuestas
        AnswerContainer.SetActive(false);

        //Carga la siguiente pregunta
        LoadQuestion();
        CheckPlayerState();
    }

    
    //Aquí se guarda la respuesta que eligio el usuario
   
    
    public void SetPlayerAnswer(int _answer)
    {
        answerFromPlayer = _answer;
    }

   
    //Este metodo detecta si ya fue seleccionada una respuesta, para despues habilitar el boton de comprobar y evite cuakquier otra accion
   
    public bool CheckPlayerState()
    {
        if(answerFromPlayer != 9)
        {
            CheckButton.GetComponent<Button>().interactable = true;
            CheckButton.GetComponent<Image>().color = Color.white;
            return true;
        }
        else
        {
            CheckButton.GetComponent<Button>().interactable = true;
            CheckButton.GetComponent<Image>().color = Color.grey;
            return false;

        }
    }
}
