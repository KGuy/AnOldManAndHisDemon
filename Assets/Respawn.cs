using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        SimpleMultiplayerPlayer simpleMultiplayerPlayer = other.GetComponent<SimpleMultiplayerPlayer>();
        other.transform.position = simpleMultiplayerPlayer.startPosition;
    }

}
