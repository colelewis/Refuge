using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    public float openDistance;
    public bool open = false;

    private float startY;
    private float openY;
    
    // Start is called before the first frame update
    void Start()
    {
            startY = transform.position.y;
            openY = startY + openDistance;
        if(open)
        {
            transform.position = new Vector3(transform.position.x, openY, transform.position.z);
        }
    }

    // Update is called once per frame
    public void ToggleDoor()
    {
        open = !open;
        if(open)
        {
            OpenDoor();
        }
        else
        {
            CloseDoor();
        }
    }

    public void OpenDoor()
    {
        transform.position = new Vector3(transform.position.x, openY, transform.position.z);
    }

    public void CloseDoor()
    {
        transform.position = new Vector3(transform.position.x, startY, transform.position.z);
    }
}