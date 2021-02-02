using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealGenerator : MonoBehaviour {

    public GameObject healPrefab;
    float span = 15.0f;
    float delta = 0;

    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject go = Instantiate(healPrefab) as GameObject;
            go.transform.position = new Vector3(15, -5, 0);
        }
    }
}