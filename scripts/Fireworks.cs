using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// La clase <c>Fireworks</c> controla la activacion de un sistema de particulas
/// mediante la deteccion de un evento.
/// </summary>
public class Fireworks : MonoBehaviour {
    public static bool changedScene = false;

    /// <summary>
    /// Se ejecuta antes de que se actualice el primer frame. Si se ha cambiado
    /// de escena, se destruye la instancia para evitar que haya mas de un
    /// sistema de particulas.
    /// </summary>
    void Start() {
        if (changedScene) {
            Destroy(this.gameObject);
        } else {
            SceneManagerScript.AllCompleted += PlayFireworks;
            DontDestroyOnLoad(this);
        }
    }

    /// <summary>
    /// Se activa el sistema de particulas cuando se lanza el evento
    /// "AllCompleted".
    /// </summary>
    void PlayFireworks() {
        transform.GetChild(0).GetChild(0).gameObject.GetComponent<ParticleSystem>().Play();
    }

    /// <summary>
    /// Cuando se destruye, se desuscribe del evento.
    /// </summary>
    void OnDestroy() {
        SceneManagerScript.AllCompleted -= PlayFireworks;
    }
}
