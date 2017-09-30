using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public GameObject normalBullet;
    public GameObject ultraBullet;
    public int health;
    public float backspeed;
    public Vector3 force;
    public float backTime;
    bool isBack = false;
    public bool isUltra = false;
    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isBack)
        {
            return;
        }
        Move();
        if (Input.GetKeyDown(KeyCode.R))
        {
            changeShootStyle(ref isUltra);
        }
        if (isUltra)
        {
            UltraShoot();
        }
        else
        {
            NormalShoot();
        }
        
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position += new Vector3(0.0f, speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            this.transform.position += new Vector3(0.0f, -speed * Time.deltaTime);
        }


        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += new Vector3(-speed * Time.deltaTime, 0.0f);
        }


        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += new Vector3(speed * Time.deltaTime, 0.0f);
        }
    }

    void NormalShoot()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GameObject bullet = Instantiate(normalBullet, transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().direction = 1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            GameObject bullet = Instantiate(normalBullet, transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().direction = 2;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GameObject bullet = Instantiate(normalBullet, transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().direction = 3;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GameObject bullet = Instantiate(normalBullet, transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().direction = 4;
        }
    }

    void UltraShoot()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GameObject bullet = Instantiate(ultraBullet, transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().direction = 1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            GameObject bullet = Instantiate(ultraBullet, transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().direction = 2;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GameObject bullet = Instantiate(ultraBullet, transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().direction = 3;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GameObject bullet = Instantiate(ultraBullet, transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().direction = 4;
        }
    }

    public void TakeDamage(int loss, Vector3 backDirection)
    {
        health -= loss;
        isBack = true;
        GetComponent<Rigidbody2D>().velocity = backDirection;
        Invoke("Stop", backTime);
    }

    void Stop()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(0.0f, 0.0f);
        isBack = false;
    }

    void changeShootStyle(ref bool isUltra)
    {
        if (isUltra)
        {
            isUltra = false;
            //UI

        }
        else
        {
            isUltra = true;
            //
        }
    }
}
