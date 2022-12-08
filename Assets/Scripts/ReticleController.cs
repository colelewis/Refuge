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
        {"Handle", "Toggle"},
        {"Key", "Collect"},
        {"Button", "Push"},
        {"Journal", "Read"}
    };


    // Note: this will only interact with objects whose layer is set to Interactable, layer 6, that's what the 1<<6 is, bit shifting to layer 6
    // Note 2: objects must have a Mesh Collider with Convex checked to true in order to be detected.

    void Update() {
        Ray reticleRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f)); // casts ray from center of viewport
  
        RaycastHit interactableHit;
        if (Physics.Raycast(reticleRay, out interactableHit, awarenessDistance)) {
            // Debug.Log("Ray collided with " + interactableHit.transform.name + " at " + interactableHit.point + ", " + interactableHit.distance + " units from the center of the screen.");

                if (interactableHit.transform.gameObject.layer == 6) {
                    popUpPanel.SetActive(true); // show panel while reticle is focused over interactable object
                    // change popup text to reflect appropriate command for object from dictionary
                    
                    try {
                        popUpPanel.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = actionMap[interactableHit.transform.tag];
                    }
                    catch (KeyNotFoundException k) {
                        popUpPanel.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = "Use";
                    }
                } else {
                    popUpPanel.SetActive(false);
                }

            if (Input.GetKeyDown(KeyCode.E) && interactableHit.transform.gameObject.layer == 6) { // interact with E
                interactableHit.transform.gameObject.GetComponent<IInteractable>().Interact(); // makes the GameObject that the ray collides with run its Interact() method
            }

        } else {
            popUpPanel.SetActive(false);
        }
        Debug.DrawRay(reticleRay.origin, reticleRay.direction * awarenessDistance, Color.green); // shows when game is paused, helps gauge how far the ray is being cast and whether or not it's colliding with objects
    }
}