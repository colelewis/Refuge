using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class CreativeCameraMovement : MonoBehaviour
{
    private const float YMin = -50.0f;
    private const float YMax = 50.0f;
 
    public Transform lookAt;
 
    public float distance = 10.0f; // this is distance from the player; 1st person POV -> distance very low, 3rd person POV -> distance higher, around 200
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    public float sensivity = 1000f;
    public float offsetX = 0f;
    public float offsetY = 0f;
    public float offsetZ = 0f;
 
    // Start is called before the first frame update
    void Start()
    {
     
 
    }
 
    // Update is called once per frame
    void Update()
    {
        currentX += Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
        currentY += Input.GetAxis("Mouse Y") * sensivity * Time.deltaTime;
        currentY = Mathf.Clamp(currentY, YMin, YMax);
 
        Vector3 direction = new Vector3(0, 0, distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
                transform.position = lookAt.position + rotation * direction;

 
        transform.LookAt(new Vector3(lookAt.position.x + offsetX, lookAt.position.y + offsetY, lookAt.position.z + offsetZ));
    }
}