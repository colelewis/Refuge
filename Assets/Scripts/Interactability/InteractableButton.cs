using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableButton : MonoBehaviour, IInteractable
{
    public GameObject innerMaze;

    private float lerpDuration = 3.0f; // button press animation should only take a moment
    private float initialY = 1.54f; 
    private float endY = 0f; 
    private float lerpValue;

    // y = 1.54 -> 1.0 -> 1.54

    public void Interact() {
        gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f); // test
        StartCoroutine(Lerp());
    }

    IEnumerator Lerp()
    {
        float elapsedTime = 0;
        while (elapsedTime < lerpDuration)
        {
            lerpValue = Mathf.Lerp(initialY, endY, elapsedTime / lerpDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        lerpValue = endY;
    }
}
