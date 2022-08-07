using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIWander: MonoBehaviour
{

    public Transform teatherPoint;
    public float walkRadius = 20f;
    private NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //check are we still moving to point 
        if (!agent.pathPending && agent.remainingDistance < 1f)
        {
            GotoRandomPoint();
        }
    }

    private void GotoRandomPoint()
    {
        Vector3 randomDirection = Random.insideUnitSphere * walkRadius;
        randomDirection += teatherPoint.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, walkRadius, 1);
        agent.destination = hit.position;
    }
}
