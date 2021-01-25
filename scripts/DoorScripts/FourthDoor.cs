using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La clase <c>FourthDoor</c> administra el funcionamiento 
/// de la cuarta puerta.
/// </summary>
public class FourthDoor : MonoBehaviour
{
    public Animator doorAnimator;

    /// <summary>
    /// Antes de que se ejecute el primer frame, recupera
    /// la animación de apertura de la cuarta puerta y además
    /// suscribe el método OpenDoor al botón "FourthButton"
    /// para que cuando éste sea presionado, la animación se ejecute.
    /// </summary>
    void Start()
    {
        doorAnimator = GameObject.Find("door_4").GetComponent<Animator>();
        FourthButton.FourthButtonPressed += OpenDoor;
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
        FourthButton.FourthButtonPressed -= OpenDoor;
    }
}
