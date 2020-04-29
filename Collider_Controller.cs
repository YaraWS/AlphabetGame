using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_Controller : MonoBehaviour
{
        public Collision_Detection[] collision_Detection;
        public bool correct;
        public GameObject colliders_Parent;
        public bool checking;  // para fazer funcionar so quando for necessario.
        public Main_Controler main_Controler;
        

    
    void Update()
    {   //This if statment will verify if the user toutched these colliders in order to make the right shape of the letter. 
        if (checking == false) 
        {
            if (collision_Detection[0].triggered == true)
            {   
                if(collision_Detection[1].triggered == true)
                {   
                    if (collision_Detection[2].triggered == true)
                    {   
                        if (collision_Detection[3].triggered == true)
                        {   
                            CorrectLineEffects();
                            correct = true; 
                            checking = true;
                                        
                        }
                    }                
                }
            }
        }
    }
    
    //Puts a tag on Main_Controler.
    public void CorrectLineEffects()
    {
        if (main_Controler == null)
        {
            main_Controler = GameObject.FindGameObjectWithTag("Main_Controller").GetComponent<Main_Controler>();
        }

        main_Controler.LineFinishedEffects();
    }
}
