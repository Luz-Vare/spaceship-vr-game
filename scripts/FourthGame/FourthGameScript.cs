using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La clase <c>FourthGameScript</c> es la principal encargada de controlar el
/// cuarto juego. Crea los enemigos, controla las luces y maneja la puntuacion
/// del jugador.
/// </summary>
public class FourthGameScript : MonoBehaviour {
    public GameObject baseShip;
    private bool waveActive;
    private GameObject[] ships;
    private int numberEnemies;
    private AudioSource roundStart;
    private int score;

    /// <summary>
    /// Se ejecuta antes de actualizar el primer frame. Establece el numero de
    /// enemigos a crear en cada ronda y crea un array para almacenarlos, asi
    /// como que almacena la musica de fondo.
    /// </summary>
    void Start() {
        roundStart = GetComponent<AudioSource>();
        numberEnemies = 3;
        ships = new GameObject[numberEnemies];
    }

    /// <summary>
    /// Esta funcion se ejecuta cuando el jugador pulsa el boton pàra empezar el
    /// juego. Activa las luces de emergencia, y posteriormente, ada 4 segundos
    /// crea un enemigo en cada spawner (3 areas delimitadas). Una vez pasados
    /// esos 4 segundos, elimina los enemigos que sigan con vida y vuelve a
    /// crear unos nuevos.
    /// </summary>
    public IEnumerator StartWave() {
        roundStart.Play();
        ActivateEmergencyLights();
        yield return new WaitForSeconds(1f);    
        if (!waveActive) {
            while(true){
                
                // First Spawner
                float xPos = Random.Range(-5.8f, -2.1f);
                float yPos = Random.Range(1.5f, 3f);
                float zPos = Random.Range(-1.91f, 1.91f);
                ships[0] = Instantiate(baseShip, new Vector3(xPos, yPos, zPos), Quaternion.identity);

                // Second Spawner
                xPos = Random.Range(2.1f, 5.8f);
                yPos = Random.Range(1.5f, 3f);
                zPos = Random.Range(-1.91f, 1.91f);
                ships[1] = Instantiate(baseShip, new Vector3(xPos, yPos, zPos), Quaternion.identity);

                // Third Spawner
                xPos = Random.Range(-1.7f, 1.7f);
                yPos = Random.Range(1.5f, 3f);
                zPos = Random.Range(-2.2f, -5.5f);
                ships[2] = Instantiate(baseShip, new Vector3(xPos, yPos, zPos), Quaternion.identity);

                waveActive = true;
                yield return new WaitForSeconds(4f);
                ClearWave();
            }
        }
    }

    /// <summary>
    /// Reduce el volumen de la musica de fondo para hacer la transicion de
    /// escena a lo largo de un segundo y medio.
    /// </summary>
    public IEnumerator FadeOutMusic() {
        float startVolume = roundStart.volume;
        while (roundStart.volume > 0) {
            roundStart.volume -= startVolume * Time.deltaTime / 1.5f;
            yield return null;
        }
    }

    /// <summary>
    /// Detecta si no hay enemigos vivos.
    /// </summary>
    /// <returns>True si no hay enemigos, y false si hay alguno.</returns>
    private bool NoShips() {
        for (int i = 0; i < numberEnemies; i++) {
            if (ships[i] != null) {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Elimina del array todas las instancias de enemigos que sigan con vida
    /// cuando acaba la ronda para crear otros nuevos.
    /// </summary>
    private void ClearWave() {
        for (int i = 0; i < numberEnemies; i++) {
            if (ships[i] != null) {
                Destroy(ships[i]);
            }
        }
    }

    /// <summary>
    /// Cambia el color de emision de las luces de la sala a rojo. Esta funcion
    /// se ejecuta al empezar a aparecer enemigos.
    /// </summary>
    public void ActivateEmergencyLights() {
        GameObject emergencyLights = GameObject.Find("EmergencyLights");
        foreach(Transform light in emergencyLights.transform) {
            light.gameObject.GetComponent<Renderer>().materials[1].SetColor("_EmissionColor", Color.red);
            light.gameObject.GetComponent<Renderer>().materials[1].SetColor("_Color", Color.red);
        }
    }

    /// <summary>
    /// Vuelve a poner el color de emision de las luces a blanco. Se ejecuta
    /// cuando se acaba el juego.
    /// </summary>
    public void ResetEmergencyLights() {
        GameObject emergencyLights = GameObject.Find("EmergencyLights");
        foreach(Transform light in emergencyLights.transform) {
            light.gameObject.GetComponent<Renderer>().materials[1].SetColor("_EmissionColor", Color.white);
            light.gameObject.GetComponent<Renderer>().materials[1].SetColor("_Color", Color.white);
        }
    }

    /// <summary>
    /// Incrementa la puntuacion del jugador en 1 y comprueba si se ha alcanzado
    /// la puntuacion de 18, dando por finalizado el juego.
    /// </summary>
    public void IncreaseScore() {
        score += 1;
        GameInfo.IncreaseFourthScore(1);
        if (score == 18) {
            StartCoroutine(FadeOutMusic());
            ResetEmergencyLights();
            GameInfo.CompleteFourthGame();
        }
    }
}
