using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turret : MonoBehaviour {

    //0 = none, 1 = left, 2 = right, 3 = both //터렛 인스펙터를 열고 총알 방향을 설정 할 수 있습니다.
    //터렛의 아트를 뒤집어서 사용가능
    public int ShootWhere = 0;
    public bool allow = false;
    public float distance;
    public float attackRange;
    public float shootInterval;//공속
    public float bulletspeed = 100;//총알 속도
    public float bulletTimer;
    public float curHealth = 5;//체력
    public float maxHealth = 5;

    public GameObject bullet;
    public Transform target;
    public Animator anim;
    public Transform shootPointLeft;
    public Transform shootPointRight;

    [Header("Unity Stuff")]
    public Image healthBar;

    // Use this for initialization
    void Start () {
        curHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        if (curHealth <= 0)
        {
            Destroy(gameObject);
        }
        healthBar.fillAmount = curHealth / maxHealth;
        Attack(ShootWhere, allow);
	}

    public void Attack(int ShootWhere, bool allow)
    {
        bulletTimer += Time.deltaTime;

        if (bulletTimer >= shootInterval)
        {
            Vector2 direction = target.transform.position - transform.position;
            direction.Normalize();

            if (ShootWhere == 1 && allow == true)
            {
                GameObject bulletClone;
                bulletClone = Instantiate(bullet, shootPointLeft.transform.position, shootPointLeft.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed;
                bulletTimer = 0;
            }
            else if (ShootWhere == 2 && allow == true)
            {
                GameObject bulletClone;
                bulletClone = Instantiate(bullet, shootPointRight.transform.position, shootPointRight.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed;
                bulletTimer = 0;
            }
            else if (ShootWhere == 3 && allow == true)
            {
                GameObject bulletClone;
                bulletClone = Instantiate(bullet, shootPointRight.transform.position, shootPointRight.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed;
                bulletClone = Instantiate(bullet, shootPointLeft.transform.position, shootPointLeft.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed;
                bulletTimer = 0;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("protagonist"))
        {
            allow = true;
        }
        if (col.CompareTag("Attack"))
        {
            curHealth--;
        }
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("protagonist"))
        {
            allow = true;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.name.Equals("protagonist"))
        {
            allow = false;
        }
    }
}
