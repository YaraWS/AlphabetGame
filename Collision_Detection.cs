using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Collision_Detection : MonoBehaviour
{
    public bool triggered;
    
    //Method to detect collision. 
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Sphere_Collider"))
        {
            triggered = true;
        }
    }
}
