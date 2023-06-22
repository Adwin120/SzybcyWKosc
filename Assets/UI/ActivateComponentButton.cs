using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateComponentButton : MonoBehaviour
{
    public GameObject component;

    public void ActivateTargetComponent()
    {
        component.SetActive(true);
    }
}
