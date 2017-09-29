using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public GameObject player;
    public float speed;
	
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	// Update is called once per frame
	void Update () {

        //if (player.transform.position.x > this.transform.position.x)
        //    gameObject.transform.position += new Vector3(speed * Time.deltaTime, 0.0f);
        //if (player.transform.position.y > this.transform.position.y)
        //    gameObject.transform.position += new Vector3(0.0f, speed * Time.deltaTime);
        //if (player.transform.position.x < this.transform.position.x)
        //    gameObject.transform.position += new Vector3(-speed * Time.deltaTime, 0.0f);
        //if (player.transform.position.y < this.transform.position.y)
        //    gameObject.transform.position += new Vector3(0.0f, -speed * Time.deltaTime);
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);
    }
}
