using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderEnemy : Enemy {

    public int columns, rows;
    public int mapColumns, mapRows;
    private Vector3 target;
    public float speed;
    public bool isArrive = true;

    private List<Vector3> gridPositions = new List<Vector3>();

    void Awake () {
        mapColumns = GameObject.FindGameObjectWithTag("GameManager").GetComponent<EnemyManager>().columns;
        mapRows = GameObject.FindGameObjectWithTag("GameManager").GetComponent<EnemyManager>().rows;
    }

    void Update()
    {
        if (isArrive)
        {
            InitialiseList((int)transform.position.x, (int)transform.position.y);
            target = RandomPosition();
            isArrive = false;
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed);
        if (transform.position == target)
            isArrive = true;
    }

    // Update is called once per frame
    void InitialiseList(int enemyX, int enemyY)
    {
        gridPositions.Clear();

        for (int x = enemyX - columns; x < enemyX + columns + 1; x++)
        {
            if(x > 0 && x < mapColumns)
            {
                for (int y = enemyY - rows; y < enemyY + rows + 1; y++)
                {
                    if(y > 0 && y < mapRows)
                    {
                        gridPositions.Add(new Vector3(x, y, 0.0f));
                    }

                }
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
}
