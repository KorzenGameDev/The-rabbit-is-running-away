using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemy=null;
    Transform[] spawnPoint = new Transform[3];
    float lastXPos;
    float distBtwSpawn = 10f;
    int inWaveEnemy;

    GameObject player=null;

    private void Awake()
    {
        spawnPoint[0] = GameObject.Find("SpawnerPoint (0)").transform;
        spawnPoint[1] = GameObject.Find("SpawnerPoint (1)").transform;
        spawnPoint[2] = GameObject.Find("SpawnerPoint (2)").transform;
    }
    private void Start()
    {
        player = FindObjectOfType<GameMenager>().player;
        SpawnerPosition();
        SpawnEnemy();
    }

    private void Update()
    {
        SpawnerPosition();
        if (Mathf.Abs(gameObject.transform.position.x - lastXPos) >= distBtwSpawn)
        {
            SpawnEnemy();
        }
    }
    void SpawnerPosition()
    {
        float offset = 25f;
        gameObject.transform.position = new Vector2(player.transform.position.x + offset, gameObject.transform.position.y);
    }

    void EnemyInWave()
    {
        float procentagEnemyInWave = Random.Range(0f, 100f);
        if (procentagEnemyInWave <= 10f)
            inWaveEnemy= 0;
        if (procentagEnemyInWave > 10f && procentagEnemyInWave <= 55f)
            inWaveEnemy= 1;
        if (procentagEnemyInWave > 55f)
            inWaveEnemy= 2;
    }

    void SpawnEnemy()
    {
        int[] lastWas = new int[2];
        lastWas[0] = -1;
        lastWas[1] = -1;
        int i = 0;
        EnemyInWave();
        while( i < inWaveEnemy)
        {
            float procentage = Random.Range(0, 100f);
            int index = 0;
            if (procentage <= 33f) index = 0;
            if (procentage > 33f && procentage <= 66f) index = 1;
            if (procentage > 66f && procentage <= 100f) index = 2;

            if (index!=lastWas[0] && index != lastWas[1])
            {
                lastWas[i] = index;
                Instantiate(enemy[0], new Vector3(gameObject.transform.position.x, spawnPoint[index].position.y, gameObject.transform.position.z), Quaternion.identity);

                i++;
                
            }
            lastXPos = gameObject.transform.position.x;
        }
    }

}
