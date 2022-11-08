using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{


    private List<GameObject>() keys = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Collect(GameObject key) {
        keys.Add(key);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
