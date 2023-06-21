using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerScript : MonoBehaviour
{
    // Start is called before the first frame update
    private int DRIVEABLE_LAYER = 9;

    private KartController kartController;
    void Start()
    {
        kartController = this.GetComponentInParent<KartController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == DRIVEABLE_LAYER)
        {
            kartController.isOnGround = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == DRIVEABLE_LAYER)
        {
            kartController.isOnGround = false;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.contactCount == 0) return;
        if (collision.gameObject.layer == DRIVEABLE_LAYER)
        {
            kartController.isOnGround = true;
            kartController.groundNormal = collision.GetContact(0).normal;
        }
    }
}
