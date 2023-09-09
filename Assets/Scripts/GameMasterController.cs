using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterController : MonoBehaviour
{
    public Transform Player1Position, Player2Position;
    private bool isPlayer1Activated, isPlayer2Activated;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 getStartPosition() {
        if (!isPlayer1Activated) {
            print("here1");
            isPlayer1Activated = true;
            return Player1Position.position;
        }
        if (!isPlayer2Activated) {
            print("here2");
            isPlayer2Activated = true;
            return Player2Position.position;
        }
        if (isPlayer1Activated && isPlayer2Activated) throw new System.Exception("Only 2 players allowed.");
        throw new System.Exception("No players instantiated?");
    }

}
