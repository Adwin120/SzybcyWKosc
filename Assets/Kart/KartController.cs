using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartController : MonoBehaviour
{
    public float maxMotorForce = 200;
    public float airControlMotorForce = 50;
    public float speedCap = 50;
    public float maxTurnForce = 50;

    public float sideDragMultiplier;
    public float driftSideDragMultuplier;
    public float forwardDragMultiplier;
    public float turnDrag;
    public float driftTurnDrag;


    public Rigidbody kartRoller;
    public Rigidbody kartBody;
    public TrailRenderer[] trailEmitters;

    [System.NonSerialized]
    public bool isOnGround = false;

    private float motorForce;
    private float turnForce;
    private bool isDrifting;
    private float currentSideDragMultiplier;
    private float currentTurnDrag;


    [System.NonSerialized]
    public Vector3 groundNormal = Vector3.zero;
    private void alignKartBodyToSurface()
    {
        var angleTransformation = Quaternion.FromToRotation(kartBody.transform.up, groundNormal);
        var targetAngle = angleTransformation * kartBody.transform.rotation;
        var debugColor = Color.red;
        if (Quaternion.Angle(targetAngle, kartBody.transform.rotation) <= 50 || Quaternion.Angle(targetAngle, Quaternion.identity) < 45)
        {
            debugColor = Color.white;
            kartBody.transform.rotation = Quaternion.Slerp(kartBody.transform.rotation, targetAngle, 0.1f);
        }
        Debug.DrawRay(kartBody.position, groundNormal * 100, debugColor, 0, false);
    }

    public void stopVelocity()
    {
        kartBody.velocity = Vector3.zero;
        kartRoller.velocity = Vector3.zero;
    }

    public Quaternion getBodyRotation()
    {
        return kartBody.transform.rotation;
    }

    private void applyControlForces()
    {
        var speed = kartRoller.velocity.magnitude;
        var driveForce = (speed < speedCap) 
            ? kartBody.transform.forward * motorForce 
            : Vector3.zero;
        if (!isOnGround)
        {
            driveForce.y = 0;
        }

        kartRoller.AddForce(driveForce);
        kartBody.AddTorque(new Vector3(0, turnForce, 0));
    }

    private void applyRollerDrag()
    {
        var forwardDir = kartBody.transform.forward;
        var sideDir = kartBody.transform.right;

        var forwardVelocity = forwardDir * Vector3.Dot(kartRoller.velocity, forwardDir);
        var sideVelocity = sideDir * Vector3.Dot(kartRoller.velocity, sideDir);

        var forwardDrag = forwardVelocity * -1 * forwardDragMultiplier;
        var sideDrag = sideVelocity * -1 * currentSideDragMultiplier;

        var drag = forwardDrag + sideDrag;
        kartRoller.AddForce(drag);
        
    }

    private void applyTurnDrag()
    {
        var speed = kartRoller.velocity.magnitude;
        var degreeDiff = Vector3.Dot(kartRoller.velocity.normalized, kartBody.transform.right);
        kartBody.AddTorque(new Vector3(0, degreeDiff * Mathf.Max(Mathf.Log(speed), 0) * currentTurnDrag, 0));
    }

    void Start()
    {
        currentSideDragMultiplier = sideDragMultiplier;
        currentTurnDrag = turnDrag;
    }

    // Update is called once per frame
    private void Update()
    {
        foreach (TrailRenderer t in trailEmitters)
        {
            t.emitting = isDrifting && isOnGround;
        }
    }

    void FixedUpdate()
    {
        alignKartBodyToSurface();
        applyControlForces();
        if (isOnGround)
        {
            applyRollerDrag();
        }
        applyTurnDrag();
    }

    public void Drive(float percent)
    {
        motorForce = (isOnGround ? maxMotorForce : airControlMotorForce) * percent;
    }

    public void Turn(float percent)
    {
        turnForce = maxTurnForce * percent;
    }

    public void StartDrift()
    {
        isDrifting = true;
        currentSideDragMultiplier = driftSideDragMultuplier;
        currentTurnDrag = driftTurnDrag;
    }

    public void StopDrift()
    {
        isDrifting = false;
        currentSideDragMultiplier = sideDragMultiplier;
        currentTurnDrag = turnDrag;
    }
}
