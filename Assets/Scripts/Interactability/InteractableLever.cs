using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableLever : MonoBehaviour, IInteractable
{
    public bool activated = false;
    
    public void Interact() {
        if (!activated) {
            // gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f); // test
            transform.position = new Vector3(transform.position.x, transform.position.y - 70f, transform.position.z);
            activated = true; // once activated, switches stay activated, no need for toggle
        }
    }
}
