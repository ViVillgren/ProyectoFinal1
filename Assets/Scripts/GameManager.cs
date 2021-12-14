using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;

public class GameManager : MonoBehaviour
{
    private PlayerController playerControllerScript;
    public bool gameOver;
    public GameObject[] targetPrefabs;
    public Vector3 randomSpawnPos;
    public List<Vector3> targetPositions;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    private float spawnRate = 5f;
    private float startDelay = 1f;
    private int star = 0;
    private float ground = 0;
    private float spawnLim = 200;
    public int missCounter;
    private float spawnPos;
    public int totalMisses = 1;


    // Start is called before the first frame update
    void Start()
    {
        star = 0;
        UpdateScore(pointsToAdd: 0);
        missCounter = 0;
        gameOverText.gameObject.SetActive(false);

        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObject", startDelay, spawnRate);
        SpawnStar();
    }

    public Vector3 SpawnRandomPos()
    {
        float randomPosX = Random.Range(-spawnLim, spawnLim);
        float randomPosY = Random.Range(ground, spawnLim);
        float randomPosZ = Random.Range(-spawnLim, spawnLim);

        return new Vector3(randomPosX, randomPosY, randomPosZ);
    }

    public void SpawnObject()
    {
        Instantiate(targetPrefabs[0], SpawnRandomPos(), targetPrefabs[0].transform.rotation);
    }

    public void SpawnStar()
    {
        for (int i = 0; i < 10; ++i)
        {
            Instantiate(targetPrefabs[1], SpawnRandomPos(), targetPrefabs[1].transform.rotation);
        }
    }

    public void UpdateScore(int pointsToAdd)
    {
        star += pointsToAdd;
        scoreText.text = $"Stars: {star}/10";

    }

    public void GameOver()
    {
        gameOver = true;
        gameOverText.gameObject.SetActive(true);
    }
}
