using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 40f;
    private float xRange = 200f;
    private float ground = 0f;

    void Start()
    {
        
    }

    void Update()
    {

        //Los proyectiles se destruyen al llegar al limite
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (transform.position.x > xRange)
        {
            Destroy(gameObject);
        }
        if (transform.position.x < -xRange)
        {
            Destroy(gameObject);
        }

        if (transform.position.y > xRange)
        {
            Destroy(gameObject);
        }
        if (transform.position.y < ground)
        {
            Destroy(gameObject);
        }

        if (transform.position.z > xRange)
        {
            Destroy(gameObject);
        }
        if (transform.position.z < -xRange)
        {
            Destroy(gameObject);
        }
    }
   

}
