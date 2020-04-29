using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greeting : MonoBehaviour
{
    [SerializeField] private Transform Greeting_PopUp;
    
    private void Start()
    {
        Instantiate(Greeting_PopUp, Vector3.zero, Quaternion.identity);
        
    }

    
}
