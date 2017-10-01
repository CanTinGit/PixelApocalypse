using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

    public GameObject wasd;
    public GameObject move;
    public GameObject arrows;
    public GameObject shoot;
    GameObject enemy;
    public GameObject ultra;
    public GameObject pac;

    int moveCount= 0;

	// Use this for initialization
	void Start () {
        arrows.SetActive(false);
        ultra.SetActive(false);
        pac.SetActive(false);
        shoot.SetActive(false);
        enemy = GameObject.FindGameObjectWithTag("TutorialEnemy");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            Destroy(wasd, 2.0f);
            Destroy(move, 2.0f);
            Invoke("AppearShoot", 2.0f);
        }
        if (enemy.GetComponent<TutorialEnemy>().canBeDestory == true)
        {
            Destroy(shoot.gameObject);
            ultra.SetActive(true);
            pac.SetActive(true);
        }

    }

    void AppearShoot()
    {
        arrows.SetActive(true);
        shoot.SetActive(true);
    }
}
