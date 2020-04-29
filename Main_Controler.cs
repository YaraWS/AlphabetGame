using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main_Controler : MonoBehaviour
{
   public AudioSource audio_src;
   public AudioClip audio_play;
    public bool isPlaying;
    public float gameTimePlaying;
    public float gameTimePaused;
    public GameObject pausedPanel; 
    public Multiply_Lines multiply_lines;
    [Range(0,10)]
    public float volumeF;
    public AudioSource effectsAudioSource;
    public AudioClip effectsAudioClip;
    public ParticleSystem effectsParticle;

    public ParticleSystem letterEndedParticle;

    public AudioClip letterEndedClip;

    public AudioSource letterEndedAudioSrc;


    


    void Start()
    {
        Time.timeScale = gameTimePlaying; // Colocar o tempo na velocidade normal do jogo. 
        SetVolume();
    }
 public void Play()
    {
        Invoke("LoadPlay",1f);
        audio_src.PlayOneShot(audio_play); //Audio que so vai executar qnd tocar esse metodo e so vai tocar uma vez. 

    }
    // Update is called once per frame
    void Update()
    {
        if (isPlaying == false)

        {
            Time.timeScale = gameTimePaused;
            pausedPanel.SetActive(true);
            multiply_lines.enabled = false; // Desativar o script de desenho qnd for pausado. 
            
        }
        if (isPlaying == true)
        {
            Time.timeScale = gameTimePlaying;
            pausedPanel.SetActive(false);
            multiply_lines.enabled = true; // Ativar o script de desenho qnd nao pausado. 
                        
        }
                
    }

    public void PauseGame()
    {
        isPlaying = !isPlaying;

    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void SetVolume()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("mainVolume");

    }

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
    
    //Vai pegar a posicao do mouse, na posicao 10f que na camera seria 0. 
    public void LineFinishedEffects()
    {
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,10f));
        effectsParticle.transform.position = currentPosition;
        effectsAudioSource.PlayOneShot(effectsAudioClip);
        effectsParticle.Play();
    }

     public void Instantiate()
    {
        letterEndedParticle.Play();
        letterEndedAudioSrc.PlayOneShot(letterEndedClip);
        
       
    }
}
