using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update() {
        RaycastHit hit;
        Ray reticleRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        
        // // instantiate ray from mouse to ...
        // Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(reticleRay, out hit, 200)) {
            Debug.Log("I'm looking at: " + hit.transform.name);
        }

        Debug.Log("Ray collided at " + hit.point + ", " + hit.distance + " units from the center of the screen.");
        Debug.DrawRay(reticleRay.origin, reticleRay.direction * 3000, Color.green);
    }
}