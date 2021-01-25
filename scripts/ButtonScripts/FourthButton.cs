using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La clase <c>FourthButton</c> se asocia al boton que cambia la escena a la
/// del cuarto juego.
/// </summary>
public class FourthButton : MonoBehaviour {
    public delegate void ButtonDelegate();
    public static ButtonDelegate FourthButtonPressed;
    
    /// <summary>
    /// Cuando se detecta que el boton ha sido pulsado, se llama a la funcion
    /// para cambiar de escena.
    /// </summary>
    public void ButtonPressed() {
        if (FourthButtonPressed != null) {
            FourthButtonPressed();
        }
        SceneManagerScript.fourthGame();
    }
}
