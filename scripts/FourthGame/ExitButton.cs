using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La clase <c>ExitButton</c> representa el boton de salida de la sala.
/// </summary>
public class ExitButton : MonoBehaviour {
    private bool pressed;

    /// <summary>
    /// Cuando el jugador mira el botn, se ejecuta esta funcion. Una vez pulsado,
    /// Le indica al SceneController que debe pausar la musica y cambiar la
    /// escena a la principal.
    /// </summary>
    public void ButtonPressed() {
        if (!pressed) {
            StartCoroutine(GameObject.Find("SceneController").GetComponent<FourthGameScript>().FadeOutMusic());
            SceneManagerScript.palLobby();
            pressed = true;
        }
    }
}
