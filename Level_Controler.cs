using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Para poder usar os componentes da interface no script.
using UnityEngine.SceneManagement; // Declaracao serve para fazer as trocas de scena. 

public class Level_Controler : MonoBehaviour
{
    public AudioSource audio_src;

    public AudioClip audio_play;


    void Start()
    {
        
    }

    public void Play()
    {
        Invoke("LoadPlay",1f);
        audio_src.PlayOneShot(audio_play); //Audio que so vai executar qnd tocar esse metodo e so vai tocar uma vez. 

    }

    public void Easy() //Used to be credits
    {
        SceneManager.LoadScene("Easy");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
 

    public void LoadPlay()  // metodo para tocar audio por 1s. Criar um metodo diferente para cada som diferente. 
    {
        SceneManager.LoadScene("Main"); 


    }
    
    
}
