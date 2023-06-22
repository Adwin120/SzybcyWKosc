using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

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
        agent.SetDestination(GameObject.Find("CheckPointTrigger").transform.position);
        if(agent.remainingDistance < 30)
        {
            currentWaypoint = currentWaypoint.nextWaypoint;
        }
        Debug.Log(currentWaypoint.ToString());
        //float steering = playerInput.actions["Move"].ReadValue<Vector2>().x;
        //float motor = playerInput.actions["Move"].ReadValue<Vector2>().y;
        //float motor = Input.GetAxis("Vertical");
        //float steering = Input.GetAxis("Horizontal");
        //var turnTowardNavSteeringTarget = agent.path.;
        //Debug.Log(turnTowardNavSteeringTarget.ToString());
        //float turnAngle = turnTowardNavSteeringTarget.x - kartController.getRotation().x;
        //turnTowardNavSteeringTarget.x
        //float angle = Vector3.SignedAngle(kartController.getRotation(), turnTowardNavSteeringTarget, Vector3.up);
        //angle = angle / 180f;
        float angle = 0;
        float driveSpeed = 0.5f - Mathf.Abs(angle) * 0.5f;
        //kartController.Drive(driveSpeed);
        //kartController.Turn(angle/20);
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
