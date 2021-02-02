using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    //총알 코드
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger != true && col.tag!=("Turret"))
        {
            if (col.CompareTag("Player"))
            {
                col.GetComponent<Player_RamenGame>().Damage(1);
            }
            Destroy(gameObject);
        }
    }
}
