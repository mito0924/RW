using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keymanager : MonoBehaviour {

    public static int key = 0;
    public static int moreKey;
    Text howmanyKey;

    void Start () {
        howmanyKey = GetComponent<Text>();
	}
	

	void Update () {
        moreKey = 5 - key;

        if (moreKey > 0)
        {
            howmanyKey.text = "앞으로 " + Keymanager.moreKey.ToString() + "개";
        }
      else
        {
            howmanyKey.text = "중심부로 가는 통로를 찾자!";
        }
	}
}
