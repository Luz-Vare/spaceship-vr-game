using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// La clase <c>SceneManagerScript</c> esta asociada a un objeto vacio y se
/// encarga de controlar los cambios entre las escenas, las luces de la escena
/// principal y de detectar la completitud de todos los juegos.
/// </summary>
public class SceneManagerScript : MonoBehaviour {
    public delegate void CompletedDelegate();
    public static event CompletedDelegate AllCompleted;
    public static event CompletedDelegate ExitMain;
    public static Image fadeImage;
    private static string nextScene;
    public static SceneManagerScript sceneManager;
    private static bool firstLoad;

    /// <summary>
    /// Se llama antes de que se actualice el primer frame. Fija el valor del
    /// atributo <c>fadeImage</c> con una imagen en negro para el fundido en la
    /// transicion de las escenas. Evita que se destruya al cargar la escena,
    /// manteniendo asi una unica instancia. Ademas, lanza un evento si todos
    /// los juegos estan completos, asi como actualizar las luces de las salas
    /// completadas.
    /// </summary>
    void Start() {
        fadeImage = GameObject.Find("FadeImage").GetComponent<Image>();
        SceneManager.sceneLoaded += OnSceneLoaded;

        if (sceneManager == null) {
            sceneManager = this;
            DontDestroyOnLoad(this);
        } else if (sceneManager != this) {
            Destroy(gameObject);
        }

        if (!firstLoad) {
            fadeImage.canvasRenderer.SetAlpha(0.0f);
            firstLoad = true;
        } else {
            updateLights();
        }

        if (GameInfo.AllCompleted() && AllCompleted != null) {
            AllCompleted();
        }
    }

    /// <summary>
    /// Comprueba si se ha pulsado el boton de salir y cierra la aplicacion si
    /// le corresponde.
    /// </summary>
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
    }

    /// <summary>
    /// Para cada puerta, pone las luces de color azul si el juego ha sido
    /// superado por el jugador.
    /// </summary>
    private static void updateLights() {
        GameObject firstLights = GameObject.Find("Lights1");
        GameObject secondLights = GameObject.Find("Lights2");
        GameObject thirdLights = GameObject.Find("Lights3");
        GameObject fourthLights = GameObject.Find("Lights4");

        if (GameInfo.completedFirstGame) {
            foreach(Transform light in firstLights.transform) {
                light.gameObject.GetComponent<Renderer>().materials[1].SetColor("_EmissionColor", Color.cyan);
            }
        }

        if (GameInfo.completedSecondGame) {
            foreach(Transform light in secondLights.transform) {
                light.gameObject.GetComponent<Renderer>().materials[1].SetColor("_EmissionColor", Color.cyan);
            }
        }

        if (GameInfo.completedThirdGame) {
            foreach(Transform light in thirdLights.transform) {
                light.gameObject.GetComponent<Renderer>().materials[1].SetColor("_EmissionColor", Color.cyan);
            }
        }

        if (GameInfo.completedFourthGame) {
            foreach(Transform light in fourthLights.transform) {
                light.gameObject.GetComponent<Renderer>().materials[1].SetColor("_EmissionColor", Color.cyan);
            }
        }
    }

    /// <summary>
    /// Cambia a la escena principal, haciendo un fundido en negro.
    /// </summary>
    public static void palLobby() {
        nextScene = "Main";
        sceneManager.StartCoroutine("FadeOut");
        sceneManager.StartCoroutine("FadeOut");
    }

    /// <summary>
    /// Cambia a la escena del primer juego, haciendo un fundido en negro.
    /// </summary>
    public static void firstGame() {
        nextScene = "FirstGame";
        Fireworks.changedScene = true;
        ExitMain();
        sceneManager.StartCoroutine("FadeOut");
        sceneManager.StartCoroutine("FadeOut");
    }

    /// <summary>
    /// Cambia a la escena del segundo juego, haciendo un fundido en negro.
    /// </summary>
    public static void secondGame() {
        nextScene = "SecondGame";
        Fireworks.changedScene = true;
        ExitMain();
        sceneManager.StartCoroutine("FadeOut");
        sceneManager.StartCoroutine("FadeOut");
    }

    /// <summary>
    /// Cambia a la escena del tercer juego, haciendo un fundido en negro.
    /// </summary>
    public static void thirdGame() {
        nextScene = "ThirdGame";
        Fireworks.changedScene = true;
        ExitMain();
        sceneManager.StartCoroutine("FadeOut");
        sceneManager.StartCoroutine("FadeOut");
    }

    /// <summary>
    /// Cambia a la escena del cuarto juego, haciendo un fundido en negro.
    /// </summary>
    public static void fourthGame() {
        nextScene = "FourthGame";
        Fireworks.changedScene = true;
        ExitMain();
        sceneManager.StartCoroutine("FadeOut");
        sceneManager.StartCoroutine("FadeOut");
    }

    /// <summary>
    /// Cambia la visibilidad de la imagen en negro para crear un fundido al
    /// cambiar la escena.
    /// </summary>
    private IEnumerator FadeOut() {
        fadeImage.CrossFadeAlpha(1.0f, 1.5f, true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(nextScene);
    }

    /// <summary>
    /// Cuando se carga una escena, se hace visible la imagen en negro para
    /// continuar el efecto de fundido.
    /// </summary>
    /// <param name="scene">Escena que se carga</param>
    /// <param name="mode">Modo de carga de la escena</param>
    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        fadeImage = GameObject.Find("FadeImage").GetComponent<Image>();
        fadeImage.canvasRenderer.SetAlpha(1.0f);
        fadeImage.CrossFadeAlpha(0.0f, 1.5f, true);
    }

}
