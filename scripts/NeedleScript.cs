using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La clase <c>NeedleScript</c> determina el comportamiento de la aguja de la
/// brujula en la UI, para que se mueva segun indique el compas del telefono.
/// </summary>
public class NeedleScript : MonoBehaviour {
    /// <summary>
    /// Se llama antes de que se actualice el primer frame. Activa el compas en
    /// telefono.
    /// </summary>
    void Start() {
        Input.compass.enabled = true;
        Input.location.Start();
    }

    /// <summary>
    /// Se llama una vez en cada frame. Actualiza la posicion de la aguja,
    /// rotandola segun indica el compas.
    /// </summary>
    void Update() {
        transform.localRotation = Quaternion.Euler(0, 0, Input.compass.trueHeading);
    }
}
