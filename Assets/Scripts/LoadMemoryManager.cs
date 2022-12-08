using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMemoryManager : MonoBehaviour
{
    public float loadedPlayerX;
    public float loadedPlayerY;
    public float loadedPlayerZ;
    public List<string> loadedPlayerInventory;
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
