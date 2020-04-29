using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Easy_Controler : MonoBehaviour
{
   public AudioSource audio_src;
   public AudioClip audio_play;
    public bool isPlaying;
    public float gameTimePlaying;
    public float gameTimePaused;
    public GameObject pausedPanel; 
    public Multiply_Lines multiply_lines;
    


    void Start()
    {
        Time.timeScale = gameTimePlaying; // Colocar o tempo na velocidade normal do jogo. 
        
    }
 public void Play() //Audio for the Play button
    {
        Invoke("LoadPlay",1f);
        audio_src.PlayOneShot(audio_play); 

    }
    // Update is called once per frame
    void Update()
    {
        if (isPlaying == false)

        {
            Time.timeScale = gameTimePaused;
            pausedPanel.SetActive(true);
            multiply_lines.enabled = false; // Desactive the drawing script when it is paused. 
            
        }
        if (isPlaying == true)
        {
            Time.timeScale = gameTimePlaying;
            pausedPanel.SetActive(false);
            multiply_lines.enabled = true; // Active the drawing script when it is not paused.
                        
        }
                
    }

    //Method to pause the game.
    public void PauseGame()
    {
        isPlaying = !isPlaying;

    }

    //Method to load the Scene Menu.
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
