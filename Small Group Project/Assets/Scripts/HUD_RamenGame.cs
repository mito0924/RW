using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HUD_RamenGame : MonoBehaviour {

    public Sprite[] EnergySprites;
    public Image EnergyUI;
    private Player_RamenGame player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_RamenGame>();
	}
	
	// Update is called once per frame
	void Update () {
        //스태미너가 조금이라도 있으면 디스플레이
        if(player.stamina >= 0)
        {
            EnergyUI.sprite = EnergySprites[player.stamina / 10];
        }
	}
}
