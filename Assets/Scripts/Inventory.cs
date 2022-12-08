using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InteractableKey> keys = new List<InteractableKey>();
    
    public void Collect(InteractableKey key) {
        keys.Add(key);
    }

}
