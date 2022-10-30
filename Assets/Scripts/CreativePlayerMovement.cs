using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreativePlayerMovement : MonoBehaviour
{
    CharacterController c;
    public float moveSpeed;
    public Transform camera;

    // Start is called before the first frame update
    void Start()
    {
        c = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float verticalMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        Vector3 playerMovement = camera.transform.right * horizontalMovement + camera.transform.forward * verticalMovement;
        
        // playerMovement.y = 0f; // flight

        c.Move(playerMovement);

        if (playerMovement.magnitude != 0f) {
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * camera.GetComponent<CreativeCameraMovement>().sensivity * Time.deltaTime);
        }

        Quaternion cameraRotation = camera.rotation;
        cameraRotation.x = 0f;
        cameraRotation.z = 0f;

        transform.rotation = Quaternion.Lerp(transform.rotation, cameraRotation, 0.1f);
    }
}
