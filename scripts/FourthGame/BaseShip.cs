using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La clase <c>BaseShip</c> representa un enemigo al que el jugador dispara.
/// </summary>
public class BaseShip : MonoBehaviour {
    /// <summary>
    /// Se ejecuta antes de actualizar el primer frame. Cuando se crea una
    /// instancia, esta rota para que mire al jugador.
    /// </summary>
    void Start() {
        transform.LookAt(GameObject.Find("Player").transform);
    }

    /// <summary>
    /// Esta funcion se ejecuta cuando el jugador mira a una instancia de un
    /// enemigo. Le indica a la pistola que tiene que disparar hacia su posicion,
    /// incrementa la puntuacion y posteriormente se destruye.
    /// </summary>
    public void IsDestroyed() {
        GameObject.Find("Pistol").GetComponent<Pistol>().Shoot(transform.position);
        GameObject.Find("SceneController").GetComponent<FourthGameScript>().IncreaseScore();
        Destroy(this.gameObject);
    }
}
