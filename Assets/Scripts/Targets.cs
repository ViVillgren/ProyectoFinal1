using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Targets : MonoBehaviour
{

    private AudioSource cameraAudioSource;
    private GameManager gameManagerScript;
    public ParticleSystem rewardParticle;
    public int star = 0;
    public bool gameOver;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI winText;

    // Start is called before the first frame update
    void Start()
    {
        star = 0;
        gameManagerScript = FindObjectOfType<GameManager>();
        gameOverText.gameObject.SetActive(false);
        winText.gameObject.SetActive(false);
        cameraAudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    private void Update()
    {
        scoreText.text = $"Stars: {star}/10";

        if (star == 10)
        {
            gameOver = true;
            winText.gameObject.SetActive(true);
        }
    }

    public void OnCollisionEnter(Collision otherCollider)
    {
        if (!gameOver)
        {

            if (otherCollider.gameObject.CompareTag("Good"))
            {
                Destroy(otherCollider.gameObject);
                Instantiate(rewardParticle, transform.position, rewardParticle.transform.rotation);
                
                star = star + 1;
            }

            else if (otherCollider.gameObject.CompareTag("Bad"))
            {
                Destroy(gameObject);
                gameManagerScript.missCounter += 1;

                if (gameManagerScript.missCounter >= gameManagerScript.totalMisses)
                {
                    gameOver = true;
                    gameOverText.gameObject.SetActive(true);
                    cameraAudioSource.Stop();
                }
            }
        }
    }

}
