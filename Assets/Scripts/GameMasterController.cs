using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterController : MonoBehaviour
{
    public Transform Player1Position, Player2Position;
    public Sprite player2Sprite, player1Sprite, player2Sprite_Attacking, player1Sprite_Attacking;
    public AudioClip player1Walking, player2Walking;

    private bool isPlayer1Activated, isPlayer2Activated;

    private float time;
    private int currentSecond, nextSwapSecond;

    [SerializeField]
    int numberOfPlayers = 0;

    [SerializeField]
    GameObject[] players;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {

        if (numberOfPlayers != 2)
        {
            players = GameObject.FindGameObjectsWithTag(TagNames.PLAYER);
            numberOfPlayers = players.Length;
        }

        else
        {
            time += Time.deltaTime;
            if (time >= 1)
            {
                time -= 1;
                currentSecond++;
            }
            if (currentSecond == nextSwapSecond)
            {
                currentSecond = 0;
                nextSwapSecond = Random.Range(3, 11);
                GameObject[] players = GameObject.FindGameObjectsWithTag(TagNames.PLAYER);
                Vector3 temp = players[0].transform.position;
                players[0].transform.position = players[1].transform.position;
                players[1].transform.position = temp;

                players[0].transform.position += Vector3.up;
                players[1].transform.position += Vector3.up;
            }
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
            info.walking = player1Walking;
            return info;
        }
        if (!isPlayer2Activated) {
            isPlayer2Activated = true;
            info.sprite = player2Sprite;
            info.spriteAttacking = player2Sprite_Attacking;
            info.playerNumber = 2;
            info.startPosition = Player2Position.position;
            info.walking = player2Walking;
            return info;
        }
        if (isPlayer1Activated && isPlayer2Activated) throw new System.Exception("Only 2 players allowed.");
        throw new System.Exception("No players instantiated?");
    }

}
