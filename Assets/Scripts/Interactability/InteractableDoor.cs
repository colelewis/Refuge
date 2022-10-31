using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoor : MonoBehaviour, IInteractable
{
    public bool locked = false; // to be used by puzzle area state managers to determine whether or not they can be used

    private bool open = false; // doors start closed 

    public void Interact() {        
        gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f); // test
        if (locked) {
            // indicate that it's locked, maybe play sound effect or instantiate a UI panel for a couple of seconds
        } else { // open if unlocked and closed,
            if (open) {
                closeDoor();
            } else {
                openDoor();
            }
            open = !open;
        }
    }

    public void openDoor() { // open door

    }

    public void closeDoor() { // close door

    }
}
