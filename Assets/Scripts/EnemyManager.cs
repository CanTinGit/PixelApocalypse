using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{

    public int columns, rows;
    public GameObject[] enemyTiles;
    public float distanceToPlayer;
    public GameObject player;
    private List<Vector3> gridPositions = new List<Vector3>();
    public GameObject enemy;
    public GameObject wanderEnemy;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void InitialiseList()
    {
        gridPositions.Clear();

        for (int x = 1; x < columns - 1; x++)
        {
            for (int y = 1; y < rows - 1; y++)
            {
                Vector3 spawnTransform = new Vector3(x, y);
                if((spawnTransform - player.transform.position).magnitude > distanceToPlayer)
                    gridPositions.Add(new Vector3(x, y, 0.0f));
            }
        }
    }

    Vector3 RandomPosition()
    {
        int randomIndex = Random.Range(0, gridPositions.Count);
        Vector3 randomPosition = gridPositions[randomIndex];
        gridPositions.RemoveAt(randomIndex);          //avoid get same position
        return randomPosition;
    }

    int LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum, int level)
    {
        int objectCount = Random.Range(minimum, maximum + 1);

        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition();
            int portion = Random.Range(0, 10);
            GameObject tileChoice;
            if (level == 1)
            {
                tileChoice = enemy;
                Instantiate(tileChoice, randomPosition, Quaternion.identity);
            }
            else
            {
                if(portion < 2)
                {
                    tileChoice = wanderEnemy;
                }
                else
                {
                    tileChoice = enemy;
                }
                
                Instantiate(tileChoice, randomPosition, Quaternion.identity);
            }  
        }
        return objectCount;
    }

    public void InitEnemy(int minEnemyCount, int maxEnemyCount, int level)
    {
        InitialiseList();            
        GameManager.instance.enemyCount +=  LayoutObjectAtRandom(enemyTiles, minEnemyCount, maxEnemyCount, level);
    }
}
