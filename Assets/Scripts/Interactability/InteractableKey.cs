using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableKey : MonoBehaviour, IInteractable
{
    public AudioClip keyCollect;

    public void Start() {
        // audio = GetComponent<AudioSource>();
    }

    public void Interact() {
        AudioSource.PlayClipAtPoint(keyCollect, this.gameObject.transform.position);      
        Inventory playerInventory = GameObject.Find("Player").GetComponent<Inventory>();
        playerInventory.Collect(this); // add key to player inventory
        gameObject.SetActive(false);
    }
}
