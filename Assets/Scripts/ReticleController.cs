using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleController : MonoBehaviour
{
    public float awarenessDistance = 300.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Note: this will only interact with objects whose layer is set to Interactable, layer 6
    // Note 2: objects must have a Mesh Collider with Convex checked to true in order to be detected.

    
    // Update is called once per frame
    void Update() {
        Ray reticleRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f)); // casts ray from center of viewport
  
        RaycastHit interactableHit;
        if (Physics.Raycast(reticleRay, out interactableHit, awarenessDistance, 1<<6)) {
            Debug.Log("Ray collided with " + interactableHit.transform.name + " at " + interactableHit.point + ", " + interactableHit.distance + " units from the center of the screen.");
            interactableHit.transform.gameObject.GetComponent<IInteractable>().Interact(); // makes the GameObject that the ray collides with run its Interact() method
        }
        Debug.DrawRay(reticleRay.origin, reticleRay.direction * awarenessDistance, Color.green); // shows when game is paused, helps gauge how far the ray is being cast and whether or not it's colliding with objects
    }
}