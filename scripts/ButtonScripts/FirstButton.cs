using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La clase <c>FirstButton</c> se asocia al boton que cambia la escena a la
/// del primer juego.
/// </summary>
public class FirstButton : MonoBehaviour {
    public delegate void ButtonDelegate();
    public static ButtonDelegate FirstButtonPressed;

    /// <summary>
    /// Cuando se detecta que el boton ha sido pulsado, se llama a la funcion
    /// para cambiar de escena.
    /// </summary>
    public void ButtonPressed() {
        if (FirstButtonPressed != null) {
            FirstButtonPressed();
        }
        SceneManagerScript.firstGame();
    }
}
