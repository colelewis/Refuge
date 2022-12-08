using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDoorEnvironmentalController : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip mainDoorFX;
    public Light directionalLight;
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < 80) {
            audio.mute = false;
            directionalLight.enabled = false;
            audio.PlayOneShot(mainDoorFX, 0.01f);
            player.transform.GetChild(4).GetComponent<PauseMenuRouter>().pauseEnabled = false; // no saving right before end of the game, helps ensure key state remains intact
        } else {
            directionalLight.enabled = true;
            audio.mute = true;
            player.transform.GetChild(4).GetComponent<PauseMenuRouter>().pauseEnabled = true;
        }
        
    }

}
