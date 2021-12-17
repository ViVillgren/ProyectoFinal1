using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public AudioSource playerAudioSource;
    public AudioSource winAudioSource;
    public AudioSource cameraAudioSource;

    public AudioClip boomClip;
    public AudioClip coinClip;
    public AudioClip deathClip;
    public AudioClip winClip;
    public AudioClip shotClip;

    public GameObject projectilePrefab;
    public GameObject shooterObject;
    public ParticleSystem shotParticle;
    public ParticleSystem explosionParticle;
    public Targets targetsScript;

    private Vector3 initialPos = new Vector3(0, 100, 0);
    public float speed = 20.0f;
    private float verticalInput;
    private float horizontalInput;
    private float turnSpeed = 100.0f;
    private float xRange = 200f;
    private float ground = 0f;


    void Start()
    {
        transform.position = initialPos;
        playerAudioSource = GetComponent<AudioSource>();
        winAudioSource = GetComponent<AudioSource>(); 
        cameraAudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        playerRigidbody = GetComponent<Rigidbody>();
        targetsScript = FindObjectOfType<Targets>();
        
    }

    void Update()
    {
        // Aqui hace que cuando gane o pierda el movimiento del player pare
        if (!targetsScript.gameOver && !targetsScript.win)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }


        //Controlador del player
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * Time.deltaTime * horizontalInput * turnSpeed);
        transform.Rotate(Vector3.right * Time.deltaTime * -verticalInput * turnSpeed);

        //limite del player
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.y > xRange)
        {
            transform.position = new Vector3(transform.position.x, xRange, transform.position.z);
        }
        if (transform.position.y < ground)
        {
            transform.position = new Vector3(transform.position.x, ground, transform.position.z);
        }

        if (transform.position.z > xRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, xRange);
        }
        if (transform.position.z < -xRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -xRange);
        }

        //Tecla para disparar
        if (Input.GetKeyDown(KeyCode.RightControl) || Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, shooterObject.transform.position, transform.rotation);
            playerAudioSource.PlayOneShot(shotClip, 3f);
            Instantiate(shotParticle, shooterObject.transform.position, shotParticle.transform.rotation);
        }
    }
}
