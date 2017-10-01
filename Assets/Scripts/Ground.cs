using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {

    public bool isChanged = false;
    public Sprite Enemyground;
    public Sprite originalGround;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (isChanged == false && other.tag == "Enemy" && other.gameObject.GetComponent<Enemy>().canBeDestory == false)
        {
            other.GetComponent<Enemy>().ChangeGround(gameObject);
            ChangeToEnemy();
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
