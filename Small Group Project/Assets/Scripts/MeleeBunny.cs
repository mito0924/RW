using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeleeBunny : MonoBehaviour {

  

    float dirX;

    [SerializeField]
    float moveSpeed = 3f; //이속
    [SerializeField]
    float rp = 0f; /*오른쪽 어디까지 가는지, Inspector을 열고, 토끼의 위치에 따라 Transform의 Position
    이 바뀌는걸 보고 토끼의 이동 사거리를 정할 수 있다.*/
    [SerializeField]
    float lp = 0f; //왼쪽 어디까지 가는지
    Rigidbody2D rb2d;
    bool facingRight = false;
    Vector3 localScale;
    
   
    public bool Attacked = false;
    static bool isAttacking = false;
    static public bool Parry;
    private bool intherange = false;



    Animator anim;

    private void Start()
    {
       
        localScale = transform.localScale;
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        dirX = -1f;
    }
    void Update()
    {
        //뒤집기 코드
        if (transform.position.x < lp)
        {
            dirX = 1f;
        }
        else if (transform.position.x > rp)
        {
            dirX = -1f;
        }
       /* if (isAttacking)
        {
            anim.SetBool("isAttacking", true);
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }
      */ 
    }

    void FixedUpdate()
    {
        //공격하고 있는게 아니면 이동, 공격 시 움직임 멈추기 - 공격 사거리에 플레이어가 있으면 공격함
        if (!isAttacking)
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
        //뒤집기 
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
        //플레이어와 상호작용
        if (col.CompareTag("Player"))
        {
            Attack();
        }
        if (col.gameObject.name.Equals("protagonist"))
        {
            intherange = true;
           // isAttacking = true;
        }
        if (col.CompareTag("Attack"))
        {
           // curHealth--;

        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        //플레이어가 사정거리에서 나오면 공격멈춤
        if (col.gameObject.name.Equals("protagonist"))
        {
            isAttacking = false;
            intherange = false;
        }
    }


    void Attack()
    {
        isAttacking = true;
        anim.SetBool("isAttacking", true);
        Parry = false;
        anim.SetTrigger("AttackStart");
        Invoke("Parrying", 2f);
    }

    void Parrying()
    {
        //Debug.Log("전:" + Parry);
        if (Parry == true)
        {
            anim.SetBool("Parry", true);
            this.GetComponent<EnemyHealth>().Damage();
        }
        else
        {
            anim.SetBool("Parry", false);
            if (intherange)
            GameObject.Find("protagonist").GetComponent<Player_RamenGame>().Damage(1);

        }
        //Debug.Log("후:" + Parry);
        Parry = false;
        isAttacking = false;
        
       // Invoke("ParrytoFalse", 0.25f);
    }

   /* void ParrytoFalse()
    {
        Parry = false;
        isAttacking = false;
    }
    */
}



