using UnityEngine;

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
    
    //Calling movement methods in FixedUpdate() helps prevent stuttering when moving at a
    //slightly faster speed
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
    
    //Add force to the rocket main engine, also turn on audio for the engine and engine particles
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

    //Add force to the rocket left engine, also turn on engine particles
    private void StartLeftEngine()
    {
        ApplyRotation(-RotatePower);
        if (!LeftEngineParticles.isPlaying) LeftEngineParticles.Play();
    }

    //Add force to the rocket right engine, also turn on engine particles
    private void StartRightEngine()
    {
        ApplyRotation(RotatePower);
        if (!RightEngineParticles.isPlaying) RightEngineParticles.Play();
    }

    void ApplyRotation(float rotationThisFrame)
    {
        //freezing rotation so we can manually rotate, prevent normal physic rotation to improve maneuverability
        rb.freezeRotation = true; 
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
