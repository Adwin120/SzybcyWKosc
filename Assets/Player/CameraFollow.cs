using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public float smoothing;
    public float rotationSmoothing;
    public Transform cameraGoalPos;
    public Camera playerCamera;

    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var cameraPost = playerCamera.transform.position;
        var cameraRotation = playerCamera.transform.rotation;

        playerCamera.transform.position = Vector3.Lerp(cameraPost, cameraGoalPos.position, smoothing);
        playerCamera.transform.rotation = Quaternion.Slerp(cameraRotation, cameraGoalPos.rotation, rotationSmoothing);
        //playerCamera.transform.rotation = Quaternion.Euler(new Vector3(
        //    cameraRotation.eulerAngles.x,
        //    cameraRotation.eulerAngles.y,
        //    0
        //));
    }
}
