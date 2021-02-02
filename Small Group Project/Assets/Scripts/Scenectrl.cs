using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenectrl : MonoBehaviour
{
    public float remain = 10.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (remain == 0)
        {
            Debug.Log("잘됨");
            SceneManager.LoadScene("Map_3");
        }
    }
}
