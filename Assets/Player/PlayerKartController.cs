using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerKartController : MonoBehaviour
{
    // Start is called before the first frame update
    private KartController kartController;
    [SerializeField] PlayerInput playerInput;

    void Start()
    {
        kartController = GetComponentInChildren<KartController>();
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    private bool lastJumpState = false;
    void Update()
    {
        float steering = playerInput.actions["Move"].ReadValue<Vector2>().x;
        float motor = playerInput.actions["Move"].ReadValue<Vector2>().y;
        //float motor = Input.GetAxis("Vertical");
        //float steering = Input.GetAxis("Horizontal");
        kartController.Drive(motor);
        kartController.Turn(steering);
        if (playerInput.actions["Drift"].IsPressed() && lastJumpState == false)
        {
            kartController.StartDrift();
            lastJumpState = true;
        }
        else
        {
            kartController.StopDrift();
            lastJumpState = false;
        }
    }
}
