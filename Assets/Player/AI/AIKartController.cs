using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIKartController : MonoBehaviour
{
    // Start is called before the first frame update
    private KartController kartController;
    private PlayerData playerData;
    public Node currentNode;
    public NavMeshAgent agent;

    void Start()
    {
        kartController = GetComponentInChildren<KartController>();
        playerData = GetComponentInChildren<PlayerData>();
        currentNode = GameObject.Find("NodeStart").GetComponent<Node>();
        //playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(currentNode.nextNode.transform.position);
        if(agent.remainingDistance < 10)
        {
            currentNode = currentNode.nextNode;
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
