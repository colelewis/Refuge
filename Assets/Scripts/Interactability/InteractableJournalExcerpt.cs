using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractableJournalExcerpt : MonoBehaviour, IInteractable
{
    public string contents;
    public string title;
    public GameObject readPanel;

    public void Interact() {
        readPanel.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = contents;
        readPanel.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = title;
        // gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f); // test
        readPanel.SetActive(!readPanel.activeSelf);
    }
}
