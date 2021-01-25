using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

/*
 * Esta clase se utiliza para representar la informacion conjunta de los juegos,
 * como son la puntuacion o si esta completo o no.
 */
/// <summary>
/// La clase <c>GameInfo</c> se utiliza para representar la informacion conjunta
/// de los juegos, como son la puntuacion o si esta completo o no.
/// </summary>
public class GameInfo : MonoBehaviour {
    public static GameInfo gameInfo;
    public static bool completedFirstGame;
    public static bool completedSecondGame;
    public static bool completedThirdGame;
    public static bool completedFourthGame;
    public static int scoreFirstGame;
    public static int scoreSecondGame;
    public static int scoreThirdGame;
    public static int scoreFourthGame;
    private static bool firstLoad;

    /// <summary>
    /// Se llama antes de actualizar el primer frame. Reinicia la puntuacion de
    /// los juegos cuando se vuelve a la primera escena.Ademas, evita que se
    /// destruya al cambiar de escena para mantener la misma instancia.
    /// </summary>
    void Start() {
        scoreFirstGame = 0;
        scoreSecondGame = 0;
        scoreThirdGame = 0;
        scoreFourthGame = 0;

        if (gameInfo == null) {
            gameInfo = this;
            DontDestroyOnLoad(this);
        } else if (gameInfo != this) {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Determina si todos los juegos han sido completados.
    /// </summary>
    /// <returns><c>True</c> si todos estan completos, <c>False</c> si no.</returns>
    public static bool AllCompleted() {
        return completedFirstGame && completedSecondGame && completedThirdGame && completedFourthGame;
    }

    /// <summary>
    /// Incrementa la puntuacion del primer juego en una cierta cantidad y
    /// actualiza la informacion de la consola en la que se muestra.
    /// </summary>
    /// <param name="points">Cantidad de puntos en los que se incrementa.</param>
    public static void IncreaseFirstScore(int points) {
        scoreFirstGame += points;
        if(points == 0) {
          scoreFirstGame = 0;
        }
        UpdateFirstText();
    }

    /// <summary>
    /// Incrementa la puntuacion del segundo juego en una cierta cantidad y
    /// actualiza la informacion de la consola en la que se muestra.
    /// </summary>
    /// <param name="points">Cantidad de puntos en los que se incrementa.</param>
    public static void IncreaseSecondScore(int points) {
        scoreSecondGame += points;
        if (scoreSecondGame < 0) {
            scoreSecondGame = 0;
        }
        UpdateSecondText();
    }

    /// <summary>
    /// Incrementa la puntuacion del tercer juego en una cierta cantidad y
    /// actualiza la informacion de la consola en la que se muestra.
    /// </summary>
    /// <param name="points">Cantidad de puntos en los que se incrementa.</param>
    public static void IncreaseThirdScore(int points) {
        scoreThirdGame += points;
        UpdateThirdText();
    }

    /// <summary>
    /// Incrementa la puntuacion del cuarto juego en una cierta cantidad y
    /// actualiza la informacion de la consola en la que se muestra.
    /// </summary>
    /// <param name="points">Cantidad de puntos en los que se incrementa.</param>
    public static void IncreaseFourthScore(int points) {
        scoreFourthGame += points;
        UpdateFourthText();
    }

    /// <summary>
    /// Actualiza el texto de la consola donde se muestra la puntuacion del
    /// primer juego.
    /// </summary>
    private static void UpdateFirstText() {
        GameObject firstText = GameObject.Find("Output");
        firstText.GetComponent<TextMesh>().text = "Score: " + scoreFirstGame;
    }

    /// <summary>
    /// Actualiza el texto de la consola donde se muestra la puntuacion del
    /// segundo juego.
    /// </summary>
    private static void UpdateSecondText() {
        GameObject firstText = GameObject.Find("Output");
        firstText.GetComponent<TextMesh>().text = "Score: " + scoreSecondGame;
    }

    /// <summary>
    /// Actualiza el texto de la consola donde se muestra la puntuacion del
    /// tercer juego.
    /// </summary>
    private static void UpdateThirdText() {
        GameObject thirdText = GameObject.Find("Output");
        if ((99 - scoreThirdGame) > 0 ) {
            thirdText.GetComponent<TextMesh>().text = "Score: " + (99 - scoreThirdGame);
        } else {
            thirdText.GetComponent<TextMesh>().text = "Score: 0";
        }
    }

    /// <summary>
    /// Actualiza el texto de la consola donde se muestra la puntuacion del
    /// cuarto juego.
    /// </summary>
    private static void UpdateFourthText() {
        GameObject firstText = GameObject.Find("Output");
        firstText.GetComponent<TextMeshPro>().text = "Score: " + scoreFourthGame;
    }

    /// <summary>
    /// Establece el estado del primer juego como completado, y vuelve a la
    /// escena principal.
    /// </summary>
    public static void CompleteFirstGame() {
        completedFirstGame = true;
        SceneManagerScript.palLobby();
    }

    /// <summary>
    /// Establece el estado del segundo juego como completado, y vuelve a la
    /// escena principal.
    /// </summary>
    public static void CompleteSecondGame() {
        completedSecondGame = true;
        SceneManagerScript.palLobby();
    }

    /// <summary>
    /// Establece el estado del tercer juego como completado, y vuelve a la
    /// escena principal.
    /// </summary>
    public static void CompleteThirdGame() {
        completedThirdGame = true;
        scoreThirdGame = 99 - scoreThirdGame;
        if (scoreThirdGame < 0) {
            scoreThirdGame = 0;
        }
        SceneManagerScript.palLobby();
    }

    /// <summary>
    /// Establece el estado del cuarto juego como completado, y vuelve a la
    /// escena principal.
    /// </summary>
    public static void CompleteFourthGame() {
        completedFourthGame = true;
        SceneManagerScript.palLobby();
    }
}
