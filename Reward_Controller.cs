using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Reward_Controller : MonoBehaviour
{
    
    public GameObject rewardsPanel;
    public GameObject menuPanel;
    public GameObject thirdPlaceImage;
    public GameObject secondPlaceImage;
    public GameObject firstPlaceImage;
    public bool panelIsActive;
    


    void Start()
    {
         if (PlayerPrefs.GetInt("scoreMedals")>= 5)
        {
            thirdPlaceImage.SetActive(true);
            
        }

        if (PlayerPrefs.GetInt("scoreMedals")>= 15)
        {
            
            secondPlaceImage.SetActive(true);
        }

        if (PlayerPrefs.GetInt("scoreMedals")>= 25)
        {
            
            firstPlaceImage.SetActive(true);
        }

      
        
        
    }
  
  // Qnd chamamos esse metodo desabilitamos o painel do menu, e depois ativamos o painel das medalhas. 
    public void ActiveRewardsPanel()
    {
        menuPanel.SetActive(panelIsActive);
        panelIsActive = !panelIsActive;
        rewardsPanel.SetActive(panelIsActive);
    }

   
}
