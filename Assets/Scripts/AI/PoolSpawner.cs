using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PoolSpawner : MonoBehaviour
{
    public GameObject[] monsterPrefabs;

    [SerializeField]
    int MonsterReserve;

    [SerializeField]
    int spawnRateA;

    float elapsedTime = 0;
    [SerializeField]
    float secondsBetweenSpawn;

    [SerializeField]
    int numberOfPlayers = 0;

    [SerializeField]
    GameObject[] players;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(numberOfPlayers != 2)
        {
            players = GameObject.FindGameObjectsWithTag(TagNames.PLAYER);
            numberOfPlayers = players.Length;
        }
        else
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime > secondsBetweenSpawn)
            {
                elapsedTime = 0;
                Debug.Log(true);

                if (MonsterReserve > 0)
                {
                    GameObject GO = Instantiate(monsterPrefabs[Random.Range(0, 2)], transform.position + getRandomPosition(6, 0, 6), getRandomRotation());
                    MonsterReserve -= 1;
                }
            }
        }
    }

    Vector3 getRandomPosition(float xMax, float yMax, float zMax)
    {
        return new Vector3(Random.Range(0, xMax), Random.Range(0, yMax), Random.Range(0, zMax));
    }

    Quaternion getRandomRotation()
    {
        Quaternion randomRotation = Quaternion.Euler(Random.Range(0, 360), 0, 0);
        return randomRotation;

    }

}


