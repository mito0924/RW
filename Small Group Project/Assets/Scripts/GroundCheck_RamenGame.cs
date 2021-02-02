using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck_RamenGame : MonoBehaviour {

    //Reference to code ramengame
    private Player_RamenGame player;

    void Start()
    {
        player = gameObject.GetComponentInParent<Player_RamenGame>();
    }

    //땅위에 있나없나
    void OnTriggerEnter2D(Collider2D col)
    {
        player.grounded = true;
    }
    void OnTriggerStay2D(Collider2D col)
    {
        player.grounded = true;
    }
    void OnTriggerExit2D(Collider2D col)
    {
        player.grounded = false;
    }
}
