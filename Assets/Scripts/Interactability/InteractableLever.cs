using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableLever : MonoBehaviour, IInteractable
{
    public bool activated = false;
    public GameObject handle;
    public GameObject[] Doors;
    private float startPos;

    void Start()
    {
        startPos = handle.transform.position.y;
    }

    
    public void Interact() {
        // gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f); // test
        activated = !activated;
        if(activated)
        {
            handle.transform.position = new Vector3(handle.transform.position.x, startPos - 0.6f, handle.transform.position.z);
            
            foreach(GameObject obj in Doors)
            {
                obj.GetComponent<DoorController>().ToggleDoor();
            }
        }
        else
        {
            handle.transform.position = new Vector3(handle.transform.position.x, startPos, handle.transform.position.z);
            foreach (GameObject obj in Doors)
            {
                obj.GetComponent<DoorController>().ToggleDoor();
            }
        }
    }
}
