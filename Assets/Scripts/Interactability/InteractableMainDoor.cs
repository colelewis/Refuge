using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractableMainDoor : MonoBehaviour, IInteractable
{
    public GameObject panel;
    public GameObject HUDCanvas;

    public void Interact() {
        Inventory playerInventory = GameObject.Find("Player").GetComponent<Inventory>();
        if (playerInventory.keys.Count == 2) { // has both keys
            StartCoroutine(end());
        }
    }

    IEnumerator end() {
        AudioListener.pause = true;
        Time.timeScale = 0f;
        panel.SetActive(true);
        HUDCanvas.SetActive(false);
        yield return new WaitForSeconds(3);
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        // Application.Quit();
    }
}
