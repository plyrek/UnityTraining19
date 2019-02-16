using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyer : MonoBehaviour
{
  
    public GameObject ship;

    [SerializeField]
    private float rcsThrust = 250f;
    [SerializeField]
    private float mainThrust = 25f;

    private Rigidbody rigidBody;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();
    }

    private void Thrust()
    {
 
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Thrust Pressed");
            rigidBody.AddRelativeForce(Vector3.up * mainThrust);
            audioSource.mute = false;
            if (!audioSource.isPlaying)
            {
                audioSource.Play();

            }
        }
        else
        {
            audioSource.mute = true;
        }
    }

    private void Rotate()
    {
        
        float rotationThisFrame = rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            rigidBody.freezeRotation = true;
            Debug.Log("Rotating Left");
            ship.transform.Rotate(Vector3.forward * rotationThisFrame);
            
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigidBody.freezeRotation = true;
            Debug.Log("Rotating Right");
            ship.transform.Rotate(-Vector3.forward * rotationThisFrame);
        } else
        {
            rigidBody.freezeRotation = false;
            rigidBody.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;
        }
    }
}

