using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public GameObject bulletOriginal;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

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
            this.transform.position += new Vector3(-speed * Time.deltaTime,0.0f);
        }


        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += new Vector3(speed * Time.deltaTime, 0.0f);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GameObject bullet = Instantiate(bulletOriginal, transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().direction = 1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            GameObject bullet = Instantiate(bulletOriginal, transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().direction = 2;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GameObject bullet = Instantiate(bulletOriginal, transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().direction = 3;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GameObject bullet = Instantiate(bulletOriginal, transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().direction = 4;
        }


    }
}
