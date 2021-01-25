using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// La clase <c>Bit1</c> controla el funcionamiento
/// del segundo bit donde el usuario introduce su solución. 
/// </summary>
public class Bit1 : MonoBehaviour
{
    public static bool state_;
    private AudioSource audioTrue_;
    private AudioSource audioFalse_;

    /// <summary>
    /// Se ejecuta justo en el primer frame de la escena, establece 
    /// el valor del estado del bit a false y coloca el color de la
    /// luz del bit en cuestión en azul, además almacena en los atributos
    /// correspondientes los dos sonidos que tienen los cubos.
    /// </summary>
    void Start()
    {
        state_ = false;
        gameObject.GetComponent<Renderer>().materials[1].SetColor("_EmissionColor", Color.cyan);
        audioTrue_ = GetComponents<AudioSource>()[0];
        audioFalse_ = GetComponents<AudioSource>()[1];
    }

    /// <summary>
    /// Este método comprueba si el juego ha iniciado, si es así,
    /// cambia el estado del cubo actual y aumenta la cantidad de 
    /// pasos que ha dado el usuario, si es mayor que el número
    /// mínimo, decrece en 1 unidad el score del jugador.
    /// Además reproduce los sonidos correspondientes al cambio de
    /// estado y coloca el cubo en el color correspondiente.
    /// Este método es llamado por el cubo cuando el usuario lo activa.
    /// </summary>
    public void chageState(){
        ThirdGameController thirdGameScript = GameObject.Find("ThirdGameController").GetComponent<ThirdGameController>();
        if(thirdGameScript.started_){
            state_ = !state_;
            thirdGameScript.steps_++;
            if (thirdGameScript.steps_ > thirdGameScript.minimumSteps_){
                GameInfo.IncreaseThirdScore(1);
            }else{
                GameInfo.IncreaseThirdScore(0);
            }
            if(state_){
                gameObject.GetComponent<Renderer>().materials[1].SetColor("_EmissionColor", new Color(255,136,0));
                audioTrue_.Play();
            }else{
                gameObject.GetComponent<Renderer>().materials[1].SetColor("_EmissionColor", Color.cyan);
                audioFalse_.Play();
            }

            thirdGameScript.checkSolution();
        }
    }


}
