using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// La clase <c>FinalSoundScript</c> está asociado a un objeto que simplemente reproducirá
/// un sonido de aplausos cuando completemos un minijuego
/// </summary>
public class FinalSoundScript : MonoBehaviour
{
    private AudioSource clapsSound;

    /// <summary>
    /// Se ejecuta antes de que se actualice el primer frame.
    /// Pillamos la referencia al audioSource asociado al gameObject
    /// </summary>
    void Start() {
        clapsSound = GetComponent<AudioSource>();
    }

    
    /// /// <summary>
    /// Simiar a playClapsSoundWihtoutFade pero el sonido de aplausos va bajando su volumen en un Fade out.
    /// Esto sirve cuando ambos minijuegos se han completado, para que los aplausos no se corten repentinamente al salir de la sala.
    /// </summary>
    public void playClapsSound() {
        clapsSound.Play();
        StartCoroutine(FadeOutMusic());
    }

    /// <summary>
    /// Esta función es llamada desde los controladores de el minijuego Spheres y de el juego Lines.
    /// Simplemente reproduce el sonido de aplausos cuando un minijuego es completado
    /// </summary>
    public void playClapsSoundWithoutFade()
    {
        clapsSound.Play();
    }

    /// <summary>
    /// Este método auxiliar nos sirve para ejecutar la Coroutine que va bajando el volumen de los aplausos gradualmente
    /// </summary>
    /// <returns><c>IEnumerator</c> Los métodos de coroutine deben devolverlo para saber en que punto de la ejeución estaba</returns>
    public IEnumerator FadeOutMusic()
    {
        float startVolume = clapsSound.volume;
        while (clapsSound.volume > 0)
        {
            clapsSound.volume -= startVolume * Time.deltaTime / 1.5f;
            yield return null;
        }
    }
}
