using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour {

    public float dirX, moveSpeed = 5f;
    public bool moveRight = true;
    /*플랫폼 위치, 플랫폼의 인스펙터를 열고 플랫폼의 위치에따라 Transform, Position이 바뀌는걸로
    위치 설정가능*/
    public float positionr=0;//좌우 이동경로
    public float positionl=0;
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x > positionr)
        {
            moveRight = false;
        }
        if (transform.position.x < positionl)
        {
            moveRight = true;
        }
        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }
    }
}
