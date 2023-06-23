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
    public TMPro.TextMeshProUGUI winText;

    private InputSystemUIInputModule input;
    void Start()
    {
        //pauseMenu.SetActive(false);
        input = this.GetComponent<InputSystemUIInputModule>();
        input.cancel.action.performed += OnCancelCallback;
        Time.timeScale = 0;

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
        if (pauseMenu.activeSelf)
        {
            Time.timeScale = 0;
        } else
        {
            Time.timeScale = 1;
        }
    }

    public void OnLap(PlayerData playerData)
    {

    }

    public void OnWin(PlayerData playerData)
    {
        winText.text = "Wygra³ gracz: " + playerData.playerName;
        Time.timeScale = 0;
    }
}
