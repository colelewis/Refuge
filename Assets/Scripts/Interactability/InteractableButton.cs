using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableButton : MonoBehaviour, IInteractable
{
    public GameObject innerMaze; // so the inner portion can rotate upon press
    private bool pressed = false; // ensures no multiple rotations
    private AudioSource audio;

    public void Start() {
        Physics.IgnoreCollision(transform.parent.gameObject.transform.GetChild(0).gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        audio = GetComponent<AudioSource>();
    }

    IEnumerator simplePress() {
        pressed = true;
        transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + 0.07f);
        yield return new WaitForSeconds(1);
        transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - 0.07f);
        innerMaze.transform.Rotate(0f, 0f, 90.0f, Space.Self);
        pressed = false;
        transform.parent.gameObject.SetActive(false);
    }

    public void Interact() {
        // gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f); // test
        audio.Play();
        if (pressed == false) {
            StartCoroutine(simplePress());
        }
    }
}
