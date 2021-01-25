using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// <c>SphereManagerScript</c> es una clase que se le asigna a un gameObject vacío. Que tiene como hijos un grupo de esferas top
/// y otro grupo de esferas bottom. Controla completamente toda la lógica del minijuego "Spheres"
/// </summary>
public class SphereManagerScript : MonoBehaviour
{

    /// <summary>
    /// Lista de esferas superiores fijas
    /// </summary>
    private GameObject[] upperSpheres;

    /// <summary>
    /// Lista de esferas inferiores. Estas esferas deben cambiar su color para tener el mismo patrón que las superiroes para completar el minijuego.
    /// </summary>
    private GameObject[] bottomSpheres;

    /// <summary>
    /// Lista de posibles colores que pueden tener las esferas
    /// </summary>
    private Color[] colors = {Color.black, Color.yellow, Color.red, Color.blue, Color.green};

    /// <summary>
    /// Almacenamos el índice de color de cada Esfera. Es decir que color, dentro de colors, tiene cada esfera de bottoSpheres ahora mismo.
    /// </summary>
    private int[] colorIndexes = { 0, 0, 0, 0 };

    /// <summary>
    /// Almacenamos si el minijuego ha sido completado o no
    /// </summary>
    static private bool completed;

    /// <summary>
    /// Un audio asociado a este gameObject que reproduciremos cada vez que cambiemos el color de una esfera en el minijuego.
    /// </summary>
    private AudioSource audio;

    /// <summary>
    /// Cantidad de movimientos realizados. Aumenta cada vez que cambiamos los colores de las esferas
    /// </summary>
    static int movementsMade = 0;

    /// <summary>
    /// Una referencia al gameObject que reproducirá aplausos al finalizar el minijuego
    /// </summary>
    GameObject altavozAplausos;

    /// <summary>
    /// primera esfera de las superiores (NEcesario para fijar bien el orden de cada esfera, pues es importante y hacer find en los gameObjects hijos, o hacer find con tag, no es consistente)
    /// </summary>
    public GameObject topFirstSphere;

    /// <summary>
    /// segunda esfera de las superiores
    /// </summary>
    public GameObject topSecondSphere;

    /// <summary>
    /// tercera esfera de las superiores
    /// </summary>
    public GameObject topThirdSphere;

    /// <summary>
    /// cuarta esfera de las superiores
    /// </summary>
    public GameObject topFourthSphere;

    /// <summary>
    /// primera esfera de las inferiores
    /// </summary>
    public GameObject botFirstSphere;

    /// <summary>
    /// segunda esfera de las inferiores
    /// </summary>
    public GameObject botSecondSphere;

    /// <summary>
    /// tercera esfera de las inferiores
    /// </summary>
    public GameObject botThirdSphere;

    /// <summary>
    /// primera esfera de las inferiores
    /// </summary>
    public GameObject botFourthSphere;

    /// <summary>
    /// Encontramos referencias a altavozAplausos y las esferas.
    /// Creamos el vector de colors, bottomsPheres, y upperSpheres. A cada esfera le asignamos un color aleatorio.
    /// Exceptuando a la primera esfera superior y primera esfera inferior. A las cuales le asignamos colores fijos para asegurarnos
    /// de que sea imposible por azar que comienze el minijuego con las esferas ya resueltas.
    /// </summary>
    void Start() {
        altavozAplausos = GameObject.FindGameObjectsWithTag("secondGameAplausos")[0];
        audio = GetComponent<AudioSource>();
        completed = false;
        colors[0] = Color.black;
        colors[1] = Color.yellow;
        colors[2] = Color.red;
        colors[3] = Color.blue;
        colors[4] = Color.green;
        bottomSpheres = GameObject.FindGameObjectsWithTag("secondGameBottomSphere");
        bottomSpheres[0] = botFirstSphere;
        bottomSpheres[1] = botSecondSphere;
        bottomSpheres[2] = botThirdSphere;
        bottomSpheres[3] = botFourthSphere;
        upperSpheres = GameObject.FindGameObjectsWithTag("secondGameUpperSphere");
        upperSpheres[0] = topFirstSphere;
        upperSpheres[1] = topSecondSphere;
        upperSpheres[2] = topThirdSphere;
        upperSpheres[3] = topFourthSphere;

        for (int i = 1; i < upperSpheres.Length; i++) {
            randomChangeSphereColor(upperSpheres[i], i);
        }
        for (int i = 1; i < bottomSpheres.Length; i++) {
            randomChangeSphereColor(bottomSpheres[i], i);
        }
        upperSpheres[0].gameObject.GetComponent<Renderer>().material.color = colors[1];
        bottomSpheres[0].gameObject.GetComponent<Renderer>().material.color = colors[4];
        colorIndexes[0] = 3;
    }

    /// <summary>
    /// Deuelve si este minijuego está completado o no
    /// </summary>
    /// <returns><c>bool</c> Deuelve si este minijuego está completado o no</returns>
    static public bool sphereGamesIsComplete() {
        return completed;
    }

    /// <summary>
    /// Cambia el color de 4 esferas inferiores
    /// </summary>
    public void changeFourSpheres() {
        if (!completed) {
            audio.Play();
            changeSphereColor(bottomSpheres[0], 0);
            changeSphereColor(bottomSpheres[1], 1);
            changeSphereColor(bottomSpheres[2], 2);
            changeSphereColor(bottomSpheres[3], 3);
            checkSolution();
        }
    }


    /// <summary>
    /// Cambia el color de 3 esferas inferiores
    /// </summary>
    public void changeThreeSpheres() {
        if (!completed) {
            audio.Play();
            changeSphereColor(bottomSpheres[0], 0);
            changeSphereColor(bottomSpheres[2], 2);
            changeSphereColor(bottomSpheres[3], 3);
            checkSolution();
        }
    }

    /// <summary>
    /// Cambia el color de 2 esferas inferiores
    /// </summary>
    public void changeTwoSpheres() {
        if (!completed) {
            audio.Play();
            changeSphereColor(bottomSpheres[0], 0);
            changeSphereColor(bottomSpheres[3], 3);
            checkSolution();
        }
    }

    /// <summary>
    /// Cambia el color de 1 esfera inferior
    /// </summary>
    public void changeOneSphere() {
        if (!completed)
        {
            audio.Play();
            changeSphereColor(bottomSpheres[3], 3);
            checkSolution();
        }
    }

    /// <summary>
    /// Comprueba si el estado actual del juego consiste o no de una solución. Se comprueba cada vez que realizamos un movimiento.
    /// Actualizaos el score y comrobar si todos los colores de las esfera superiores son iguales a las de las inferiores.
    /// Si hay solución reproduce un sonido de aplausos usando altavozAplausos. Si el minijuego de Lines también ha sido completado
    /// los aplausos hacen un "fade out" disminuyendo su intensidad a medida que pasamos a un fundido a negro y abandonamos la sala
    /// </summary>
    private void checkSolution() {
        movementsMade++;
        if (movementsMade > 9) {
            GameInfo.IncreaseSecondScore(-1);
        }
        bool isSolution = true;
        for (int i = 0; i < bottomSpheres.Length; i++) {
            if (bottomSpheres[i].gameObject.GetComponent<Renderer>().material.color != upperSpheres[i].gameObject.GetComponent<Renderer>().material.color) {
                isSolution = false;
            }
        }
        if (isSolution) {
            completed = true;
            if (PanelsManagerScript.lineGameIsComplete()) {
                altavozAplausos.GetComponent<FinalSoundScript>().playClapsSound();
                GameInfo.CompleteSecondGame();
            } else{
                altavozAplausos.GetComponent<FinalSoundScript>().playClapsSoundWithoutFade();
            }
        }
    }

    /// <summary>
    /// Cammbia de manera completamente aleatoria el color de una esfera
    /// </summary>
    /// <param name="sphere">La esfer a la cual le vamos a cambiar el color</param>
    /// <param name="sphereIndex">El índice de la esfera en colorIndexes para actualizar a que posición de colors hace referencia su color</param>
    private void randomChangeSphereColor(GameObject sphere, int sphereIndex) {
        int randomNumber = Random.Range(0, colors.Length);
        colorIndexes[sphereIndex] = randomNumber;
        sphere.gameObject.GetComponent<Renderer>().material.color = colors[randomNumber];
    }

    /// <summary>
    /// Cammbia de manera no aleatoria aleatoria el color de una esfera.
    /// Se cambiará el color al siguiente color de colors. 
    /// Para ello hacemos uso de colorsIndexes para saber a que índice se corresponde el color actual de la esfera.
    /// </summary>
    /// <param name="sphere">La esfer a la cual le vamos a cambiar el color</param>
    /// <param name="sphereIndex">El índice de la esfera en colorIndexes para actualizar a que posición de colors hace referencia su color</param>
    private void changeSphereColor(GameObject sphere, int sphereIndex)
    {
        int colorIndex = colorIndexes[sphereIndex] + 1;
        if (colorIndex >= colors.Length)
        {
            colorIndex = 0;
        }
        colorIndexes[sphereIndex] = colorIndex;
        sphere.gameObject.GetComponent<Renderer>().material.color = colors[colorIndex];
    }

}
