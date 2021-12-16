using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private AudioSource playerAudioSource;
    private AudioSource cameraAudioSource;
    private Vector3 initialPos = new Vector3(0, 100, 0);
    public float speed = 10.0f;
    private float verticalInput;
    private float horizontalInput;
    private float turnSpeed = 100.0f;
    private float xRange = 200f;
    private float ground = 0f;
    public GameObject projectilePrefab;
    public GameObject shooterObject;
    public AudioClip shotClip;
    public ParticleSystem shotParticle;
    public Targets targetsScript;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = initialPos;
        playerAudioSource = GetComponent<AudioSource>();
        playerRigidbody = GetComponent<Rigidbody>();
        cameraAudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        targetsScript = FindObjectOfType<Targets>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!targetsScript.gameOver)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * Time.deltaTime * horizontalInput * turnSpeed);
        transform.Rotate(Vector3.right * Time.deltaTime * -verticalInput * turnSpeed);

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

        if (Input.GetKeyDown(KeyCode.RightControl) || Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, shooterObject.transform.position, transform.rotation);
            playerAudioSource.PlayOneShot(shotClip, 3f);
            Instantiate(shotParticle, shooterObject.transform.position, shotParticle.transform.rotation);
        }
    }
}
