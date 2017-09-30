using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int level;
    public static GameManager instance;
    public bool isEnemyClear = false;
    public EnemyManager enemyManager;
    public int maxEnemyCount, minEnemyCount;
    public int enemyCount;

	void Awake ()
    {
        instance = this;
        enemyManager = GetComponent<EnemyManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(enemyCount <= 0)
        {
            enemyManager.InitEnemy(minEnemyCount, maxEnemyCount);
            LevelUp();
        }
    }

    void LevelUp()
    {
        minEnemyCount += 5;
        maxEnemyCount += 5;
    }
}
