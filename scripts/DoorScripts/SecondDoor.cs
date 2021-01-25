using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La clase <c>SecondDoor</c> administra el funcionamiento 
/// de la segunda puerta.
/// </summary>
public class SecondDoor : MonoBehaviour
{
    public Animator doorAnimator;

    /// <summary>
    /// Antes de que se ejecute el primer frame, recupera
    /// la animación de apertura de la segunda puerta y además
    /// suscribe el método OpenDoor al botón "SecondButton"
    /// para que cuando éste sea presionado, la animación se ejecute.
    /// </summary>
    void Start()
    {
        doorAnimator = GameObject.Find("door_2").GetComponent<Animator>();
        SecondButton.SecondButtonPressed += OpenDoor;
    }

    /// <summary>
    /// Ejecuta la animación de la puerta.
    /// </summary>
    void OpenDoor() {
        doorAnimator.Play("door_1_open");
    }

    /// <summary>
    /// Al destruir el objeto se desuscribe el método.
    /// </summary>
    void OnDestroy() {
        SecondButton.SecondButtonPressed -= OpenDoor;
    }
}
