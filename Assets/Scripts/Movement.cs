using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] AudioSource audioSource;
    [SerializeField] float mainThrust = 100f, rotationThrust = 1f;
    
    public bool isAlive;
    [HideInInspector] public bool success;

    [SerializeField] ParticleSystem mainParticles;
    [SerializeField] ParticleSystem sideLParticels, sideRParticels;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isAlive = true;
        success = false;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();

        if (GetComponent<MeshCollider>().transform.position.z != 0) // to freeze position on z axis permanantly
        {
            transform.position = new Vector3(GetComponent<MeshCollider>().transform.position.x, GetComponent<MeshCollider>().transform.position.y, 0);
        }
        if(!isAlive && audioSource.isPlaying)
            audioSource.Stop();
            
    }
    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space) && isAlive)
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime); // Vector3.up = 0,1,0
            if(!mainParticles.isPlaying)
                mainParticles.Play();
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            audioSource.Stop();
            mainParticles.Stop();
        }

    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
            if(!sideLParticels.isPlaying)
                sideLParticels.Play();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
            if(!sideRParticels.isPlaying)
                sideRParticels.Play();
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            sideLParticels.Stop();
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            sideRParticels.Stop();
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(Vector3.forward*rotationThrust*Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S)){
            transform.Rotate(- Vector3.forward * rotationThrust * Time.deltaTime);
        }
        void ApplyRotation(float rotationThisFrame)
        {
            /*When we are controlling it, we want to say, freeze the rotation. Don't let the physics system do anything for the rotation. However, when we're finished with our particular manual rotation, we say back to usual unfreeze the rotation that's happening. We don't need to freeze it anymore.*/
            rb.freezeRotation = true; //freezing rotation se we can manually rotate
            transform.Rotate(Vector3.right * rotationThisFrame * Time.deltaTime);
            rb.freezeRotation = false;
        }
    }
}
//Gravity changed from -9.81 to -4 in Unity Project Settings-Physic