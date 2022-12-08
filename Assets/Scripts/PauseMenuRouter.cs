using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class PauseMenuRouter : MonoBehaviour
{
    public GameObject pausePanel;
    private float oldCamSensitivity;
    public bool pauseEnabled = true;

    private GameObject player;
    public GameObject saveSplashText;

    public void Start() {
        oldCamSensitivity = gameObject.GetComponentInParent<PlayerController>().sensitivity;
        player = this.transform.parent.gameObject;
    }

    public void Resume() {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        saveSplashText.SetActive(false);
    }

    public void Quit() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void Save() {
        BinaryFormatter b = new BinaryFormatter();
        FileStream saveFile = File.Create(Application.persistentDataPath + "/refuge.save");
        SaveData saveData = new SaveData();
        saveData.playerPositionX = player.transform.position.x;
        saveData.playerPositionY = player.transform.position.y;
        saveData.playerPositionZ = player.transform.position.z;
        foreach (InteractableKey i in player.GetComponent<Inventory>().keys) {
            saveData.playerInventory.Add(i.transform.name);
        }
        b.Serialize(saveFile, saveData);
        saveFile.Close();
        saveSplashText.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && pauseEnabled) {
            pausePanel.SetActive(!pausePanel.activeSelf);
        }
        if (pausePanel.activeSelf == true) { // if paused
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.Confined; // locks cursor position while playing
            Cursor.visible = true; // keeps cursor from being distracting during camera movement
            gameObject.GetComponentInParent<PlayerController>().sensitivity = 0; // keep camera from moving
            AudioListener.pause = true;
        } else { // otherwise
            Time.timeScale = 1f;
            gameObject.GetComponentInParent<PlayerController>().sensitivity = oldCamSensitivity;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            AudioListener.pause = false;
            saveSplashText.SetActive(false);
        }
    }
}

// for some reason, Vector3 isn't natively serializable, so we just store the floats instead

[System.Serializable]
class SaveData {
    public float playerPositionX;
    public float playerPositionY;
    public float playerPositionZ;
    public List<string> playerInventory = new List<string>();
}
