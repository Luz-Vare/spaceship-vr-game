using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// <c>LinePanelsScript</c> es una clase muy similar a <c>BasePanelScript</c>.
/// Esta asociada a cada panel con linea en el medio, detecta cuando pasamos el ratón por encima
/// para enviar una petición de moverse a <c>PanelsManagerScript</c> Además, si se desplaza cambiará el color
/// de la línea dependiendo si está o no en la fila "central"
/// </summary>
public class LinePanelsScript : MonoBehaviour
{
    private AudioSource audio;
    private Color originalColor;

    /// <summary>
    /// Cogemos la referencia al auido que vamos a reproducir cuando movemos panel así como al
    /// color que tiene el panel de base
    /// </summary>
    void Start() {
        audio = GetComponent<AudioSource>();
        originalColor = transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color;
    }

    /// <summary>
    /// Cuando pasamos el puntero por encima del panel, se llamam a este método. Envía una petición a
    /// <c>PanelsManagerScript</c> para moverse a un hueco cercano, si existiese, dentro del juego.
    /// Si consigue moverse reproduce un sonido y actualiza el color de su linea dependiendo si su nueva posición
    /// es en la línea central o no
    /// </summary>
    public void moveThisPanel()
    {
        int row = (int)transform.localPosition[1];
        int col = (int)transform.localPosition[0];
        if (PanelsManagerScript.lineGameIsComplete() == false)
        {
            if (PanelsManagerScript.movePanel(row, col, true))
            {
                int[] move = PanelsManagerScript.getLastMovement();
                transform.localPosition = new Vector3(move[1], move[0], transform.localPosition.z);
                audio.Play();
                if (move[0] == 1)
                {
                    transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = Color.white;
                }
                else
                {
                    transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = originalColor;
                }
            }
        }

    }
}
