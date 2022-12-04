using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuRouter : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject HowToPlayPanel;
    public GameObject AboutPanel;
    // Start is called before the first frame update
    void Start()
    {
        mainMenu();
    }

    public void mainMenu() {
        MainMenu.SetActive(true);
    }

    public void Load() {
        // load save state
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
