using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// La clase <c>ExitButtonThirdGame</c> controla el funcionamiento
/// del botón que hace al jugador salir del juego. 
/// </summary>
public class ExitButtonThirdGame : MonoBehaviour
{
    private bool pressed;

    /// <summary>
    /// Este método se encarga de avisar al ThirdGameController
    /// cuando el usuario ha pulsado el botón de salir del 
    /// minijuego para que haga FadeOutMusic. Después del aviso,
    /// envía al jugador al Lobby.
    /// </summary>
    public void ButtonPressed() {
        if (!pressed) {
            StartCoroutine(GameObject.Find("ThirdGameController").GetComponent<ThirdGameController>().FadeOutMusic(1));
            SceneManagerScript.palLobby();
            pressed = true;
        }
    }
}
