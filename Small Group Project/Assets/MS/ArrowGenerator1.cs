using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator1 : MonoBehaviour{

    public GameObject bombPrefab;
    float span = 1.4f;
    float delta = 0;

    void Update()    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject go = Instantiate(bombPrefab) as GameObject;
            int px = Random.Range(-19, 19);
            go.transform.position = new Vector3(px, 7, 0);
        }
    }
}