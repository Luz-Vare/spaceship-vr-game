using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// La clase <c>ThirdGameController</c> controla el funcionamiento
/// Del juego MathPuzzle. 
/// </summary>
public class ThirdGameController : MonoBehaviour
{
    public bool started_;
    public int cubes_;
    public int steps_ = 0;
    public int minimumSteps_ = 0;


    /// <summary>
    /// Resetea la variable que almacena la incognita que debe
    /// descubrir el usuario, además resetea el número mínimo 
    /// de pasos que debe dar y los pasos actuales que lleva
    /// el usuario.
    /// </summary>
    void Start()
    {
        cubes_ = 0;
        steps_ = 0;
        minimumSteps_ = 0;
    }

    /// <summary>
    /// Este método genera la ecuacion que debe resolver el usuario,
    /// tiene limitado el valor que puede tomar la incógnita a un
    /// valor aleatorio entre el 1 y el 10. Además se encarga de 
    /// mostrar la ecuación en el juego y de calcular el mínimo 
    /// número de pasos que ha de dar el usuario para resolver el puzle. 
    /// </summary>
    public void GenerateSolution(){
        GameObject.Find("ThirdGameController").GetComponents<AudioSource>()[1].Play();
        started_ = true;
        cubes_ = UnityEngine.Random.Range(1, 11);
        //a*cubes+b*spheres = data1
        int a = UnityEngine.Random.Range(1, 6);
        int b = UnityEngine.Random.Range(1, 6);
        int data1 = a*cubes_+b;

        GameObject.Find("ProblemX1").GetComponent<TextMesh>().text = "" + a +"x";
        GameObject.Find("ProblemY1").GetComponent<TextMesh>().text = "" + b;
        GameObject.Find("ProblemData1").GetComponent<TextMesh>().text = "" + data1;

        //To String convierte el numero a string en la base que le digas
        string binarySolution = Convert.ToString(cubes_, 2);

        foreach (char character in binarySolution){
            if(character == '1'){
                minimumSteps_++;
            }
        }
    }

    /// <summary>
    /// Este método revisa la solución que introduce el usuario
    /// y comprueba si esta es correcta o no. Si es correcta lanza
    /// el FadeOutMusic para que la música se detenga adecuadamente
    /// </summary>
    public void checkSolution(){
        int solution = 0;
        if ( Bit0.state_ ){
            solution+=1;
        }

        if ( Bit1.state_ ){
            solution+=2;
        }

        if ( Bit2.state_ ){
            solution+=4;
        }

        if ( Bit3.state_ ){
            solution+=8;
        }

        if(solution == cubes_){
            StartCoroutine(FadeOutMusic(1));
            GetComponents<AudioSource>()[0].Play();
            StartCoroutine(FadeOutMusic(0));
            started_ = false;
            GameInfo.CompleteThirdGame();
        }
    }

    /// <summary>
    /// Este método baja poco a poco el volumen de la música
    /// para que se detenga suavemente.
    /// </summary>
    public IEnumerator FadeOutMusic(int index) {
        AudioSource music = GameObject.Find("ThirdGameController").GetComponents<AudioSource>()[index];
        float startVolume = music.volume;
        while (music.volume > 0) {
            music.volume -= startVolume * Time.deltaTime / 1.5f;
            yield return null;
        }
    }
}
