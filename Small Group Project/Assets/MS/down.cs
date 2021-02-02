﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class down : MonoBehaviour
{

    GameObject player;

    void Start()
    {
        this.player = GameObject.Find("protagonist");       // 추가
    }

    void Update()
    {
        transform.Translate(0, -0.1f, 0);
        if (transform.position.y < -7.0f)
        {
            Destroy(gameObject);
        }

        // 충돌 판정 (추가)
        Vector2 p1 = transform.position;              // 화살의 중심 좌표
        Vector2 p2 = this.player.transform.position;  // 플레이어의 중심 좌표
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.5f;                              // 화살의 반경
        float r2 = 1.0f;                              // 플레이어의 반경

        if (d < r1 + r2)
        {
            // 충돌한 경우는 화살을 지운다
            Destroy(gameObject);
        }
    }
}