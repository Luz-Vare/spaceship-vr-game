using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La clase <c>FirstDoor</c> administra el funcionamiento 
/// de la primera puerta.
/// </summary>
public class FirstDoor : MonoBehaviour
{
    public Animator doorAnimator;

    /// <summary>
    /// Antes de que se ejecute el primer frame, recupera
    /// la animación de apertura de la primera puerta y además
    /// suscribe el método OpenDoor al botón "FirstButton"
    /// para que cuando éste sea presionado, la animación se ejecute.
    /// </summary>
    void Start() {
        doorAnimator = GameObject.Find("door_1").GetComponent<Animator>();
        FirstButton.FirstButtonPressed += OpenDoor;
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
        FirstButton.FirstButtonPressed -= OpenDoor;
    }
}
