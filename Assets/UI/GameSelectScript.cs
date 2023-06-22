using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class GameSelectScript : MonoBehaviour
{
    public Slider aiSlider;
    public TMP_Text aiDisplay;
    public EventSystem eventSystem;
    public GameObject returnFocusTo;
    public GameSettings settings;

    void OnEnable()
    {
        eventSystem.firstSelectedGameObject = aiSlider.gameObject;
        eventSystem.SetSelectedGameObject(aiSlider.gameObject);
        aiSlider.value = settings.aiPlayersAmount;
    }

    private void OnDisable()
    {
        eventSystem.firstSelectedGameObject = returnFocusTo;
        eventSystem.SetSelectedGameObject(returnFocusTo);
    }

    // Update is called once per frame
    void Update()
    {
        aiDisplay.text = aiSlider.value.ToString();
        settings.aiPlayersAmount = (int)aiSlider.value;
    }

    public void OnCancel()
    {
        this.gameObject.SetActive(false);
    }
}
