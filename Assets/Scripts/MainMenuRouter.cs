using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class MainMenuRouter : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject HowToPlayPanel;
    public GameObject AboutPanel;
    public GameObject loadMemoryManager;

    private GameObject loadedPlayer;
    // Start is called before the first frame update
    void Start()
    {
        mainMenu();
    }

    public void mainMenu() {
        MainMenu.SetActive(true);
    }

    public void Load() {
        if (File.Exists(Application.persistentDataPath + "/refuge.save")) {
            BinaryFormatter b = new BinaryFormatter();
            FileStream loadedSaveFile = File.Open(Application.persistentDataPath + "/refuge.save", FileMode.Open);
            SaveData loadedSaveData = (SaveData)b.Deserialize(loadedSaveFile);
            loadedSaveFile.Close();
            Debug.Log(loadedSaveData.playerInventory);
            loadMemoryManager.GetComponent<LoadMemoryManager>().loadedPlayerX = loadedSaveData.playerPositionX;
            loadMemoryManager.GetComponent<LoadMemoryManager>().loadedPlayerY = loadedSaveData.playerPositionY;
            loadMemoryManager.GetComponent<LoadMemoryManager>().loadedPlayerZ = loadedSaveData.playerPositionZ;
            loadMemoryManager.GetComponent<LoadMemoryManager>().loadedPlayerInventory = loadedSaveData.playerInventory;
            Instantiate(loadMemoryManager);
            UnityEngine.SceneManagement.SceneManager.LoadScene("IslandScene");
        } else {
            Debug.LogError("There is no save file present.");
        }
    }

    public void HowToPlay() {
        HowToPlayPanel.SetActive(!HowToPlayPanel.activeSelf);
    }

    public void About() {
        AboutPanel.SetActive(!AboutPanel.activeSelf);
    }

    public void NewGame() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("IslandScene");
    }

}