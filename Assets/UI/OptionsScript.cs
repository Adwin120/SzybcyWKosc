using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OptionsScript : MonoBehaviour
{
    public Slider volumeSlider;
    public EventSystem eventSystem;
    public GameObject returnFocusTo;
    public GameSettings settings;

    private float initialVolume;

    void OnEnable()
    {
        eventSystem.firstSelectedGameObject = volumeSlider.gameObject;
        eventSystem.SetSelectedGameObject(volumeSlider.gameObject);
        initialVolume = settings.volume;
        volumeSlider.value = initialVolume;
    }

    private void OnDisable()
    {
        eventSystem.firstSelectedGameObject = returnFocusTo;
        eventSystem.SetSelectedGameObject(returnFocusTo);
    }

    // Update is called once per frame
    void Update()
    {
        settings.volume = volumeSlider.value;
    }

    public void OnSubmitButton()
    {
        this.gameObject.SetActive(false);
    }

    public void OnCancel()
    {
        settings.volume = initialVolume;
        OnSubmitButton();
    }
}
