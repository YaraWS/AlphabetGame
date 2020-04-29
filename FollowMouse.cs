using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MirzaBeig
{

    namespace ParticleSystems
    {

        namespace Demos
        {

            //[ExecuteInEditMode]
            [System.Serializable]

            
            public class FollowMouse : MonoBehaviour
            {
                //Variables
                public float speed = 8.0f;
                public float distanceFromCamera = 10.0f;

                void Update()
                {
                    Vector3 mousePosition = Input.mousePosition;
                    mousePosition.z = distanceFromCamera;

                    Vector3 mouseScreenToWorld = Camera.main.ScreenToWorldPoint(mousePosition);

                    Vector3 position = Vector3.Lerp(transform.position, mouseScreenToWorld, 1.0f - Mathf.Exp(-speed * Time.deltaTime));

                    transform.position = position;
                }
                         

            }

        }

    }

}


