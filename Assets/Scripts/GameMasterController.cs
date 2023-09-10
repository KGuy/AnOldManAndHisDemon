using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterController : MonoBehaviour
{
    public Transform Player1Position, Player2Position;
    public Sprite player2Sprite, player1Sprite, player2Sprite_Attacking, player1Sprite_Attacking;

    private bool isPlayer1Activated, isPlayer2Activated;

    private float time;
    private int currentSecond, nextSwapSecond;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        time += Time.deltaTime;
        if ( time >= 1) {
            time -= 1;
            currentSecond++;
        }
        if (currentSecond == nextSwapSecond) {
            currentSecond = 0;
            nextSwapSecond = Random.Range(3, 11);
            GameObject[] players = GameObject.FindGameObjectsWithTag(TagNames.PLAYER);
            Vector3 temp = players[0].transform.position;
            players[0].transform.position = players[1].transform.position;
            players[1].transform.position = temp;
        }
    }

    public PlayerInfo getStartPosition() {
        PlayerInfo info = new PlayerInfo();
        if (!isPlayer1Activated) {
            isPlayer1Activated = true;
            info.sprite = player1Sprite;
            info.spriteAttacking = player1Sprite_Attacking;
            info.playerNumber = 1;
            info.startPosition = Player1Position.position;
            return info;
        }
        if (!isPlayer2Activated) {
            isPlayer2Activated = true;
            info.sprite = player2Sprite;
            info.spriteAttacking = player2Sprite_Attacking;
            info.playerNumber = 2;
            info.startPosition = Player2Position.position;
            return info;
        }
        if (isPlayer1Activated && isPlayer2Activated) throw new System.Exception("Only 2 players allowed.");
        throw new System.Exception("No players instantiated?");
    }

}
