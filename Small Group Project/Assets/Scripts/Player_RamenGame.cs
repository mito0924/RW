using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_RamenGame : MonoBehaviour {

    Animator animator;
    //점프와 이동
    public float maxSpeed = 5;
    public float speed = 100f;
    public float jumpPower = 250f;

    //대쉬 
    public float dashSpeed;
    public float dashTime;
    public float startDashTime;
    public int direction;

    public bool grounded;
    private Rigidbody2D rb2d;

    public float display = 3f;//얼마나 오랬동안 반짝이는지
    public float timeint = 0.1f;//얼마나 자주 반짝이는지

    //스태미너
    int flag = 0;
    public int stamina = 30;
    public int staminaPerSecond = 2;
    private float regenStamina;
    public bool dashing = false;
    public bool nostam = false;

    public int maxHealth = 3;
    public int curHealth = 3;
    public bool invincible = false;

    //체력UI
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Animator anim;

    //공격관련
    private bool attacking = false;
    public float attackDelay = 5f;
    public float currentAttackDelay= 0;
    public Transform pos;
    public Vector2 boxSize;

    private MeleeBunny mb;

    int flaga = 0;

    void Start () {
        //캐릭터의 물리 성질 가져오기
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        mb = gameObject.GetComponentInParent<MeleeBunny>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   


        //점프
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb2d.AddForce(Vector2.up * jumpPower);
            anim.SetBool("isJumping", true);
        }
        if (grounded)
        {
            anim.SetBool("isJumping", false);
        }
        if (currentAttackDelay <= 0)
        {
            anim.SetBool("isAttacking", false);
        }
        if (rb2d.velocity == Vector2.zero)
        {
            anim.SetBool("isWalking", false);
        }
        else
        {
            anim.SetBool("isWalking", true);
        }
        //뒤집기
        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(-0.7868006F, 0.4799541F, 0.1421244F);
            if (flaga == 0)
            {
                transform.Translate(-5F, 0, 0);
                flaga = 1;
            }
        }
        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(0.7868006F, 0.4799541F, 0.1421244F);
            if (flaga == 1)
            {
                transform.Translate(5F, 0, 0);
                flaga = 0;
            }
        }
        //스태미너
        regenStamina += Time.deltaTime * staminaPerSecond;
        if (regenStamina >= 1 && stamina < 30)
        {
            int a = Mathf.FloorToInt(regenStamina);
            stamina += a;
            regenStamina -= a;
        }

        //체력UI
        if (curHealth >= maxHealth)
        {
            curHealth = maxHealth;
        }
        for (int i = 0; i < maxHealth; i++)
        {
            if (i < curHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }


            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = true;
            }
        }

        //공격 관련
        if (currentAttackDelay <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                anim.SetBool("isAttacking", true);
                currentAttackDelay = attackDelay;
                Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
                foreach (Collider2D collider in collider2Ds)
                {
                    Debug.Log(collider.tag);
                    if (collider.tag == "Enemy")
                    {
                        collider.GetComponent<EnemyHealth>().Damage();
                        MeleeBunny.Parry = true;
                        Debug.Log("공격성공");


                    }
                }

                animator.SetTrigger("attack");

                attacking = true;
            }
        }
        else
        {
            currentAttackDelay -= Time.deltaTime;
            if (currentAttackDelay <= 0)
            {
                attacking = false;
            }
        }

    

}




    void FixedUpdate()
    {
        //이동 Horizontal이 뭔지는 Edit -> Project Settings -> Input에서 변경 가능
        float h = Input.GetAxis("Horizontal");
        rb2d.AddForce((Vector2.right * speed) * h);


        //속도제한
        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
            
        }
        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }

        //대쉬
        if(dashing == false)
        {
            if (direction == 0)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetAxis("Horizontal") < -0.1f)
                {
                    direction = 1;
                    stamina-=10;
                    invincible = true;
                    if (stamina <= 0)
                    {
                        direction = 0;
                        stamina+=10;
                    }
                }
                else if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetAxis("Horizontal") > 0.1f)
                {
                    direction = 2;
                    stamina-=10;
                    invincible = true;
                    if (stamina <= 0)
                    {
                        direction = 0;
                        stamina+=10;
                    }
                }
            }
            else
            {
                if (dashTime <= 0)
                {
                    direction = 0;
                    dashTime = startDashTime;
                    rb2d.velocity = Vector2.zero;
                }
                else
                { 
                    dashTime -= Time.deltaTime;
                    if (direction == 1)
                    {
                        rb2d.velocity = Vector2.left * dashSpeed;
                        dashing = true;
                    }
                    else if (direction == 2)
                    {
                        rb2d.velocity = Vector2.right * dashSpeed;
                        dashing = true;
                    }
                }
            }

        }
        if (dashing == true)
        {
            Invoke("resetinv", 1);
            dashing = false;
        }
        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.y = rb2d.velocity.y;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.75f;

        //가상 마찰력(이거 없으면 벽에 붙고 캐릭터가 계속 한방향으로 감) 이거 있는 대신
        //물건 만들때 마다 마찰력 추가 해야됨, 않그러면 inertia 않없어진다
        if (grounded == true) //if (grounded)
        {
            rb2d.velocity = easeVelocity;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag == "flag")
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.Log("flag");
                transform.position = new Vector3(9, 4, 0);
            }
        }

        if (col.tag == "flag2")
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.Log("flag");
                transform.position = new Vector3(-6.5f, 4, 0);
            }
        }


    }

    
        //맞고 나면 무적
        public void Damage(int dmg)
    {
        if (!invincible)
        {
           
            curHealth -= dmg;
            if (curHealth == 0)
            {
                Die();
            }
            invincible = true;
            onenable();
            Invoke("resetinv", 3);
        }
    }


    //무적 상태를 원래로 돌리기
    void resetinv()
    {
        invincible = false;
    }

    //맞을 때 캐릭터가 번쩍거리는거 
    void onenable()
    {
        StartCoroutine(Flash(display, timeint));//시간 세기 시작
    }
    IEnumerator Flash(float time, float intervalTime)
    {
        float elapsedTime = 0f;//시간이 얼마나 지났는지 계산
        while (elapsedTime < time)//미리 정해둔 시간보다 지나간 시간이 더 많으면
        {
            anim.SetTrigger("isHit");
            Renderer[] RendererArray = GetComponentsInChildren<Renderer>();
            foreach (Renderer r in RendererArray)
                r.enabled = false;
            elapsedTime += Time.deltaTime;
            yield return new WaitForSeconds(intervalTime);
            foreach (Renderer r in RendererArray)
                r.enabled = true;
            elapsedTime += Time.deltaTime;
            yield return new WaitForSeconds(intervalTime);
        }
    }
    void Die()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("Moving Platform"))
        {
            this.transform.parent = col.transform;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("Moving Platform"))
        {
            this.transform.parent = null;
        }
    }


    //공격범위 파란 네모
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }


}
