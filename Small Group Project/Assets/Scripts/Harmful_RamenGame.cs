using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harmful_RamenGame : MonoBehaviour {

    private Player_RamenGame character;

    // Use this for initialization
    void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_RamenGame>();
    }
    //장애물 코드, 맞으면 1딜
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            character.Damage(1);
        }
    }
}
