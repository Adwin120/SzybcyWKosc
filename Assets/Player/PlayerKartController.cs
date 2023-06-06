using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKartController : MonoBehaviour
{
    // Start is called before the first frame update
    private KartController kartController;

    void Start()
    {
        kartController = GetComponentInChildren<KartController>();
    }

    // Update is called once per frame
    private bool lastJumpState = false;
    void Update()
    {
        float motor = Input.GetAxis("Vertical");
        float steering = Input.GetAxis("Horizontal");
        kartController.Drive(motor);
        kartController.Turn(steering);
        if (Input.GetAxis("Jump") > 0 && lastJumpState == false)
        {
            kartController.StartDrift();
            lastJumpState = true;
        }
        if (Input.GetAxis("Jump") == 0 && lastJumpState == true)
        {
            kartController.StopDrift();
            lastJumpState = false;
        }
    }
}
