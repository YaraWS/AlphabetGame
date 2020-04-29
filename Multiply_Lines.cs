using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiply_Lines : MonoBehaviour
{
  	public GameObject circlePointPrefab;
    public LineRenderer currentLineRenderer;
    public GameObject lineRendererPrefab;
    public Material drawingMaterial;

    public GameObject linesParentPrefab;
    public GameObject linesParent;
    public bool randomColor;
    public Color[] lineColor;

    public GameObject lineCollider;
    public GameObject colliderParent;

    public Letters_Controller letters_Controller;

    public bool addLines;
    
    private Vector3 previousPosition;
    private Vector3 currentPosition;
    
    // Serve para saber se ouve um click ou nao. 
    private bool clickStarted; 

    private int numberOfPoints;


    public Texture2D cursorDefault;

    public Texture2D cursorCanDraw;

    public GameObject lineFather;

    public bool canDraw;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
    void Update()
    {
      if (letters_Controller.hasMoreCollider == true)
      {
                
        if (currentLineRenderer == null) // O null ajuda a nao sobrecarregar a funcao Update. 
        {
          currentLineRenderer = GameObject.Instantiate(lineRendererPrefab).GetComponent<LineRenderer>(); 
          currentLineRenderer.gameObject.SetActive(false); 
          linesParent = GameObject.Instantiate(linesParentPrefab); // Para nao excluir a linha errada. 
          linesParent.transform.parent = lineFather.transform;
          linesParent.transform.position = new Vector3(1000,1000,1000);
          currentLineRenderer.transform.parent = linesParent.transform; //Qnd o objeto for criado ele vai virar filho do linesParent.   
          randomColor = true;       
        }

        currentPosition = Camera.main.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x,Input.mousePosition.y,10.0f)); // O numero no final sera colocado dentro de uma varial para best practices 
        //posicao do mouse em x e y. A camera tem o posicionamento de 10.0f , para que o script do mouse possa  reagir com base nessa informacao. 

        //0 botao da esquerda
        if (Input.GetMouseButtonDown (0)&& canDraw == true) 
        {
          clickStarted = true;
          InstantiateCirclePoint(currentPosition,currentLineRenderer.transform);
          currentLineRenderer.gameObject.SetActive(true);    
          addLines = true;    
        }
        if (Input.GetMouseButtonUp(0)) // Para detectar que o botao esquerdo do mouse foi solto.
        {
                //Debug.Log("Soltou");
                clickStarted = false;
                InstantiateCirclePoint(currentPosition,currentLineRenderer.transform);
          //StartCoroutine("SmoothCurrentLine");
          currentLineRenderer = null;
          numberOfPoints = 0;
          if (addLines == true)
          {
            if (letters_Controller.collider_Controller[letters_Controller.currentColliderController].correct == true)
              { 
                foreach (Transform child in colliderParent.transform)
                {
                  GameObject.Destroy(child.gameObject);
                            
                }
                if (letters_Controller.wrong_Collider.isWrong == false)
                {

                            letters_Controller.currentColliderController +=1;
                            addLines = false;
                }
                
                  
              }//Essa linha serve para checar os coliders como os coliders de erro(externos)
              
              else if(letters_Controller.collider_Controller[letters_Controller.currentColliderController].correct == false )
              {
                DeleteLine();
                ResetColliders();
              }
              if(letters_Controller.wrong_Collider.isWrong == true)
              {
                 DeleteLine();
                 ResetColliders();
                 letters_Controller.wrong_Collider.isWrong = false;
              }
          }
            
        }
      
     }   
    }

    private void FixedUpdate()
    {
        if (clickStarted == true)
        {
            numberOfPoints++;
            TouchSpaceHandle(currentPosition, currentLineRenderer);
            InstantiateCollider(currentPosition, colliderParent.transform);
        }
    }
    //Essa primeira parte do foreach deleta os colisores antigos. 
    private void ResetColliders()
    {
      foreach (Transform child in colliderParent.transform)
      {
          Destroy(child.gameObject); 
      }
      StartCoroutine("TurnOffComparers");
    }
   
   //Metodo chamado com delay para tornar as variaveis falsas.
    IEnumerator TurnOffComparers()
    {
      yield return new WaitForSeconds(0.1f);//delay
      foreach (Transform child in letters_Controller.collider_Controller[letters_Controller.currentColliderController].transform)//foreach vai tornar o triggered dos colisores false.
      {
          child.GetComponent < Collision_Detection >().triggered = false;
      }
      letters_Controller.collider_Controller[letters_Controller.currentColliderController].correct = false;
        letters_Controller.collider_Controller[letters_Controller.currentColliderController].checking = false;
//letters controler pega a linha atual e vai tornar a variavel correct falsa e variavel checking falsa, podendo assim fazer a comparacao novamente.
    }
    private void DeleteLine()
    {
        foreach (Transform child in linesParent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
    private void InstantiateCirclePoint(Vector3 position, Transform parent) 
    {
      GameObject currentCircle = GameObject.Instantiate(circlePointPrefab);
      currentCircle.transform.parent = parent;
      currentCircle.GetComponent<Renderer>().material = drawingMaterial;
      currentCircle.transform.position = position; //Settando posicao do objeto com base na posicao do mouse.

    }

    private void TouchSpaceHandle(Vector3 position,LineRenderer currentLineRendererGo) // Fazer o desenho da linha de acordo com a posicao do mouse. 
    {
      LineRenderer currentLineRenderer = currentLineRendererGo;
      currentLineRenderer.positionCount = numberOfPoints; // adicionar segmentos com base no numberofpoints
      currentPosition = position; //onde a linha vai ser criada
      currentLineRenderer.SetPosition(numberOfPoints -1,currentPosition); //Settando a possicao das linhas
      if (randomColor == true)
      {
        currentLineRenderer.material.color = lineColor[Random.Range(0,lineColor.Length)];
        randomColor = false;
        
          
      }
    }

    private void InstantiateCollider(Vector3 position, Transform parent)
    {
      GameObject currentCollider = GameObject.Instantiate(lineCollider);
      currentCollider.transform.parent = parent;
      currentCollider.transform.position = position;

    }
    
    //Esse metodo impede que seja criada linhas quando vc clica no botao. 
    public void CannotDraw()
    {
      canDraw = false;
      Cursor.SetCursor(cursorDefault, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void CanDraw()
    {
      canDraw = true;
      Cursor.SetCursor(cursorCanDraw, Vector2.zero, CursorMode.ForceSoftware);
    }

    /*private IEnumerator SmoothCurrentLine()
    {
      //LineRenderer 'e uma subvariavel de LineRenderer.
      LineRendererAttributes line_Atributes = currentLineRenderer.GetComponent<LineRendererAttributes>(); 
      //ln vai servir como um atalho de variavel.
      LineRenderer ln = currentLineRenderer.GetComponent<LineRenderer>();
      //Vector3 vai receber os vetores de posicao de LineRenderer.
      Vector3[] vectors = SmoothCurve.MakeSmoothCurve(line_Atributes.Points.ToArray(),10);

      //childsCount vai contar quantos objetos tem em LineRenderer.
      int childsCount = currentLineRenderer.transform.childCount;
      
      //for vai destruir os objetos que a gente tem como filhos do LineRenderer. 
      for (int i = 0; i <vectors.Length; i++)
      {
        Destroy (currentLineRenderer.transform.GetChild(i).gameObject);
          
      }

      line_Atributes.Points.Clear();
      //Esse for vai fazer a criacao de nova linha otimizado.
      for (int i = 0; i < vectors.Length; i++)
      {
        if (i == 0 || i < vectors.Length -1)
        {
            InstantiateCirclePoint(vectors[i],currentLineRenderer.transform);
        }
        line_Atributes.numberOfPoints = i+1;
        line_Atributes.Points.Add(vectors[i]);
        ln.positionCount = i+1;
        ln.SetPosition(i,vectors[i]);
              
          
      }

      currentLineRenderer = null;
      yield return new WaitForSecond(0);
    }*/


}
