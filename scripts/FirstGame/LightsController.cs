using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La clase <c>LightsController</c> administra la intensidad
/// de las luces cuando pasamos sobre ellas.
/// </summary>
public class LightsController : MonoBehaviour
{
    /// <summary>
    /// Apaga la luz cuando salimos del botón.
    /// </summary>
    public void LightOff()
    {
      GetComponent<Light>().intensity = 0f;
    }
    /// <summary>
    /// Enciende la luz cuando entramos al botón
    /// </summary>
    public void LightOn()
    {
      GetComponent<Light>().intensity = 1.50f;
    }
}
