using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

/// <summary>
/// En nuestra escena lesson, esta clase nos va a ayudar a cambiar las preguntas, las opciones de los botones
/// Tambien nos inicará si esta es correcta o incorrecta a la hora de seleccionarla y enviar la respuesta
/// </summary>
public class LevelManager : MonoBehaviour
{
    //Instancia de la clase
    public static LevelManager Instance;
    [Header("Level Data")]
    public SubjectContainer subject;

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

    //(.5 pts perdidos XD) Patron Singleton: Es un patrón de diseño, encargado, de crear una instancia de la clase para ser referenciada en otra clase sin la necesidad de declarar una variables.
    /// <summary>
    ///Verificará que solo haya una instancia de LevelManager
    /// </summary>
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

    /// <summary>
    /// Este metodo esta ligado a un boton con imagen de un tache, nos ayudará a regresar a la escena principal "Main"
    /// </summary>
    public void GoToMenu()
    {
        SceneManager.LoadScene("Main");
    }


    /// <summary>
    ///  Esta cargará la primera pregunta de nuestra leccion y registra la respuesta,
    ///  para despues habilitar el botón para enviar la respuesta
    ///  Todo es a nivel UI/comienza desde que empezamos a jugar
    /// </summary>
    void Start()
    {
        subject = SaveSystem.Instance.subject;
        //Establecemos la cantidad de preguntas en la leccion
        questionAmount = subject.leccionList.Count;
        //Cargar la primera pergunta
        LoadQuestion();
        //check player input
        CheckPlayerState();
    }

    /// <summary>
    /// Está encargado de buscar las preguntas, aquí esta la logica sobre lo que aparecera para la leccion, la pregunta y sus respuestas correspondientes
    /// llamará la informacion para verificar la respuesta correcta y las opciones guardadas
    /// una vez que se acaben las preguntas guardadas o asignadas, en consola aparecera un mensaje indicandolo
    /// </summary>
    private void LoadQuestion()
    {
        //Aseguramos que la pregunta actual esta dentro de los limites
        if(currentQuestion < questionAmount) 
        {
            //Establecemos la leccíon actual
            currentLesson = subject.leccionList[currentQuestion];
            //Establecemos la pregunta
            question = currentLesson.lessons;
            //Establecemos la respuesta correcta
            correctAnswer = currentLesson.options[currentLesson.correctAnswer];
            //Establecemos la pregunta en UI
            QuestionTxt.text = question;
            //Establecemos las Opciones
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
            //Si llegamos al final de las preguntas
            Debug.Log("Fin de las preguntas");
           
        }
    }

    /// <summary>
    /// Este metodo nos ayuda a verificar la respuesta, si estuv bien aparecerá una ventana emergente verde, 
    /// si la respuesta fue incorrecta el color será rojo
    /// y procederá a mostrarnos la siguiente pregunta
    /// </summary>
    public void NextCuestion()
    {
        if(CheckPlayerState())
        {
            if (currentQuestion < questionAmount)
            {
                //Revisamos si la respuesta es correcta o no
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
                //Actualizamos el contador de vida
                livesTxt.text = lives.ToString();

                //Incrementamos el indice de la pregunta actual
                currentQuestion++;

                //Mostrar el resultado durante un tiempo (puedes usar una corotine o Invoke)
                StartCoroutine(ShowResultAndLoadQuestion(isCorrect));

                //Reset answer from player
                answerFromPlayer = 9;
            }
            else
            {
                //Cambio de escena
            }
        }
    }

    /// <summary>
    /// Aqui nos mostrara la respuesta correcta a la pregunta despues de haber sido respondida, esperará 2.5 segundos
    /// se ocultará y llamará a la siguiente pregunta
    /// </summary>
    /// <param name="isCorrect"></param>
    /// <returns></returns>
    private IEnumerator ShowResultAndLoadQuestion(bool isCorrect)
    {
        yield return new WaitForSeconds(2.5f); //Ajusta el tiempo que deseas mostrar el resultado

        //Ocultar el contenedor de respuestas
        AnswerContainer.SetActive(false);

        //Cargar la nueva pregunta
        LoadQuestion();

        //Activar el botón después de mostrar el resultado
        //Puedes hacer esto aquí o en LoadQuestion(), dependiendo de tu estructura
        //por ejemplo, si el botón está en el mismo GameObject que el script:
        //GetComponent<Buttton>().intercatable = true;
        CheckPlayerState();
    }

    /// <summary>
    /// Aquí nos guarda la respuesta del jugador, la que eligió
    /// </summary>
    /// <param name="_answer"></param>
    public void SetPlayerAnswer(int _answer)
    {
        answerFromPlayer = _answer;
    }

    /// <summary>
    /// Este detecta si ya fue seleccionada una respuesta, para despues habilitar el boton de comprobar
    /// mientras no nos deja enviar nada
    /// </summary>
    /// <returns></returns>
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
