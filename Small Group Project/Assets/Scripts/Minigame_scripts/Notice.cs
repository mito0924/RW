using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notice : MonoBehaviour {

    public Image notice_start;
	void Start () {
        notice_start.gameObject.SetActive(true);

        
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            notice_start.gameObject.SetActive(false);
        }

    }


}
