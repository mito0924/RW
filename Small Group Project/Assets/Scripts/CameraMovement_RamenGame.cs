using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement_RamenGame : MonoBehaviour {

    //카메라 움직임 코드
    private Vector2 velocity;
    public float TimeY;
    public float TimeX;

    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    //카메라 이동
    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, TimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, TimeY);

        transform.position = new Vector3(posX, posY, transform.position.z);
    }
}
