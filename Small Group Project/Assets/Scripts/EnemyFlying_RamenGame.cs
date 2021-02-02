using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.UI;

public class EnemyFlying_RamenGame : MonoBehaviour {

    public Transform target;
    public Transform enemyGFX;
   
    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb2d;

    

    void Start () {
     
        seeker = GetComponent<Seeker>();
        rb2d = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, 0.5f);

	}

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb2d.position, target.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    private void Update()
    {
     
    }

    void FixedUpdate () {
        if (path == null)
        {
            return;
        }
        //주인공에게 도달하면 움직임 멈춤
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        //아니면 "끝까지 도달함"을 거짓으로 세팅
        else
        {
            reachedEndOfPath = false;
        }

        //가야하는 방향, 속도 구하기
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb2d.position).normalized;
        Vector2 force = direction * speed * Time.fixedDeltaTime;

        rb2d.AddForce(force);

        float distance = Vector2.Distance(rb2d.position, path.vectorPath[currentWaypoint]);
        //방향 정하기
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
        //적 뒤집기 코드(적이 좌우 대칭이면 필요 ㄴㄴ)
        if (force.x >= 0.01f)
        {
            enemyGFX.localScale = new Vector3(15f, 15f, 1f);
        }
        else if (force.x <= -0.01f)
        {
           enemyGFX.localScale = new Vector3(15f, 15f, 1f);
        }


	}
    //플레이어와 상호작용
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.GetComponent<Player_RamenGame>().Damage(1);
        }
        if (col.CompareTag("Attack"))
        {
            //curHealth--;
        }
    }
}
