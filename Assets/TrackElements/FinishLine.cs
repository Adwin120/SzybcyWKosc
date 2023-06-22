using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    // plan jest taki ¿e finish line bêdzie kontrolowa³o ca³¹ grê czy coœ xd
    public UIScript gameUI;
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
                gameUI.OnWin(pd);
            }

            gameUI.OnLap(pd);
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
        // ai trzeba te¿ bêdzie otagowaæ player
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject p in players)
        {
            RegisterPlayer(p);
        }
    }
}
