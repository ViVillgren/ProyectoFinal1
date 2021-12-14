using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{

    private AudioSource cameraAudioSource;
    private GameManager gameManagerScript;
    [SerializeField] private int stars;
    public ParticleSystem rewardParticle;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter(Collision otherCollider)
    {
        if (!gameManagerScript.gameOver)
        {
            gameManagerScript.UpdateScore(stars);
            Instantiate(rewardParticle, transform.position, rewardParticle.transform.rotation);
        }

        if (gameObject.CompareTag("Good"))
        {


            Destroy(gameObject);
            gameManagerScript.targetPositions.Remove(transform.position);
        }

        else if (gameObject.CompareTag("Bad"))
        {
            Destroy(gameObject);
            gameManagerScript.missCounter += 1;

            if (gameManagerScript.missCounter >= gameManagerScript.totalMisses)
            {
                gameManagerScript.GameOver();
                cameraAudioSource.Stop();
            }
        }




    }
}
