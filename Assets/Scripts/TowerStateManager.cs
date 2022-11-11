using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStateManager : MonoBehaviour
{

     /*
        Notes:
        The door and lever prefabs each have children which contain the interactability component.
        State will be determined by the booleans set by the children.
        The lever child object is named Handle, the door child object is named Door, these will also contain the mesh colliders for our raycasting.
        This script will only contain GameObjects dependent on tower state, meaning doors that are always unlocked will not be listed
    */

    // Floor 1
    public GameObject door_to_vault;
    public GameObject door_to_floor_2;
    public GameObject door_to_switch_3_f1;
    public GameObject switch_1_f1;
    public GameObject switch_2_f1;
    public GameObject switch_3_f1;
    public GameObject switch_4_f1;

    // Floor 2
    public GameObject door_to_floor_3;
    public GameObject door_to_switch_4_f2;
    public GameObject door_to_switch_5_f2;
    public GameObject switch_1_f2;
    public GameObject switch_2_f2;
    public GameObject switch_3_f2;
    public GameObject switch_4_f2;
    public GameObject switch_5_f2;
    public GameObject bonusSwitch1;

    // Floor 3
    public GameObject door_to_transmission_log;
    public GameObject door_to_switch_3_f3;
    public GameObject door_to_switch_4_f3;
    public GameObject door_to_bonusSwitch2;
    public GameObject door_to_greenKey;
    public GameObject switch_1_f3;
    public GameObject switch_2_f3;
    public GameObject switch_3_f3;
    public GameObject switch_4_f3;
    public GameObject bonusSwitch2;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void importState() {

    }

    void exportState() {

    }

    // Door: .transform.gameObject.GetComponent<InteractableDoor>() =
    // Switch: .transform.gameObject.GetComponent<InteractableLever>() = 

    // Update is called once per frame
    void Update()
    {
        // Floor 1 Logic
        if (
            switch_1_f1.transform.gameObject.GetComponent<InteractableLever>().activated == true &&
            switch_2_f1.transform.gameObject.GetComponent<InteractableLever>().activated == true &&
            switch_3_f1.transform.gameObject.GetComponent<InteractableLever>().activated == true && 
            switch_4_f1.transform.gameObject.GetComponent<InteractableLever>().activated == true
        ) { door_to_floor_2.transform.gameObject.GetComponent<InteractableDoor>().locked = false; }

        if (
            switch_2_f1.transform.gameObject.GetComponent<InteractableLever>().activated == true
        ) { door_to_switch_3_f1.transform.gameObject.GetComponent<InteractableDoor>().locked = false; }

        if (
            bonusSwitch2.transform.gameObject.GetComponent<InteractableLever>().activated == true
        ) { door_to_vault.transform.gameObject.GetComponent<InteractableDoor>().locked = false; }

        // Floor 2 Logic
        if (
            switch_1_f2.transform.gameObject.GetComponent<InteractableLever>().activated == true &&
            switch_2_f2.transform.gameObject.GetComponent<InteractableLever>().activated == true &&
            switch_3_f2.transform.gameObject.GetComponent<InteractableLever>().activated == true && 
            switch_4_f2.transform.gameObject.GetComponent<InteractableLever>().activated == true &&
            switch_5_f2.transform.gameObject.GetComponent<InteractableLever>().activated == true
        ) { door_to_floor_3.transform.gameObject.GetComponent<InteractableDoor>().locked = false; }

        if (
            switch_3_f2.transform.gameObject.GetComponent<InteractableLever>().activated == true
        ) { door_to_switch_4_f2.transform.gameObject.GetComponent<InteractableDoor>().locked = false; }

        if (
            switch_4_f2.transform.gameObject.GetComponent<InteractableLever>().activated == true
        ) { door_to_switch_5_f2.transform.gameObject.GetComponent<InteractableDoor>().locked = false; }

        // Floor 3 Logic
        if (
            switch_1_f3.transform.gameObject.GetComponent<InteractableLever>().activated == true &&
            switch_2_f3.transform.gameObject.GetComponent<InteractableLever>().activated == true &&
            switch_3_f3.transform.gameObject.GetComponent<InteractableLever>().activated == true && 
            switch_4_f3.transform.gameObject.GetComponent<InteractableLever>().activated == true
        ) { door_to_greenKey.transform.gameObject.GetComponent<InteractableDoor>().locked = false; }

        if (
            switch_2_f3.transform.gameObject.GetComponent<InteractableLever>().activated == true
        ) { 
            door_to_switch_3_f3.transform.gameObject.GetComponent<InteractableDoor>().locked = false; 
            door_to_switch_4_f3.transform.gameObject.GetComponent<InteractableDoor>().locked = false;
        }
        
        if (
            switch_3_f3.transform.gameObject.GetComponent<InteractableLever>().activated == true
        ) { door_to_bonusSwitch2.transform.gameObject.GetComponent<InteractableDoor>().locked = false; }
    }
}
