using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eat : MonoBehaviour {

    GameObject player;

    void Start()
    {
        this.player = GameObject.Find("protagonist");       // 추가
    }

    void Update()
    {
        

        // 충돌 판정 (추가)
        Vector2 p1 = transform.position;              // 화살의 중심 좌표
        Vector2 p2 = this.player.transform.position;  // 플레이어의 중심 좌표
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.5f;                              // 화살의 반경
        float r2 = 1.0f;                              // 플레이어의 반경

        if (d < r1 + r2)
        {

            var cur = GameObject.Find("protagonist").GetComponent<Player_RamenGame>();
            if (cur.curHealth > 0)
            {
                cur.curHealth++;
                Destroy(gameObject);
            }
        }
    }
}