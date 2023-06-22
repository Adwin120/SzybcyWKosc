using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using static UnityEngine.InputSystem.InputAction;

public class UIScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseMenu;

    private InputSystemUIInputModule input;
    void Start()
    {
        //pauseMenu.SetActive(false);
        input = this.GetComponent<InputSystemUIInputModule>();
        input.cancel.action.performed += OnCancelCallback;

    }

    private void OnDestroy()
    {
        input.cancel.action.performed -= OnCancelCallback;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCancelCallback(CallbackContext context)
    {
        OnCancel();
    }

    void OnCancel()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
    }

    public void OnLap(PlayerData playerData)
    {

    }

    public void OnWin(PlayerData playerData)
    {

    }
}
