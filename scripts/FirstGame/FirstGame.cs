using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La clase <c>FirstGame</c> controla el funcionamiento
/// Del juego de Simón dice. 
/// </summary>
public class FirstGame : MonoBehaviour
{
    private int currentLevel_;
    private GameObject[] board;
    private GameObject[] tiles;
    public Light light;
    private static bool alreadyStarted_ = false;
    public static int [] playerSecuence;
    public static int [] randomValues;
    public static int currentPlayerPosition_;

    /// <summary>
    /// Se ejecuta antes de que se actualice el primer frame. Recupera 
    /// el tablero en el que se escribe el nivel, además recupera 
    /// cada una de las luces que vamos a usar, además asigna el 
    /// nivel actual.
    /// </summary>
    void Start() {
      board = GameObject.FindGameObjectsWithTag("LevelBoard");
      GameObject redLight = GameObject.Find("RedLight");
      GameObject greenLight = GameObject.Find("GreenLight");
      GameObject blueLight = GameObject.Find("BlueLight");
      GameObject yellowLight = GameObject.Find("YellowLight");
      tiles = new GameObject[] {redLight, greenLight, blueLight, yellowLight};
      currentLevel_ = 1;
    }

    /// <summary>
    /// Actualiza el cartel del nivel.
    /// </summary>
    void Update() {
      GameObject firstText = GameObject.Find("OutputLevel");
      firstText.GetComponent<TextMesh>().text = "Level: " + currentLevel_;
    }

    /// <summary>
    /// Se asegura de que no ha comenzado el juego ya, si no ha comenzado
    /// lo inicia llamando a la función PlayGame();
    /// </summary>
    public void StartGame() {
      if(!alreadyStarted_) {
        alreadyStarted_ = true;
        PlayGame();
      }
    }

    /// <summary>
    /// Cuando pasamos un nivel, reproduce la música de aplausos, además
    /// aumenta la puntuación en 10. Si hemos llegado a superar los cinco
    /// niveles, hemos completado el juego, de otra forma, aumentamos un
    /// nivel y jugamos de nuevo.
    /// </summary>
    IEnumerator NextLevel() {
      GetComponents<AudioSource>()[0].Play();
      GameInfo.IncreaseFirstScore(10);
      yield return new WaitForSeconds(4f);
      if((currentLevel_ + 1) == 6) {
        GameInfo.CompleteFirstGame();
      } else {
        currentLevel_++;
        PlayGame();
      }
    }

    /// <summary>
    /// Esta función comprueba el estdo actual de la secuencia que 
    /// introduce el usuario. Para ello comprueba si la secuencia
    /// acutual se corresponde con la secuencia generada aleatoriamente.
    /// Si es correcta, pasamos de nivel.
    /// Si no es correcta, suena el audio de fallo, la puntuación se vuelve 0
    /// y volvemos al nivel 1.
    /// </summary>
    public void CheckCurrentStatus() {
      if(playerSecuence[currentPlayerPosition_] != randomValues[currentPlayerPosition_] && currentPlayerPosition_ < playerSecuence.Length) {
        GetComponents<AudioSource>()[1].Play();
        alreadyStarted_ = false;
        GameInfo.IncreaseFirstScore(0);
        currentLevel_ = 1;
      } else {
        if(currentPlayerPosition_ == currentLevel_ - 1) {
          StartCoroutine(NextLevel());
        }
      }
    }

    /// <summary>
    /// Esta función lo que hace es añadir el color que ha tocado el jugador
    /// a su secuencia. Comprueba el estado actual y luego aumenta la posición
    /// de la secuencia, para no sobreescribirla.
    /// </summary>
    void AddColor(int color) {
      if(alreadyStarted_ && currentPlayerPosition_ < playerSecuence.Length) {
        playerSecuence[currentPlayerPosition_] = color;
        CheckCurrentStatus();
        currentPlayerPosition_++;
      }
    }

    /// <summary>
    /// El 0 representa el color rojo.
    /// </summary>
    public void AddRed() {
      AddColor(0);
    }
    /// <summary>
    /// El 1 representa el color verde.
    /// </summary>
    public void AddGreen() {
      AddColor(1);
    }
    /// <summary>
    /// El 2 representa el color azul.
    /// </summary>
    public void AddBlue() {
      AddColor(2);
    }
    /// <summary>
    /// El 3 representa el color amarillo.
    /// </summary>
    public void AddYellow() {
      AddColor(3);
    }

    /// <summary>
    /// El juego comienza inicializando las secuencias del computador y del
    /// jugador, al tamaño del nivel actual.
    /// Además el jugador empieza en la posición 0.
    /// Por último se genera una secuencia aleatoria de colores.
    /// </summary>
    void PlayGame() {
      randomValues = new int[currentLevel_];
      playerSecuence = new int[currentLevel_];
      currentPlayerPosition_ = 0;

      for(int i = 0; i < currentLevel_; i++) {
        randomValues[i] = Random.Range(0, 4);
      }
      StartCoroutine(PlaySecuence(randomValues));
    }

    /// <summary>
    /// Una vez tenemos generada la secuencia aleatoria de colores, lo que
    /// hacemos es mostrársela al usuario a través de la ejecución de su
    /// sonido y el aumento o disminución de la intensidad de la luz.
    /// </summary>
    IEnumerator PlaySecuence(int [] randomValues) {
      for(int i = 0; i < currentLevel_; i++) {
        tiles[randomValues[i]].GetComponent<AudioSource>().Play();
        tiles[randomValues[i]].transform.GetChild(0).GetComponent<Light>().intensity = 1.50f;
        yield return new WaitForSeconds(1f);
        tiles[randomValues[i]].transform.GetChild(0).GetComponent<Light>().intensity = 0f;
      }
    }
}
