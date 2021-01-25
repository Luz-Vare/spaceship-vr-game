using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La clase <c>ThirdButton</c> se asocia al boton que cambia la escena a la
/// del tercer juego.
/// </summary>
public class ThirdButton : MonoBehaviour {
    public delegate void ButtonDelegate();
    public static ButtonDelegate ThirdButtonPressed;

    /// <summary>
    /// Cuando se detecta que el boton ha sido pulsado, se llama a la funcion
    /// para cambiar de escena.
    /// </summary>
    public void ButtonPressed() {
        if (ThirdButtonPressed != null) {
            ThirdButtonPressed();
        }
        SceneManagerScript.thirdGame();
    }
}
