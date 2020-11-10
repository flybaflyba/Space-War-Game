using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryOutOfBounds : MonoBehaviour
{
    private float xBound = 50.0f;
    private float yBound = 15.0f;
    private float zBound = 25.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // if a objects go off view, destroy the object. 
        if (transform.position.x > xBound || transform.position.x < -xBound || transform.position.y > yBound || transform.position.y < -yBound || transform.position.z > zBound || transform.position.z < -zBound)
        {
            Destroy(gameObject);
            
        }


    }
}
