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
    public bool isPixel = false;
    public Sprite pixel;
    public Vector3 scale;

    public List<GameObject> changedGround = new List<GameObject>();

    void Awake()
    {
        scale = transform.localScale;
        player = GameObject.FindGameObjectWithTag("Player");
        changedGround.Clear();
    }

	// Update is called once per frame
	void Update ()
    {
        if (transform.position.x < player.transform.position.x)
            transform.localScale = new Vector3(scale.x,scale.y);
        if (transform.position.x > player.transform.position.x)
            transform.localScale = new Vector3(-scale.x,scale.y);
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);
    }

    public void TakeDamage(int loss)
    {
        health -= loss;
        if (health <= 0)
        {
            isPixel = true;
            canBeDestory = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = pixel;
            gameObject.GetComponent<Animator>().enabled = false;
        }
    }
    
    public void DestoryEnemy()
    {
        if (canBeDestory)
        {
            for(int i = 0; i < changedGround.Count; i++)
            {
                changedGround[i].GetComponent<Ground>().ChangeToOriginal();
            }
            GameManager.instance.enemyCount--;
            Destroy(gameObject);
        }
    }

    public void ChangeGround(GameObject ground)
    {
        if(!isPixel)
            changedGround.Add(ground);
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
