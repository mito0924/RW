using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit1 : MonoBehaviour {

   
    Vector3 movement;
    int movementDirection = 1;     // 0 멈춤 1 상 -1 하 2 우 -2 좌
    int WalkDirection = 1; // 1=위 -1=아래
    public float movePower = 3f;
   


    void Start () {
        StartCoroutine("Change0");
	}
	
	// Update is called once per frame
	void Update () {
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
        else if (movementDirection == 2)
        {
            moveSpeed = Vector3.right;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (movementDirection == -2)
        {
            moveSpeed = Vector3.left;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        transform.position += moveSpeed * movePower * Time.deltaTime;

    }


    IEnumerator Change0()
    {
      
        movementDirection = 1;



        yield return new WaitForSeconds(0.9f);
        StartCoroutine("Change1");

    }


    IEnumerator Change1()
    {
        this.transform.Rotate(new Vector3(0, 0, -90));
        movementDirection = 2;
        
      

        yield return new WaitForSeconds(4.5f);
        StartCoroutine("Change2");
     
    }

    IEnumerator Change2()
    {
        this.transform.Rotate(new Vector3(0, 0, 90));
        movementDirection = -1;
        yield return new WaitForSeconds(0.9f);
        StartCoroutine("Change3");
    }

    IEnumerator Change3()
    {
        this.transform.Rotate(new Vector3(0, 0, 90));
        movementDirection = -2;
        yield return new WaitForSeconds(4.5f);
        StartCoroutine("Change4");
    }

    IEnumerator Change4()
    {
        this.transform.Rotate(new Vector3(0, 0, 90));
        movementDirection = 0;
        yield return new WaitForSeconds(3f);
        StartCoroutine("Change5");
    }

    IEnumerator Change5()
    {
        this.transform.Rotate(new Vector3(0, 0, 180));
        
        yield return new WaitForSeconds(1f);
        StartCoroutine("Change0");
    }


}
