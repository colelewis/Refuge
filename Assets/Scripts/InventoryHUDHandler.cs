using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryHUDHandler : MonoBehaviour
{
    private List<InteractableKey> playerKeys = new List<InteractableKey>();

    // public GameObject red_key_icon;
    public GameObject blue_key_icon;
    public GameObject green_key_icon;

    // public Sprite red_key_filled;
    public Sprite blue_key_filled;
    public Sprite green_key_filled;

    // Start is called before the first frame update
    void Start()
    {
        playerKeys = transform.parent.gameObject.GetComponent<Inventory>().keys;
        
        // red_key_icon = GetComponent<Image>();
        // blue_key_icon = GetComponent<Image>();
        // green_key_icon = GetComponent<Image>();

        // red_key_filled = GetComponent<Sprite>();
        // blue_key_filled = GetComponent<Sprite>();
        // green_key_filled = GetComponent<Sprite>();
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (InteractableKey k in playerKeys) {
            // if (k.name == "RedKey") {
            //     red_key_icon.GetComponent<Image>().sprite = red_key_filled;
            // } else {
            //     //
            // }

            if (k.name == "GreenKey") {
                green_key_icon.GetComponent<Image>().sprite = green_key_filled;
            } else {
                //
            }
            if (k.name == "BlueKey") {
                blue_key_icon.GetComponent<Image>().sprite = blue_key_filled;
            } else {

            }
        }
        
    }
}
