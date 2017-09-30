using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public GameObject normalBullet;
    public GameObject ultraBulletUp;
    public GameObject ultraBulletDown;
    public GameObject ultraBulletLeft;
    public GameObject ultraBulletRight;
    public int health;
    public float backspeed;
    public Vector3 force;
    public float backTime;
    bool isBack = false;
    public bool isUltra = false;

    public GameObject[] hearts;
    public int playerHealth = 3;
    public GameObject currentHeart;

    private float ultraCoolDown = 5.0f;
    public GameObject[] ultras;
    public GameObject currentUltra;
    public int ultraNum = 3;
    public float coolDown = 5.0f;
    public GameObject fillingUltra;
    public GameObject ultraSlider;
    // Use this for initialization
    void Start ()
    {
        currentHeart = hearts[playerHealth - 1];
        currentUltra = ultras[2];
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isBack)
        {
            return;
        }
        Move();

        #region normal or ultra
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
        #endregion

        if (ultraNum == 3)
        {
            ultraCoolDown = coolDown;
        }
        else if (ultraNum == 2)
        {
            FillUltraUI(2);
        }
        else if (ultraNum == 1)
        {
            FillUltraUI(1);
        }
        else
        {
            FillUltraUI(0);
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
        if (Input.GetKeyDown(KeyCode.UpArrow) && ultraNum > 0)
        {
            GameObject bullet = Instantiate(ultraBulletUp, transform.position, Quaternion.identity);
            bullet.GetComponent<UltraBullet>().direction = 1;
            ChangeUltraUI();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && ultraNum > 0)
        {
            GameObject bullet = Instantiate(ultraBulletDown, transform.position, Quaternion.identity);
            bullet.GetComponent<UltraBullet>().direction = 2;
            ChangeUltraUI();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && ultraNum > 0)
        {
            GameObject bullet = Instantiate(ultraBulletLeft, transform.position, Quaternion.identity);
            bullet.GetComponent<UltraBullet>().direction = 3;
            ChangeUltraUI();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && ultraNum > 0)
        {
            GameObject bullet = Instantiate(ultraBulletRight, transform.position, Quaternion.identity);
            bullet.GetComponent<UltraBullet>().direction = 4;
            ChangeUltraUI();
        }
        
    }

    public void TakeDamage(int loss, Vector3 backDirection)
    {
        health -= loss;
        isBack = true;
        GetComponent<Rigidbody2D>().velocity = backDirection;
        Invoke("Stop", backTime);

        ChangeHealthUI();
        
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
    void Dead()
    {
        Application.LoadLevel("Start");
    }

    void ChangeHealthUI()
    {
        currentHeart.SetActive(false);
        if (playerHealth >= 2)
        {
            playerHealth--;
            currentHeart = hearts[playerHealth - 1];
        }
        else
        {
            Dead();
        }
    }
    void FillUltraUI(int i)
    {
        ultraCoolDown -= Time.deltaTime;
        ultraSlider.GetComponent<Slider>().value = coolDown - ultraCoolDown;
        if (ultraCoolDown <= 0)
        {

            fillingUltra = ultras[i];
            fillingUltra.SetActive(true);
            ultraCoolDown = coolDown;
            ultraNum++;
            currentUltra = ultras[i];
        }
    }
    void ChangeUltraUI()
    {
        currentUltra.SetActive(false);
        ultraNum--;
        currentUltra = ultras[ultraNum - 1];
    }
}
