using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float mainThrust = 100f;
    Rigidbody rigidbodyRocket;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyRocket = GetComponent<Rigidbody>();
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
            rigidbodyRocket.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
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
