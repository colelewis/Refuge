using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReticleController : MonoBehaviour
{
    public float awarenessDistance = 500.0f;

    [SerializeField]
    private GameObject popUpPanel;

    void Start() {
        popUpPanel.SetActive(false);
    }

    Dictionary<string, string> actionMap = new Dictionary<string, string>()
    { // maps objects to their actions, the action then gets placed on the popup panel (i.e., when door is seen, show open)
        // Door is not listed here since text will be custom based on the Door's state
        {"Switch", "Toggle"},
        {"Handle", "Push"}
    };


    // Note: this will only interact with objects whose layer is set to Interactable, layer 6, that's what the 1<<6 is, bit shifting to layer 6
    // Note 2: objects must have a Mesh Collider with Convex checked to true in order to be detected.

    void Update() {
        Ray reticleRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f)); // casts ray from center of viewport
  
        RaycastHit interactableHit;
        if (Physics.Raycast(reticleRay, out interactableHit, awarenessDistance, 1<<6)) {
            Debug.Log("Ray collided with " + interactableHit.transform.name + " at " + interactableHit.point + ", " + interactableHit.distance + " units from the center of the screen.");

            if (interactableHit.transform.name == "Handle" && interactableHit.transform.gameObject.GetComponent<InteractableLever>().activated == true) { // if the lever has already been activated, then don't show a popup 
                popUpPanel.SetActive(false);
            }
            else if (interactableHit.transform.name == "Door" && interactableHit.transform.gameObject.GetComponent<InteractableDoor>().open == true) { // if the door is open, show close
                popUpPanel.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = "Close";
            }
            else if (interactableHit.transform.name == "Door" && interactableHit.transform.gameObject.GetComponent<InteractableDoor>().open == false) { // if the door is closed, then show open
                popUpPanel.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = "Open";
            }
            else if (interactableHit.transform.name == "Door" && interactableHit.transform.gameObject.GetComponent<InteractableDoor>().open == false) { // if the door is locked, then show locked
                popUpPanel.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = "This door is locked.";
            }
            else {
                popUpPanel.SetActive(true); // show panel while reticle is focused over interactable object
            }

            // change popup text to reflect appropriate command for object from dictionary
            popUpPanel.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = actionMap[interactableHit.transform.name];

            if (Input.GetKeyDown(KeyCode.E)) { // interact with E
                interactableHit.transform.gameObject.GetComponent<IInteractable>().Interact(); // makes the GameObject that the ray collides with run its Interact() method
            }

        } else {
            popUpPanel.SetActive(false);
        }
        Debug.DrawRay(reticleRay.origin, reticleRay.direction * awarenessDistance, Color.green); // shows when game is paused, helps gauge how far the ray is being cast and whether or not it's colliding with objects
    }
}