using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableKey : MonoBehaviour, IInteractable
{
    public void Interact() {
        // gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f); // test
        Inventory playerInventory = GameObject.Find("Player").GetComponent<Inventory>();
        playerInventory.Collect(this); // add key to player inventory
        Destroy(this); // destroy the key in the scene as it has been collected
    }
}
