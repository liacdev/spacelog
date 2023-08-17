using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust() 
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Pressed SPACE - Thrusting");
        }
    }
    
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            // rotate left
            Debug.Log("Rotating left");
        }

        else if (Input.GetKey(KeyCode.D))
        {
            // rotate right
            Debug.Log("Rotating right");
        }        
    }




}
