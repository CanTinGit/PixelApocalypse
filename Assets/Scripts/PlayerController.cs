using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public GameObject normalBulletUp;
    public GameObject normalBulletDown;
    public GameObject normalBulletLeft;
    public GameObject normalBulletRight;
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
    public GameObject ultraStatus;

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

    private Animator animator;
    // Use this for initialization
    void Start ()
    {
        animator = GetComponent<Animator>();
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
            animator.SetTrigger("CharacterRun");
        }

        if (Input.GetKey(KeyCode.S))
        {
            this.transform.position += new Vector3(0.0f, -speed * Time.deltaTime);
            animator.SetTrigger("CharacterRun");
        }


        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += new Vector3(-speed * Time.deltaTime, 0.0f);
            this.transform.localScale = new Vector3(-0.5f, 0.5f,0.5f);
            animator.SetTrigger("CharacterRun");
        }


        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += new Vector3(speed * Time.deltaTime, 0.0f);
            this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            animator.SetTrigger("CharacterRun");
        }
    }

    void NormalShoot()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GameObject bullet = Instantiate(normalBulletUp, transform.position, normalBulletUp.transform.rotation);
            bullet.GetComponent<Bullet>().direction = 1;
            animator.SetTrigger("CharacterAttack");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            GameObject bullet = Instantiate(normalBulletDown, transform.position, normalBulletDown.transform.rotation);
            bullet.GetComponent<Bullet>().direction = 2;
            animator.SetTrigger("CharacterAttack");
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
            GameObject bullet = Instantiate(normalBulletLeft, transform.position, normalBulletLeft.transform.rotation);
            bullet.GetComponent<Bullet>().direction = 3;
            animator.SetTrigger("CharacterAttack");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            GameObject bullet = Instantiate(normalBulletRight, transform.position, normalBulletRight.transform.rotation);
            bullet.GetComponent<Bullet>().direction = 4;
            animator.SetTrigger("CharacterAttack");
        }
    }

    void UltraShoot()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && ultraNum > 0)
        {
            GameObject bullet = Instantiate(ultraBulletUp, transform.position, Quaternion.identity);
            bullet.GetComponent<UltraBullet>().direction = 1;
            animator.SetTrigger("CharacterAttack");
            ChangeUltraUI();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && ultraNum > 0)
        {
            GameObject bullet = Instantiate(ultraBulletDown, transform.position, Quaternion.identity);
            bullet.GetComponent<UltraBullet>().direction = 2;
            animator.SetTrigger("CharacterAttack");
            ChangeUltraUI();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && ultraNum > 0)
        {
            GameObject bullet = Instantiate(ultraBulletLeft, transform.position, Quaternion.identity);
            bullet.GetComponent<UltraBullet>().direction = 3;
            animator.SetTrigger("CharacterAttack");
            ChangeUltraUI();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && ultraNum > 0)
        {
            GameObject bullet = Instantiate(ultraBulletRight, transform.position, Quaternion.identity);
            bullet.GetComponent<UltraBullet>().direction = 4;
            animator.SetTrigger("CharacterAttack");
            ChangeUltraUI();
        }
        
    }

    public void TakeDamage(int loss, Vector3 backDirection)
    {
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
            ultraStatus.SetActive(false);

        }
        else
        {
            isUltra = true;
            ultraStatus.SetActive(true);
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
