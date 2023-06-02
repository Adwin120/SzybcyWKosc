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
    void Update()
    {
        float motor = Input.GetAxis("Vertical");
        float steering = Input.GetAxis("Horizontal");
        Debug.Log(motor);
        Debug.Log(steering);
        kartController.Drive(motor);
        kartController.Turn(steering);
    }
}
