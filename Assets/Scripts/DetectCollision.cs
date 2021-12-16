using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetectCollision : MonoBehaviour
{
    private AudioSource explosionAudioSource;
    public ParticleSystem explosionParticle;
    public AudioClip boomClip;
   


    void Start()
    {
        explosionAudioSource = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter(Collider otherTrigger)
    {
        /*
        if (otherTrigger.gameObject.CompareTag("Bad"))
        {
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            explosionAudioSource.PlayOneShot(boomClip, 4f);
            Destroy(otherTrigger.gameObject); //Gameobject enemy
            Destroy(gameObject); //Gameobject del proyectil
            
        }
         */


        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        explosionAudioSource.PlayOneShot(boomClip, 4f);
        Destroy(otherTrigger.gameObject); //Gameobject enemy
        Destroy(gameObject); //Gameobject del proyectil

    }
}
