using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : MonoBehaviour
{

    public Transform[] waypoints;
    private int currentWPTarget = 0;
    private UnityEngine.AI.NavMeshAgent agent;

    private bool objectDetected;
    public float detectionDistance = 30f;
    public float detectionRadius = 2f;
    private RaycastHit raycastHitInfo;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }
        else
        {
            CheckIfPlayerInLos();
        }
    }

    private void CheckIfPlayerInLos()
    {
        objectDetected = Physics.SphereCast(transform.position, detectionRadius, transform.forward, out raycastHitInfo, detectionDistance);
        if (objectDetected)
        {
            if (raycastHitInfo.transform.CompareTag("Player"))
            {
                Debug.Log("I see you");
                GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
                agent.destination = raycastHitInfo.transform.position;
            }
            else
            {
                GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
            }
        }
    }

    private void GotoNextPoint()
    {
        if (waypoints.Length == 0)
        {
            return;
        }
        agent.destination = waypoints[currentWPTarget].position;
        currentWPTarget = (currentWPTarget + 1) % waypoints.Length;

    }

}