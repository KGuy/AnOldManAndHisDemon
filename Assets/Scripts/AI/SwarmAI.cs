using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SwarmAI : MonoBehaviour
{
    public PoolSpawner mother;
    public NavMeshAgent agent;
    public GameObject target;


    public float range = 10.0f;
    public float maxRange = 50f;
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }

    public GameObject FindClosestPlayer()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = FindClosestPlayer();
    }

        // Update is called once per frame
    private void FixedUpdate()
    {
        if(Vector3.Distance(transform.position, target.transform.position) < maxRange)
        {
            Vector3 NavPoint;
            if (RandomPoint(target.transform.position, range, out NavPoint))
            {
                Debug.DrawRay(NavPoint, Vector3.up, Color.blue, 1.0f);
            }

            agent.SetDestination(NavPoint);
        }
        else
        {
            agent.SetDestination(transform.position);
        }
    }

    //private void OnDestroy()
    //{
    //    
    //}
}
