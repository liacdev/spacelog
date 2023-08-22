using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // PARAMETERS: For tuning, typically set in the editor
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotateSpeed = 100f;
    [SerializeField] AudioClip mainEngine;

    // CACHE: References for readability or speed
    Rigidbody rigidbodyRocket;
    AudioSource audioSource;

    // STATE: Private instance (member) variables


    // Start is called before the first frame update
    void Start()
    {
        rigidbodyRocket = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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
       
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);

            }
        }
        
        else 
        {
            audioSource.Stop();
        }


    }
    
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotateSpeed);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotateSpeed);
        }          
    }
        void ApplyRotation(float rotationThisFrame)
        {
            rigidbodyRocket.freezeRotation = true; //Freezing rotation so we can manually rotate
            transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
            rigidbodyRocket.freezeRotation = false; //Un-freezing rotation so physics system can work again
        }   
           




}
