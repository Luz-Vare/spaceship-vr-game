using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// La clase <c>BasePanelScript</c> está asociado a cada panel sin linea
/// y detecta cuando se pasa la mirada por el panel y realiza la petición correspondiente.
/// </summary>
public class BasePanelScript : MonoBehaviour {
    private AudioSource audio;

    /// <summary>
    /// Se ejecuta antes de que se actualice el primer frame.
    /// Pillamos la referencia al audioSource asociado al panel
    /// </summary>
    void Start() {
        audio = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Se llama cuando pasamos la mirada por encima de este panel. 
    /// Realiza una petición a <c>PanelManagerScript</c> para desplazar este panel a un hueco vacío.
    /// Siempre y cuando el juego no haya sido completado y haya un hueco pegado a este panel (arriba, abajo, izquierda, o derecha)
    /// </summary>
    public void moveThisPanel() {
        int row = (int)transform.localPosition[1];
        int col = (int)transform.localPosition[0];
        if (PanelsManagerScript.lineGameIsComplete() == false) {
            if (PanelsManagerScript.movePanel(row, col, false)) {
                int[] move = PanelsManagerScript.getLastMovement();
                transform.localPosition = new Vector3(move[1], move[0], transform.localPosition.z);
                audio.Play();
            }
        }

    }
}
