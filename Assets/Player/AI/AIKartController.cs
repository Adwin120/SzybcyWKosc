using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIKartController : MonoBehaviour
{
    // Start is called before the first frame update
    private KartController kartController;
    private PlayerData playerData;
    //public Waypoint currentWaypoint;
    public NavMeshAgent agent;

    void Start()
    {
        kartController = GetComponentInChildren<KartController>();
        playerData = GetComponentInChildren<PlayerData>();
        //currentWaypoint = GameObject.Find("NodeStart").GetComponent<Waypoint>();
        //playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        //agent.SetDestination(currentWaypoint.nextWaypoint.transform.position);
        if(agent.remainingDistance < 10)
        {
            //currentWaypoint = currentWaypoint.nextWaypoint;
        }
        //float steering = playerInput.actions["Move"].ReadValue<Vector2>().x;
        //float motor = playerInput.actions["Move"].ReadValue<Vector2>().y;
        //float motor = Input.GetAxis("Vertical");
        //float steering = Input.GetAxis("Horizontal");
        kartController.Drive(1);
        //kartController.Turn(steering);
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
