using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject player;
    Transform PT;


	// Use this for initialization
	void Start () {
        PT = player.transform;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, PT.position, 5f*Time.deltaTime);
        transform.Translate(0, 0, -10);
	}
}
