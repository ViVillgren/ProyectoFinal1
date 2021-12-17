using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Targets : MonoBehaviour
{

    private AudioSource cameraAudioSource;
    private GameManager gameManagerScript;
    public ParticleSystem rewardParticle;
   
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI winText;

    private PlayerController playerControllerScript;
    private GameManager gamemanagerScript;

    public int star = 0;
    public bool gameOver;
    public bool win;

    void Start()
    {
        star = 0;
        gameManagerScript = FindObjectOfType<GameManager>();
        playerControllerScript = FindObjectOfType<PlayerController>();
        gameOverText.gameObject.SetActive(false);
        winText.gameObject.SetActive(false);
        cameraAudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        
    }

    private void Update()
    {
        scoreText.text = $"Stars: {star}/10";
    }

    public void OnCollisionEnter(Collision otherCollider)
    {
        if (!gameOver) //Siempre que no sea Game Over
        {

            if (otherCollider.gameObject.CompareTag("Good")) //Para los recolectables se destruyan cada vez que el player los toque, sume puntos, suene musica y salgan particulas
            {
                Destroy(otherCollider.gameObject);
                Instantiate(rewardParticle, transform.position, rewardParticle.transform.rotation);
                playerControllerScript.playerAudioSource.PlayOneShot(playerControllerScript.coinClip, 2f);
                star = star + 1;

                if (star == 10) // cuando recogamos 10 monedas se active la funcion win, aparezca el texto y suene una musica de victoria
                {
                    win = true;
                    winText.gameObject.SetActive(true);
                    playerControllerScript.winAudioSource.PlayOneShot(playerControllerScript.winClip, 1f);

                }
            }

            else if (otherCollider.gameObject.CompareTag("Bad")) // Para los enemigos, si chocamos con 1 perdemos la partida
            {
                
                gameManagerScript.missCounter += 1;
                

                if (gameManagerScript.missCounter >= gameManagerScript.totalMisses) //Se activa el came over, aparezca el texto, suene la musica de perder y tambien que pare la musica general.
                {
                    gameOver = true;
                    gameOverText.gameObject.SetActive(true);
                    cameraAudioSource.Stop();
                    playerControllerScript.playerAudioSource.PlayOneShot(playerControllerScript.deathClip, 1f);
                }
            }
        }
    }

}
