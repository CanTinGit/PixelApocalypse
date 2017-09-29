using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public GameObject player;
    public float speed;
    public int health;
	
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

	// Update is called once per frame
	void Update ()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);
    }

    public void TakeDamage(int loss)
    {
        health -= loss;
        if (health <= 0)
            Destroy(gameObject);
    }
}
