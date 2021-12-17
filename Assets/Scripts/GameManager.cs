using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;

public class GameManager : MonoBehaviour
{
    private PlayerController playerControllerScript;
    public GameObject[] targetPrefabs;
    public Vector3 randomSpawnPos;
    public List<Vector3> targetPositions;

    private float spawnRate = 5f;
    private float startDelay = 1f;
    private float ground = 0;
    private float spawnLim = 200;

    public int missCounter;
    private float spawnPos;
    public int totalMisses = 1;


    void Start() //Nada mas empezar el juego aparezcan 10 recolectables, 1 objeto cada 5 segundo y todo en posiciones aleatoria
    {
        missCounter = 0;
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObject", startDelay, spawnRate);
        SpawnStar();
    }

    public Vector3 SpawnRandomPos() //Funcion para aleatorizar la posicion de un objeto
    {
        float randomPosX = Random.Range(-spawnLim, spawnLim);
        float randomPosY = Random.Range(ground, spawnLim);
        float randomPosZ = Random.Range(-spawnLim, spawnLim);

        return new Vector3(randomPosX, randomPosY, randomPosZ);
    }

    public void SpawnObject() //con la aleatoridad haremos que aparezcan objetos
    {
        Instantiate(targetPrefabs[0], SpawnRandomPos(), targetPrefabs[0].transform.rotation);
    }

    public void SpawnStar() // con la aleatoridad apareceran los recolectables
    {
        for (int i = 0; i < 10; ++i)
        {
            Instantiate(targetPrefabs[1], SpawnRandomPos(), targetPrefabs[1].transform.rotation);
        }
    }

}
