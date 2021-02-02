using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RangeBunny : MonoBehaviour {

    float dirX;

    public float distance;
    public float attackRange;
    public float shootInterval;//공속
    public float bulletspeed = 100;//총알 속도
    public float bulletTimer;
   

    public GameObject bullet;
    public Transform target;
    public Animator anim;
    public Transform shootPointLeft;
    public Transform shootPointRight;

    [SerializeField]
    float moveSpeed = 3f;//이속
    [SerializeField]
    float rp = 0f;/*근거리 토끼랑 움직이는 메커니즘이 똑같습니다, 차이점이 있으면 근거리 토끼는 
    공격사거리에 플레이어가 오면 가만히 있고, 원거리 토끼는 총을 쏩니다. 총을 쏠 때, 토끼가
    어느 방향을 보고 있느냐에 따라 총알의 방향이 바뀝니다*/
    [SerializeField]
    float lp = 0f;
    Rigidbody2D rb2d;
    bool facingRight = false;
    Vector3 localScale;

    public bool isShootingr = false;
    public bool isShootingl = false;

    
    private void Start()
    {
       
        localScale = transform.localScale;
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        dirX = -1f;
    }
    void Update()
    {

        if (transform.position.x < lp)
        {
            dirX = 1f;
        }
        else if (transform.position.x > rp)
        {
            dirX = -1f;
        }
        if (isShootingr || isShootingl)
        {
            anim.SetBool("isShooting", true);
        }
        else
        {
            anim.SetBool("isShooting", false);
        }
      
    }

    void FixedUpdate()
    {
        if (!isShootingr && !isShootingl)
        {
            rb2d.velocity = new Vector2(dirX * moveSpeed, rb2d.velocity.y);
        }
        else
        {
            rb2d.velocity = Vector2.zero;
        }
    }

    void LateUpdate()
    {
        CheckRight();
    }
    void CheckRight()
    {
        if (dirX > 0)
        {
            facingRight = true;
        }
        else if (dirX < 0)
        {
            facingRight = false;
        }
        if (((facingRight) && (localScale.x > 0) || (!facingRight) && (localScale.x < 0)))
        {
            localScale.x *= -1;
        }
        transform.localScale = localScale;
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("protagonist") && dirX>0)
        {
            isShootingr = true;
        }
        if (col.gameObject.name.Equals("protagonist") && dirX < 0)
        {
            isShootingl = true;
        }
        if (col.CompareTag("Attack"))
        {
           // curHealth--;
           // anim.SetTrigger("isDamaged");
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("protagonist") && dirX > 0)
        {
            isShootingr = false;
        }
        if (col.gameObject.name.Equals("protagonist") && dirX < 0)
        {
            isShootingl = false;
        }
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("protagonist") && dirX > 0)
        {
            isShootingr = true;
        }
        if (col.gameObject.name.Equals("protagonist") && dirX < 0)
        {
            isShootingl = true;
        }
    }

    public void Attack(bool isShooting)
    {
        bulletTimer += Time.deltaTime;

        if (bulletTimer >= shootInterval)
        {
            Vector2 direction = target.transform.position - transform.position;
            direction.Normalize();
            if (isShootingl)
            {
                GameObject bulletClone;
                bulletClone = Instantiate(bullet, shootPointLeft.transform.position, shootPointLeft.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed;
                bulletTimer = 0;
            }
            if (isShootingr)
            {
                GameObject bulletClone;
                bulletClone = Instantiate(bullet, shootPointRight.transform.position, shootPointRight.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed;
                bulletTimer = 0;
            }
        }
    }
}
