using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public GameObject player;
    public float speed;
    public int health;
    public int attack;
    public float force;
    public bool canBeDestory = false;
	
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

	// Update is called once per frame
	void Update ()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);
    }

    public void TakeDamage(int loss)
    {
        health -= loss;
        if (health <= 0)
        {
            canBeDestory = true;
            //Change image
        }
    }
    
    public void DestoryEnemy()
    {
        if (canBeDestory)
        {
            GameManager.instance.enemyCount--;
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Vector3 backDirection = (player.transform.position - transform.position).normalized * force;
            player.GetComponent<PlayerController>().TakeDamage(attack,backDirection);
        }
    }
}
