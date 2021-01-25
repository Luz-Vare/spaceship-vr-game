using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La clase <c>WaveButton</c> se encarga de iniciar 
/// el juego. Por ello comienza la primera oleada de enemigos.
/// </summary>
public class WaveButton : MonoBehaviour
{
    private AudioSource buttonSound;
    private bool pressed;

    /// <summary>
    /// Inicialmente recuperamos el sonido que se va a reproducir
    /// cuando comience el juego.
    /// </summary>
    void Start()
    {
        buttonSound = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Esta función es llamada cuando presionamos Start,
    /// comenzamos la música, desde la clase principal
    /// iniciamos la primera oleada y nos aseguramos a través
    /// del bool "pressed" que no sea presionado nuevamente.
    /// </summary>
    public void ButtonPressed() {
        if (!pressed) {
            buttonSound.Play();
            StartCoroutine(GameObject.Find("SceneController").GetComponent<FourthGameScript>().StartWave());
            pressed = true;
        }        
    }
}
