using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Vector3 initialPos = new Vector3(0, 100, 0);
    public float speed = 10.0f;
    private float verticalInput;
    private float horizontalInput;
    private float turnSpeed = 100.0f;
    private float xRange = 200f;
    private float ground = 0f;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = initialPos;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

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
    }
}
