﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit35 : MonoBehaviour {

    Vector3 movement;
    int movementDirection = 1;     // 0 멈춤 1 상 -1 하
    int WalkDirection = 1; 
    public float movePower = 3.2f;

    void Start()
    {
        StartCoroutine("ChangeDirection");
    }


    void Update()
    {
        Vector3 moveSpeed = Vector3.zero;


        if (movementDirection == 1)
        {
            moveSpeed = Vector3.up;
            transform.localScale = new Vector3(1, 1, 1);

        }
        else if (movementDirection == -1)
        {
            moveSpeed = Vector3.down;
            transform.localScale = new Vector3(1, -1, 1);
        }


        transform.position += moveSpeed * movePower * Time.deltaTime;

    }


    IEnumerator ChangeDirection()
    {

        WalkDirection *= -1;
        if (WalkDirection == 1)
        {
            movementDirection = 1;
        }
        else
            movementDirection = -1;

        yield return new WaitForSeconds(2.5f);
        StartCoroutine("Stop");

    }

    IEnumerator Stop()
    {
        movementDirection = 0;

        yield return new WaitForSeconds(1f);
        StartCoroutine("ChangeDirection");


    }

   /* IEnumerator Turn()
    {

       
        this.transform.Rotate(new Vector3(0, 0, 180));
       


        yield return new WaitForSeconds(2f);
        StartCoroutine("ChangeDirection");

    }

  */


}
