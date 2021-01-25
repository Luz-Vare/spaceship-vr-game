using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// La clase <c>StartButton</c> controla el funcionamiento
/// del botón que inicia el juego. 
/// </summary>
public class StartButton : MonoBehaviour
{

    /// <summary>
    /// Este método se encarga de avisar al ThirdGameController
    /// cuando el usuario ha pulsado el botón de iniciar el 
    /// minijuego, después del aviso se destruye así mismo
    /// para eliminar el texto "Start"
    /// </summary>
    public void startGame(){
        GameObject.Find("ThirdGameController").GetComponent<ThirdGameController>().GenerateSolution();
        Destroy(this.gameObject);
    }
}
