using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La clase <c>LaserBeam</c> representa el láser que será disparado
/// desde la pistola.
/// </summary>
public class LaserBeam : MonoBehaviour
{
    /// <summary>
    /// Esta función es invocada desde la clase Pistol y lo que hace
    /// es crear una línea entre dos posiciones que son el orígen
    /// y el objetivo. Este láser se irá moviendo en un tiempo
    /// que hemos indicado hasta llegar al objetivo.
    /// </summary>
    public IEnumerator Shoot(Vector3 targetPosition) {
        Vector3 currentPos = transform.position;
        float time = 0f;
        while(time < 1) {
            time += Time.deltaTime / 0.15f;
            transform.position = Vector3.Lerp(currentPos, targetPosition, time);
            yield return null;
        }
        Destroy(this.gameObject);
    }
}
