using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public float maxMotorForce = 200;
    [SerializeField]
    public float maxTurnForce = 50;

    //should be 5x smaller when drifting
    public float sideDragMultiplier;
    public float forwardDragMultiplier;
    public float turnDrag;

    public Rigidbody kartRoller;
    public Rigidbody kartBody;


    private float motorForce;
    private float turnForce;

    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        //Debug.Log(forwardVelocity + " " + sideVelocity + " " + kartRoller.velocity.magnitude);
        kartBody.transform.position = kartRoller.transform.position;
    }

    void FixedUpdate()
    {
        //Driving
        if (kartRoller.velocity.magnitude < 50)
        {
            kartRoller.AddForce(kartBody.transform.forward * motorForce);
        }
        kartBody.AddTorque(new Vector3(0, turnForce, 0));

        //Roller Drag
        var forwardVelocity = kartBody.transform.forward * Vector3.Dot(kartRoller.velocity, kartBody.transform.forward);
        var sideVelocity = kartBody.transform.right * Vector3.Dot(kartRoller.velocity, kartBody.transform.right);
        var forwardDrag = forwardVelocity * -1 * forwardDragMultiplier;
        var sideDrag = sideVelocity * -1 * sideDragMultiplier;
        var drag = forwardDrag + sideDrag;
        kartRoller.AddForce(drag);

        //Body Drag
        var degreeDiff = Vector3.Dot(kartRoller.velocity.normalized, kartBody.transform.right);
        Debug.Log(degreeDiff);
        kartBody.AddTorque(new Vector3(0, degreeDiff * turnDrag, 0));
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
