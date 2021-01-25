using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La clase <c>VictoryMusic</c> se encarga de controlar la reproduccion de
/// una cancion cuando se completen todos los mini-juegos.
/// </summary>
public class VictoryMusic : MonoBehaviour {
    public static VictoryMusic victoryMusic;
    private static bool firstLoad;
    private static float initialVolume;

    /// <summary>
    /// Se llama antes de que se actualice el primer frame. Evita que se
    /// destruya al cargar la escena, manteniendo asi una unica instancia. Y se
    /// suscribe al evento para reproducir la musica, o para pararla.
    /// </summary>
    void Start() {
        if (victoryMusic == null) {
            victoryMusic = this;
            DontDestroyOnLoad(this);
        } else if (victoryMusic != this) {
            Destroy(gameObject);
        }
        if (!firstLoad) {
            SceneManagerScript.AllCompleted += PlayMusic;
            SceneManagerScript.ExitMain += FadeMusic;
            initialVolume = GetComponent<AudioSource>().volume;
            firstLoad = true;
        }
    }

    /// <summary>
    /// Empieza a reproducir la musica.
    /// </summary>
    void PlayMusic() {
        GetComponent<AudioSource>().volume = initialVolume;
        GetComponent<AudioSource>().Play();
    }

    /// <summary>
    /// Comienza la corrutina que va disminuyendo el volumen de la musica hasta
    /// que la para.
    /// </summary>
    void FadeMusic() {
        StartCoroutine(FadeOut());
    }

    /// <summary>
    /// Va reduciendo el volumen de la musica a lo largo de un segundo y medio,
    /// hasta parar su reproduccion.
    /// </summary>
    IEnumerator FadeOut() {
        AudioSource music = GetComponent<AudioSource>();
        while (music.volume > 0) {
            music.volume -= initialVolume * Time.deltaTime / 1.5f;
            yield return null;
        }
        music.Stop();
    }

    /// <summary>
    /// Cuando se destruye, se desuscribe del evento.
    /// </summary>
    void OnDestroy() {
        SceneManagerScript.AllCompleted -= PlayMusic;
    }
}
