using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mini_Rabbit : MonoBehaviour
{

    //Animator animator;
    Vector3 movement;
    int movementDirection = -1;     // 0 멈춤 1 상 -1 하
    int WalkDirection = 1; // 1=위 -1=아래
    public float movePower = 2.5f;
    private int angle = 0;
   
    void Start()
    {

        //animator = gameObject.GetComponentInChildren<Animator>();

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

        yield return new WaitForSeconds(5f);
        StartCoroutine("Stop");
        //StartCoroutine("Turn");
    }

    IEnumerator Stop()
    {
        movementDirection = 0;

        yield return new WaitForSeconds(3f);
        StartCoroutine("Turn");


    }

    IEnumerator Turn()
    {

        while (angle <= 90) {
            this.transform.Rotate(new Vector3(0, 0, 1));
            angle++;
        }

        angle = 0;

        yield return new WaitForSeconds(3f);
        StartCoroutine("TurnComback");

    }

    IEnumerator TurnComback()
    {
        while (angle <= 90)
        {
            this.transform.Rotate(new Vector3(0, 0, -1));
            angle++;
        }

        angle = 0;

        yield return new WaitForSeconds(3f);
        StartCoroutine("ChangeDirection");

    }

}