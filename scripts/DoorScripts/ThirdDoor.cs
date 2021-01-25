using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La clase <c>ThirdDoor</c> administra el funcionamiento 
/// de la tercera puerta.
/// </summary>
public class ThirdDoor : MonoBehaviour
{
    public Animator doorAnimator;

    /// <summary>
    /// Antes de que se ejecute el primer frame, recupera
    /// la animación de apertura de la tercera puerta y además
    /// suscribe el método OpenDoor al botón "ThirdButton"
    /// para que cuando éste sea presionado, la animación se ejecute.
    /// </summary>
    void Start()
    {
        doorAnimator = GameObject.Find("door_3").GetComponent<Animator>();
        ThirdButton.ThirdButtonPressed += OpenDoor;
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
        ThirdButton.ThirdButtonPressed -= OpenDoor;
    }
}
