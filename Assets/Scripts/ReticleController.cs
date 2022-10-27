using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleController : MonoBehaviour
{
    public GameObject reticle;
    public Camera camera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update() {
        RaycastHit hit;
        Ray reticleRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        {
            if (Physics.Raycast(reticleRay, out hit)) {
                Debug.Log("I'm looking at: " + hit.transform.name);
            } else {
                Debug.Log("Nothing.");
            }
            Debug.DrawLine(reticleRay.origin, reticleRay.direction*100, Color.yellow);
            
        }
    }
}
