using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Cotrolar o CAMInho de cada linha. 
public class Letters_Controller : MonoBehaviour
{
    public string letters; // serve para identificar que letra 'e essa que estamos usando. 
    public Collider_Controller[] collider_Controller; //serve para identificar a ordem das linhas que a gente tem que fazer.
    public bool hasMoreCollider; //para checar se todo o processo de tracar a letra foi concluido.
    public int currentColliderController;//verifica se estamos detro do array.
    public Wrong_Collider wrong_Collider;
    public bool letterHasEnded;

    public Main_Controler main_Controler;

    public bool congratulations;

    void Start()
    {
        main_Controler = GameObject.FindGameObjectWithTag("Main_Controller").GetComponent<Main_Controler>();
    }
    
        
    void Update()
    {
        if (hasMoreCollider == true)//identifica se o tracado de todas as linhas do array foi concluido.
        {
            if (currentColliderController < collider_Controller.Length)//identifica se o n- de linhas atuais feitos esta dentro do array. 
            {
                if (collider_Controller[currentColliderController].correct==true)//Verifica se a linha ATUAL foi encerrada com exito. 
                {
                    if (collider_Controller.Length >= currentColliderController)//verifica se array ainda tem espaco para fazer mais um tracado. Se ele tiver espaco, vai ser verdadeiro, caso contrario, falso. 
                    {
                        hasMoreCollider = true;
                    }
                }
                
            }
            else// se o numero de linhas nao estiver dentro do array ex: temos 3, nao podemos fazer a quarta linha. Ai ele encerra. 
            {
                hasMoreCollider = false;
                if (letterHasEnded == false && PlayerPrefs.GetString(letters) != "true")
                {
                    Debug.Log("lettersSeted");
                    PlayerPrefs.SetString(letters,"true");
                    int temp = PlayerPrefs.GetInt("scoreMedals");
                    PlayerPrefs.SetInt("scoreMedals", temp + 1);
                    letterHasEnded = true;
                                        
                }
                if ( congratulations == false)
               {
                   main_Controler.Instantiate();
                   congratulations = false;
               }

            }

            
        }
        
    }

           
}
