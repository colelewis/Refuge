using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuRouter : MonoBehaviour
{
    public GameObject pausePanel;
    private float oldCamSensitivity;

    public void Start() {
        oldCamSensitivity = gameObject.GetComponentInParent<PlayerController>().sensitivity;
    }

    public void Resume() {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Quit() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void Save() {
        //TBD
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) {
            pausePanel.SetActive(!pausePanel.activeSelf);
        }
        if (pausePanel.activeSelf == true) { // if paused
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.Confined; // locks cursor position while playing
            Cursor.visible = true; // keeps cursor from being distracting during camera movement
            gameObject.GetComponentInParent<PlayerController>().sensitivity = 0; // keep camera from moving
        } else { // otherwise
            Time.timeScale = 1f;
            gameObject.GetComponentInParent<PlayerController>().sensitivity = oldCamSensitivity;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
