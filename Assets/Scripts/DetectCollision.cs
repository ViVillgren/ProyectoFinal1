using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private AudioSource explosionAudioSource;
    public ParticleSystem explosionParticle;
    public AudioClip boomClip;
    private void OnTriggerEnter(Collider otherTrigger)
    {
        Destroy(otherTrigger.gameObject); //Gameobject enemy
        Destroy(gameObject); //Gameobject del projectil
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        explosionAudioSource.PlayOneShot(boomClip, 1f);
    }
}
