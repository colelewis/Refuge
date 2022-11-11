using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InteractableKey> keys = new List<InteractableKey>();
    
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    public void Collect(InteractableKey key) {
        keys.Add(key);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
