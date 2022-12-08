using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableElevator : MonoBehaviour, IInteractable
{
    public GameObject Player;
    public GameObject Target;
    public void Interact()
    {
        Player.transform.position = Target.transform.position;
        Player.transform.localRotation *= Quaternion.Euler(0, 180, 0);
    }
}
