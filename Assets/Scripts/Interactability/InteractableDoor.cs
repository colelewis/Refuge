using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoor : MonoBehaviour, IInteractable
{
    public bool locked = false; // to be used by puzzle area state managers to determine whether or not they can be used

    public bool open = false; // doors start closed 

    public void Interact() {        
        gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f); // test
        if (!locked) {
            if (open) {
                closeDoor();
            } else {
                openDoor();
            }
        }
    }

    public void openDoor() { // open door
        
        open = true;
    }

    public void closeDoor() { // close door

        open = false;
    }
}
