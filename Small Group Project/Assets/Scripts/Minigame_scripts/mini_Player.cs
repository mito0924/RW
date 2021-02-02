using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class mini_Player : MonoBehaviour {

    public float moveSpeed=4f;
    private float Dirx;
    private float Diry;
    Vector2 lastMove;

    bool Walking;

    Animator animator;

    public Image notice_key;
	
	void Start () {
        animator = GetComponent<Animator>();
        notice_key.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        Walking = false;
        Dirx = Input.GetAxisRaw("Horizontal");
        Diry = Input.GetAxisRaw("Vertical");

  
        

        if (Dirx != 0)
        {
          

            transform.Translate(new Vector3(Dirx * moveSpeed * Time.deltaTime, 0f, 0f));
            Walking = true;
            lastMove = new Vector2(Dirx, 0f);
        }

        if (Diry != 0)
        {
            transform.Translate(new Vector3(0f, Diry * moveSpeed * Time.deltaTime, 0f));
            Walking = true;
            lastMove = new Vector2(0f, Diry);
        }

        animator.SetFloat("Dirx", Dirx);
        animator.SetFloat("Diry", Diry);
        animator.SetBool("Walking", Walking);
        animator.SetFloat("LastMoveX", lastMove.x);
        animator.SetFloat("LastMoveY", lastMove.y);


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Item")
        {
            Keymanager.key++;
            collision.gameObject.SetActive(false);
        }


        if (collision.tag == "Finish")
        {

            if (Keymanager.key == 5)
            {
                SceneManager.LoadScene("MiniGameScene");
            }
            else
            {
                notice_key.gameObject.SetActive(true);
                Invoke("Disa_notice_key", 1f);
            }
          
        }

    }

    void Disa_notice_key()
    {
        notice_key.gameObject.SetActive(false);
    }

}
