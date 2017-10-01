using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {

    public bool isChanged = false;
    public Sprite Enemyground;
    public Sprite originalGround;
    public float slowSpeed = 4;
    public float normal = 5;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isChanged == false && other.tag == "Enemy")
        {
            if (!other.GetComponent<Enemy>().isPixel)
            {
                other.GetComponent<Enemy>().ChangeGround(gameObject);
                ChangeToEnemy();
            }
           
        }

        if (isChanged == true && other.tag == "Player")
        {
            other.GetComponent<PlayerController>().speed = slowSpeed;
        }

        if (isChanged == false && other.tag == "Player")
        {
            other.GetComponent<PlayerController>().speed = normal;
        }
    }

    public void ChangeToOriginal()
    {
        this.GetComponent<SpriteRenderer>().sprite = originalGround;
        isChanged = false;
    }

    public void ChangeToEnemy()
    {
        this.GetComponent<SpriteRenderer>().sprite = Enemyground;
        isChanged = true;
    }
}
