using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letters_Array : MonoBehaviour
{   
    //Variables
    public Letters_Controller [] letters_Controllers;
    public int currentLetter;
    public Multiply_Lines multiply_Lines;
    public bool panelLettersConfigIsActive;
    public bool panelLettersButtonIsActive;
    public GameObject panelLettersConfig;
    public GameObject panelLettersButton;

    private void Start()
    {
        ActivePanelLettersButton();

    }
    public void Letter(int letter) //
    {
        letters_Controllers[letter].gameObject.SetActive(true);
        letters_Controllers[letter].congratulations = false;
        for (int i = 0; i < letters_Controllers.Length; i++)
        {
            if (i != letter)
            {
                letters_Controllers[i].gameObject.SetActive(false);
            }
        }
        currentLetter = letter; 
        ResetLetters(letter);
        multiply_Lines.letters_Controller = letters_Controllers[currentLetter];
        //Toda vez que eu clicar na letra referente ao nosso array de letters controler nosso script multiply lines recebe o letter contolers. 
        
    }

    public void NextLetter()
    {
        if (currentLetter < 25)
        {
            currentLetter++;
        }
        
        letters_Controllers[currentLetter].gameObject.SetActive(true);
        letters_Controllers[currentLetter].congratulations = false;
        ResetLetters(currentLetter);
        multiply_Lines.letters_Controller = letters_Controllers[currentLetter];
        for (int i = 0; i < letters_Controllers.Length; i++)
        {
            if (i != currentLetter)
            {
                letters_Controllers[i].gameObject.SetActive(false);
            }
        }
        DestroyAllLines();
    }

     public void PreviousLetter()
    {   
        if (currentLetter > 0)
        {
            currentLetter--;
        }
       
        letters_Controllers[currentLetter].gameObject.SetActive(true);
        letters_Controllers[currentLetter].congratulations = false;
        ResetLetters(currentLetter);
        multiply_Lines.letters_Controller = letters_Controllers[currentLetter];
        for (int i = 0; i < letters_Controllers.Length; i++)
        {
            if (i != currentLetter)
            {
                letters_Controllers[i].gameObject.SetActive(false);
            }
        }
        DestroyAllLines();
    }


    public void ResetReference()
    {
        ResetLetters(currentLetter);
    }

    public void ResetLetters(int letters)
    {
    
      //Chama o metodo DestroyAllLines
        DestroyAllLines();
        letters_Controllers[currentLetter].congratulations = false;
        //Percorre a lista de colliderControler na letra atual.
        for (int i = 0; i < letters_Controllers[letters].collider_Controller.Length; i++)
        {
            //torna false a variavel que checa se a linha foi concluida            
            letters_Controllers[letters].collider_Controller[i].correct = false;
            //torna false a variavel de busca e comparacao se a linha ta concluida.
             letters_Controllers[letters].collider_Controller[i].checking = false;
            //Percorre a lista de colisores de cada linha.
             for (int o = 0; o <letters_Controllers[letters].collider_Controller[i].collision_Detection.Length; o++)
             {
                 //Torna a variavel de comparacao triggered false.
                 letters_Controllers[letters].collider_Controller[i].collision_Detection[o].triggered = false;
                 
             }
        }
        //Faz a letra atual voltar para a linha 0.(First Line)
        letters_Controllers[letters].currentColliderController = 0;
        //Faz a letra atual voltar a poder ser desenhada.
        letters_Controllers[letters].hasMoreCollider = true;
    }

    // Esse metodo vai destruir todas as linhas criadas, que estao dentro do objecto lineFather.
    public void DestroyAllLines()
    {
        foreach (Transform child in multiply_Lines.lineFather.transform)
        {
            Destroy(child.gameObject);
        }
    }

// Toda vez que chamarmos esse metodo podemos ativar e desativar o objeto. 
    public void ActivePanelLettersButton()
    {
        panelLettersButtonIsActive = !panelLettersButtonIsActive;
        panelLettersButton.SetActive(panelLettersButtonIsActive);

    }

    public void ActivePanelLettersConfig()
    {
        panelLettersConfigIsActive = !panelLettersConfigIsActive;
        panelLettersConfig.SetActive(panelLettersConfigIsActive);
    }

    public void Return()
    {
        letters_Controllers[currentLetter].gameObject.SetActive(false);
    }
}
