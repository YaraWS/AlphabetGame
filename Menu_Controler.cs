using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Para poder usar os componentes da interface no script.
using UnityEngine.SceneManagement; // Declaracao serve para fazer as trocas de scena. 

public class Menu_Controler : MonoBehaviour
{
    public AudioSource audio_src;

    public AudioClip audio_play;

    public float volumeF;


    void Start() // Esse if vai verificar se existe um volume no prefs, se existir o metodo vai ignorar, caso contrario vai. 
    {
        if (!PlayerPrefs.HasKey("mainVolume"))
        {
            PlayerPrefs.SetFloat("mainVolume", 1);
            
        }
        AudioListener.volume = PlayerPrefs.GetFloat("mainVolume");
    }

    public void Play()
    {
        Invoke("LoadPlay",1f);
        audio_src.PlayOneShot(audio_play); //Audio que so vai executar qnd tocar esse metodo e so vai tocar uma vez. 

    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Quit()  // O metodo para sair do jogo 'e diferente dos outros metodos. 
        {
            Application.Quit();
        }

    public void LoadPlay()  // metodo para tocar audio por 1s. Criar um metodo diferente para cada som diferente. 
    {
        SceneManager.LoadScene("Main"); 


    }

    ////////

     public void UpVolume(float value)
    {
        if (volumeF < 10)
        {
            volumeF = PlayerPrefs.GetFloat("mainVolume")+ value;
        }
         PlayerPrefs.SetFloat("mainVolume",volumeF);
         SetVolume();
    }

    public void DownVolume(float value)
    {
        if (volumeF > 0)
        {
            volumeF = PlayerPrefs.GetFloat("mainVolume")- value;
        }
         PlayerPrefs.SetFloat("mainVolume",volumeF);
         SetVolume();
    }

    public void MuteVolume()
    {
        PlayerPrefs.SetFloat("mainVolume", 0);
        SetVolume();
    }
   
   private void SetVolume()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("mainVolume");

    }
    
    
}
