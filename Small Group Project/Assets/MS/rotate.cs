using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class rotate : MonoBehaviour
{



    // Update is called once per frame

    void Update()
    {



        // Time.deltaTime은 

        // '지난 프레임이 완료되는데 까지 걸린 시간을 나타내며, 단위는 초를 사용' 한다.

        // 아래 수식은 초당 15, 30, 45를 이동하라는 의미이다.

        transform.Rotate(new Vector3(0,0,-10) * Time.deltaTime);

    }



}