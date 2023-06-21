using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Kart")
        {
            PlayerData pd = other.GetComponent<PlayerData>();
            pd.GotToCheckPoint = true;
        }
    }
}
