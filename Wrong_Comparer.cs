using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrong_Comparer : MonoBehaviour
{
    public Wrong_Collider wrong_Collider;


    private void OnTriggerEnter(Collider other) {
        if (other.tag.Equals("Sphere_Collider"))
        {
            wrong_Collider.isWrong = true;
        }
        
    }
}
