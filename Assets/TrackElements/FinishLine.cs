using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    // plan jest taki �e finish line b�dzie kontrolowa�o ca�� gr� czy co� xd

    public int laps = 2;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Kart")
        {
            PlayerData pd = other.GetComponent<PlayerData>();

            if (pd.GotToCheckPoint)
            {
                pd.LapCount++;
                pd.GotToCheckPoint = false;
            }

            if (pd.LapCount == laps)
            {
                Debug.Log("wygrywa " + other.name);
            }

            Debug.Log(pd.LapCount);
        }
    }

    static List<GameObject> Players = new List<GameObject>();

    public static void RegisterPlayer(GameObject playerGo)
    {
        Players.Add(playerGo);
    }

    public static void UnregisterPlayer(GameObject playerGo)
    {
        Players.Remove(playerGo);
    }

    public void RegisterAllPlayers()
    {
        // ai trzeba te� b�dzie otagowa� player
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject p in players)
        {
            RegisterPlayer(p);
        }
    }
}
