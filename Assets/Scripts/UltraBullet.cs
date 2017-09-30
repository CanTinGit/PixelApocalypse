using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltraBullet : MonoBehaviour {

    public float speed;
    public int direction; // 1 up; 2 down; 3 left; 4 right;

    float step;
    

    // Update is called once per frame
    void Update()
    {
        if (direction == 1)
        {
            this.transform.position += new Vector3(0.0f, speed * Time.deltaTime);
        }

        if (direction == 2)
        {
            this.transform.position += new Vector3(0.0f, -speed * Time.deltaTime);
        }

        if (direction == 3)
        {
            this.transform.position += new Vector3(-speed * Time.deltaTime, 0.0f);
        }

        if (direction == 4)
        {
            this.transform.position += new Vector3(speed * Time.deltaTime, 0.0f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().DestoryEnemy();
        }

        if (other.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}
