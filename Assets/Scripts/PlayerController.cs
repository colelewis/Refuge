using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// inspired by https://sharpcoderblog.com/blog/unity-3d-fps-controller

[RequireComponent(typeof(CharacterController))] // ensure our player object has a Character Controller

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 175.0f;
    public float sprintSpeed = 262.5f;
    public float jumpSpeed = 100.0f;
    public float playerGravity = 50.0f;
    public Camera camera;
    public float sensitivity = 2.0f;
    public float xAngleLimit = 45.0f;

    CharacterController cc;
    Vector3 movementDirection = Vector3.zero; // initialize movement vector to zeroes
    float xRotation = 0f; // initialize player camera x rotation to zero

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; // locks cursor position while playing
        Cursor.visible = false; // keeps cursor from being distracting during camera movement
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool sprinting = Input.GetKey(KeyCode.LeftControl);
        float horizontalMovement = (sprinting ? sprintSpeed : walkSpeed) * Input.GetAxis("Vertical");
        float verticalMovement = (sprinting ? sprintSpeed : walkSpeed) * Input.GetAxis("Horizontal");

        float verticalDirection = movementDirection.y;

        movementDirection = (forward * horizontalMovement) + (right * verticalMovement);

        if (Input.GetKey(KeyCode.Space) && cc.isGrounded) { // player is on the ground and space is pressed
            movementDirection.y = jumpSpeed;
        } else {
            movementDirection.y = verticalDirection;
        }

        if (!cc.isGrounded) { // player is in the air
            movementDirection.y -= playerGravity * Time.deltaTime;
        }

        cc.Move(movementDirection * Time.deltaTime);

        xRotation += -Input.GetAxis("Mouse Y") * sensitivity;
        xRotation = Mathf.Clamp(xRotation, -xAngleLimit, xAngleLimit);
        camera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * sensitivity, 0);
    }
}
