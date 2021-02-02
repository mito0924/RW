using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement2 : MonoBehaviour {

    public float dirY, moveSpeed = 5f;
    public bool moveUp = true;
    /*플랫폼 위치, 플랫폼의 인스펙터를 열고 플랫폼의 위치에따라 Transform, Position이 바뀌는걸로
    위치 설정가능*/
    public float positionu = 0;//상하 이동경로
    public float positiond = 0;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > positionu)
        {
            moveUp = false;
        }
        if (transform.position.y < positiond)
        {
            moveUp = true;
        }
        if (moveUp)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y+moveSpeed*Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y-moveSpeed*Time.deltaTime);
        }
    }
}
