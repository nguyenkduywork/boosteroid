using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.PlayerLoop;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    private AudioSource audioSource;
 

    [SerializeField] float ThrustPower = 2000;
    [SerializeField] float RotatePower = 100;

    [SerializeField] private AudioClip mainEngine;

    [SerializeField] private ParticleSystem mainEngineParticles;
    [SerializeField] private ParticleSystem LeftEngineParticles;
    [SerializeField] private ParticleSystem RightEngineParticles;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
    void FixedUpdate()
    {
        ProcessThrust();
        ProcessRotation();
    }
    
    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            audioSource.Stop();
            mainEngineParticles.Stop();
        }
    }

    private void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * ThrustPower * Time.deltaTime);
        if (!audioSource.isPlaying) audioSource.PlayOneShot(mainEngine);
        if (!mainEngineParticles.isPlaying) mainEngineParticles.Play();
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            StartRightEngine();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            StartLeftEngine();
        }
        else
        {
            RightEngineParticles.Stop();
            LeftEngineParticles.Stop();
        }
    }

    private void StartLeftEngine()
    {
        ApplyRotation(-RotatePower);
        if (!LeftEngineParticles.isPlaying) LeftEngineParticles.Play();
    }

    private void StartRightEngine()
    {
        ApplyRotation(RotatePower);
        if (!RightEngineParticles.isPlaying) RightEngineParticles.Play();
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; //freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
