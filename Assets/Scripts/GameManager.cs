using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int level = 0;
    public static GameManager instance;
    public bool isEnemyClear = false;
    public EnemyManager enemyManager;
    public int maxEnemyCount, minEnemyCount;
    public int enemyCount;
    public int columns = 0;
    public int rows = 0;
    public GameObject[] floorTiles;
    public GameObject WallUp;
    public GameObject WallDown;
    public GameObject WallLeft;
    public GameObject WallRight;
    private Transform boardHolder;
    float time;
    public float waveTime;

    void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;

        for (int x = -2; x < columns + 1; x++)
        {
            for (int y = -2; y < rows + 1; y++)
            {
                GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];
                if (x == -2)
                    toInstantiate = WallLeft;
                if (x == columns)
                    toInstantiate = WallRight;
                if (y == -2)
                    toInstantiate = WallDown;
                if (y == rows)
                    toInstantiate = WallUp;

                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;

                instance.transform.SetParent(boardHolder);

            }
        }
    }

    void Awake ()
    {
        waveTime = -5;
        time = waveTime;
        instance = this;
        enemyManager = GetComponent<EnemyManager>();
	}
	
    void Start()
    {
        BoardSetup();
    }
	// Update is called once per frame
	void Update ()
    {
        time -= Time.deltaTime;
        if(enemyCount <= 0 || time <= 0)
        {
            enemyManager.InitEnemy(minEnemyCount, maxEnemyCount, level);
            LevelUp();
        }
    }

    void LevelUp()
    {
        minEnemyCount += 1;
        maxEnemyCount += 3  ;
        waveTime += 10;
        time = waveTime;
        level++;
    }
}
