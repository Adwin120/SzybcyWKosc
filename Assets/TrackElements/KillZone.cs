using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    public void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.tag == "Kart")
        {
            Debug.Log("yeet");
            other.transform.parent.gameObject.GetComponent<KartController>().stopVelocity();
            PlayerData pd = other.GetComponent<PlayerData>();

            if (pd.GotToCheckPoint)
            {
                other.GetComponent<Rigidbody>().MovePosition(GameObject.Find("CheckPointTrigger").transform.position);
                other.transform.parent.GetChild(1).GetComponent<Rigidbody>().MovePosition(GameObject.Find("CheckPointTrigger").transform.position);
            }
            else
            {
                other.GetComponent<Rigidbody>().MovePosition(GameObject.Find("FinishLineTrigger").transform.position);
                other.transform.parent.GetChild(1).GetComponent<Rigidbody>().MovePosition(GameObject.Find("FinishLineTrigger").transform.position);
            }
        }
    }
}
