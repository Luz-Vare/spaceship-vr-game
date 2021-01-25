using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La clase <c>SecondButton</c> se asocia al boton que cambia la escena a la
/// del segundo juego.
/// </summary>
public class SecondButton : MonoBehaviour {
    public delegate void ButtonDelegate();
    public static ButtonDelegate SecondButtonPressed;

    /// <summary>
    /// Cuando se detecta que el boton ha sido pulsado, se llama a la funcion
    /// para cambiar de escena.
    /// </summary>
    public void ButtonPressed() {
        if (SecondButtonPressed != null) {
            SecondButtonPressed();
        }
        SceneManagerScript.secondGame();
    }
}
