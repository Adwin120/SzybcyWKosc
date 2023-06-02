using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public float maxMotorForce;
    [SerializeField]
    public float maxTurnForce;

    private Rigidbody kartBody;
    private float motorForce = 0;
    private float turnForce = 0;

    void Start()
    {
        kartBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (kartBody.velocity.magnitude < 50)
        {
            kartBody.AddForce(kartBody.transform.TransformDirection(new Vector3(0, 0, motorForce)));
        }
        kartBody.AddTorque(new Vector3(0, turnForce, 0));
    }

    public void Drive(float percent)
    {
        motorForce = maxMotorForce * percent;
    }

    public void Turn(float percent)
    {
        turnForce = maxTurnForce * percent;
    }
}
