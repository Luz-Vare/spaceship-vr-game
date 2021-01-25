using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// <c>PanelsManagerScript</c> Este script controla toda la lógica principal del minijuego Lines.
/// Recibe petición de movimiento de los paneles, les responde si se puede mover o no y a dónde.
/// Mantiene en una matriz la posición de todos los paneles para saber el estado actual del videojuego.
/// Tras cada movimiento realizado comprueba si se ha encontrado solución o no
/// </summary>
public class PanelsManagerScript : MonoBehaviour {
    /// <summary>
    /// Localizaciones iniciales de los paneles del minijuego
    /// </summary>
    static private int[][] panelsLocation = {
        new int[] { 0, 0, 1 },
        new int[] { 0, -1, 0 },
        new int[] { 1, 0, 1}
    };

    /// <summary>
    /// Última fila a la que se movió el último panel. Esta información la leerán los paneles para desplazarse.
    /// </summary>
    static private int lastFinalRow;

    /// <summary>
    /// Última columna a la que se movió el último panel. Esta información la leerán los paneles para desplazarse.
    /// </summary>
    static private int lastFinalCol;

    /// <summary>
    /// Movimientos realizados en el minijuego
    /// </summary>
    static private int movementsMade = 0;

    /// <summary>
    /// Booleando que almacena si el minijuego ha sido o no completado
    /// </summary>
    static private bool completeLineGame;

    /// <summary>
    /// Una referencia a un gameobject que contiene <c>FinalSoundSCript</c> para reproducir aplausos cuando se completa el minijuego
    /// </summary>
    static private GameObject altavozAplausos;

    /// <summary>
    /// Definimos las posiciones iniciales de los paneles, además de poner el estado del juego a no completado y
    /// encontrar la referencia al gameObject que reproducirá los aplausos al completar el minijuego
    /// </summary>
    void Start() {
        altavozAplausos = GameObject.FindGameObjectsWithTag("secondGameAplausos")[0];
        GameInfo.IncreaseSecondScore(99);
        for (int i = 0; i < panelsLocation.Length; i++) {
            for (int j = 0; j < panelsLocation.Length; j++) {
                panelsLocation[i][j] = 0;
            }
        }
        panelsLocation[1][1] = -1;
        panelsLocation[0][2] = 1;
        panelsLocation[2][0] = 1;
        panelsLocation[2][2] = 1;
        movementsMade = 0;
        completeLineGame = false;
    }

    /// <summary>
    /// Devuelve el último movimiento realizado para que los paneles sepan a dónde deben desplazarse
    /// </summary>
    /// <returns><c>int[]</c> Fila y columna a donde deben desplazarse los paneles</returns>
    public static int[] getLastMovement() {
        return new int[] { lastFinalRow, lastFinalCol };
    }

    /// <summary>
    /// Devuelve si el minijuego está completo o no
    /// </summary>
    /// <returns><c>bool</c> Devuelve si el minijuego está completo o no</returns>
    public static bool lineGameIsComplete() {
        return completeLineGame;
    }

    /// <summary>
    /// Recibe una petición para mover un panel
    /// </summary>
    /// <param name="row"> Fila del panel que realiza la petición</param>
    /// <param name="col"> Columna del panel que realiza la petición</param>
    /// <param name="isLine"> Indica si el panel es del tipo Línea o Base (true => tipo línea)</param>
    /// <returns><c>bool</c> true si se puede mover el panel. False en otro caso</returns>
    public static bool movePanel (int row, int col, bool isLine)
    {
        int panelType = 0;
        const int emptyPanelType = -1;
        if (isLine)
        {
            panelType = 1;
        }
        if (panelsLocation[row][col] == emptyPanelType)
        {
            Debug.Log("ERROR. Intentando desplazar un panel que no está bien localizado ");
            return false;
        }
        if (panelsLocation[row][col] == 0 && isLine)
        {
            Debug.Log("ERROR. Se ha tratado de mover un panel clasificado como con linea pero está registrado cono plano base");
            return false;
        }
        if (panelsLocation[row][col] == 1 && !isLine)
        {
            Debug.Log("ERROR. Se ha tratado de mover un panel clasificado como base pero está registrado como con linea");
            return false;
        }

        // Can move left?
        if (row > 0)
        {
            if (checkAndMove(row, col, row -1, col, panelType))
            {
                return true;
            }
        }
        // Can move right?
        if (row < panelsLocation.Length - 1)
        {
            if (checkAndMove(row, col, row + 1, col, panelType))
            {
                return true;
            }
        }
        // Can move bottom?
        if (col > 0)
        {
            if (checkAndMove(row, col, row, col - 1, panelType))
            {
                return true;
            }
        }
        // Can move upwards?
        if (col < panelsLocation[row].Length - 1)
        {
            if (checkAndMove(row, col, row, col + 1, panelType))
            {
                return true;
            }
        }
        return false;
    }


    /// <summary>
    /// Método privado que comrpueba si un panel se muede mover a una posición determinada y,
    /// si es así. realiza el movimiento en el estado interno del minijuego
    /// </summary>
    /// <param name="originalRow"> fila de partida</param>
    /// <param name="originalCol"> columna de partida</param>
    /// <param name="finalRow"> fila destino</param>
    /// <param name="finalCol"> columna destino</param>
    /// <param name="panelType"> tipo de panel que se va a desplazar (0 tipo base, 1 tipo línea)</param>
    /// <returns><c>bool</c> true si se puede y ha realizado el movimiento. False otro caso</returns>
    private static bool checkAndMove(int originalRow, int originalCol, int finalRow, int finalCol, int panelType)
    {
        const int emptyPanelType = -1;
        if (panelsLocation[finalRow][finalCol] == emptyPanelType)
        {
            panelsLocation[originalRow][originalCol] = emptyPanelType;
            panelsLocation[finalRow][finalCol] = panelType;
            lastFinalCol = finalCol;
            lastFinalRow = finalRow;
            movementsMade++;
            if (movementsMade > 9)
            {
                GameInfo.IncreaseSecondScore(-1);
            }
            checkSolution();
            return true;
        }
        return false;
    }

    /// <summary>
    /// Tras cada movimiento detecta si se ha completado el minijuego. Si es así reproduce un sondio de aplausos
    /// usando altavozAplausos, pone el bool de completeLineGame a true, y si el minijuego de esferas también ha sido completado
    /// finaliza este nivel o sala llamando a GameInfo.CompleteSecondGame();
    /// </summary>
    private static void checkSolution()
    {
        if (panelsLocation[1][0] == 1 && panelsLocation[1][1] == 1 && panelsLocation[1][2] == 1)
        {
            completeLineGame = true;
            if (SphereManagerScript.sphereGamesIsComplete())
            {
                altavozAplausos.GetComponent<FinalSoundScript>().playClapsSound();
                GameInfo.CompleteSecondGame();
            } else
            {
                altavozAplausos.GetComponent<FinalSoundScript>().playClapsSoundWithoutFade();
            }
        }
    }
}
