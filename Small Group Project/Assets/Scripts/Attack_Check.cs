using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Check : MonoBehaviour {

    //적이 공격할 상황인지 확인
    public RangeBunny turretAI;
    public bool isLeft = false;

    void Awake()
    {
        turretAI = gameObject.GetComponentInParent<RangeBunny>();
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (isLeft)
            {
                turretAI.Attack(false);
            }
            else
            {
                turretAI.Attack(true);
            }
        }
    }
}
