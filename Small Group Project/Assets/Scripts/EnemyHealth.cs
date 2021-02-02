using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [Header("Unity Stuff")]
    public Image healthBar;

    public float curHealth = 5;
    public float maxHealth = 5;

    Animator anim;

    void Start()
    {
        curHealth = maxHealth;
        anim = GetComponent<Animator>();

    }



    // Update is called once per frame
    void Update()
    {
        var rem = GameObject.Find("GameCtrl").GetComponent<Scenectrl>();
        healthBar.fillAmount = curHealth / maxHealth;

        //피가 0이면 죽기
        if (curHealth <= 0)
        {

            Destroy(gameObject);
            rem.remain--;
            Debug.Log("쥬금");

        }



    }

    public void Damage()
    {
        curHealth--;
        anim.SetTrigger("isDamaged");
    }

}