using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

public class AIKartController : MonoBehaviour
{
    // Start is called before the first frame update
    private KartController kartController;
    private PlayerData playerData;
    public Waypoint currentWaypoint;
    public NavMeshAgent agent;

    void Start()
    {
        kartController = GetComponentInChildren<KartController>();
        playerData = GetComponentInChildren<PlayerData>();
        currentWaypoint = GameObject.Find("Waypoint 0").GetComponent<Waypoint>();
        //playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        //agent.SetDestination(currentWaypoint.nextWaypoint.transform.position);
        agent.SetDestination(currentWaypoint.transform.position);
        if (agent.remainingDistance < 30)
        {
            currentWaypoint = currentWaypoint.nextWaypoint;
            agent.SetDestination(currentWaypoint.transform.position);
        }
        Debug.DrawRay(kartController.getPosition(), agent.desiredVelocity *100, Color.blue, 0, false);

        var kartBody = kartController.getBody();
        float angle = Vector3.SignedAngle(kartBody.transform.forward, agent.desiredVelocity, Vector3.up);
        Debug.Log(angle.ToString() + " angle");
        angle = angle / 180f;

        float driveSpeed = 1f - Mathf.Abs(angle) * 1f;
        kartController.Drive(driveSpeed);
        kartController.Turn(Mathf.Sign(angle));
        //if (playerInput.actions["Drift"].IsPressed())
        //{
        //    kartController.StartDrift();
        //}
        //else
        //{
        //    kartController.StopDrift();
        //}
    }
}
