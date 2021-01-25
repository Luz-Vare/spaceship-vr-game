using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La clase <c>Pistol</c> implementa las funcionalidades
/// de la pistola del juego.
/// </summary>
public class Pistol : MonoBehaviour
{
    private AudioSource shootSound;
    public GameObject laser;

    /// <summary>
    /// Inicialmente recuperamos el sonido que la pistola tiene
    /// asignado, que se reproducirá con cada disparo.
    /// </summary>
    void Start()
    {
        shootSound = GetComponent<AudioSource>();
    }

    /// <summary>
    /// La función shoot, recibe la posición del objetivo al que vamos a disparar.
    /// Primero reproduce el sonido de la pistola láser. Y luego instancia el láser
    /// que se verá como una luz azul que sale de la misma. 
    /// </summary>
    public void Shoot(Vector3 targetPosition) {
        shootSound.Play();
        StartCoroutine(Instantiate(laser, transform.position, transform.rotation).GetComponent<LaserBeam>().Shoot(targetPosition));
    }
}
