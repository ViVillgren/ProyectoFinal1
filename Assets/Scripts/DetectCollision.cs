using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetectCollision : MonoBehaviour
{
   
    private PlayerController playerControllerScript;


    void Start()
    {

        playerControllerScript = FindObjectOfType<PlayerController>();

    }

    private void OnTriggerEnter(Collider otherTrigger)
    {
        
        if (otherTrigger.gameObject.CompareTag("Bad")) //con el tag evitamos que tambien destruyan los recolectables con los proyectiles
        {
            Destroy(otherTrigger.gameObject); //Gameobject enemy
            Destroy(gameObject); //Gameobject del proyectil
            playerControllerScript.playerAudioSource.PlayOneShot(playerControllerScript.boomClip, 1f);
            Instantiate(playerControllerScript.explosionParticle, transform.position, playerControllerScript.explosionParticle.transform.rotation);
        }
    }
}
