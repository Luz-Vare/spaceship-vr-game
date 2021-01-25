using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La clase <c>LobbyButton</c> se asocia al boton que cambia la escena a la
/// escena principal.
/// </summary>
public class LobbyButton : MonoBehaviour
{
    private bool pressed;


    /// <summary>
    /// Cuando se detecta que el boton ha sido pulsado, se llama a la funcion
    /// para cambiar de escena.
    /// </summary>
    public void ButtonPressed() {
        if (!pressed) {
            SceneManagerScript.palLobby();
            pressed = true;
        }
    }
}
