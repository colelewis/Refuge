using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundtrack : MonoBehaviour
{
    private AudioSource audio;
    public int randomSeed = 99;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    IEnumerator playSong() {
        audio.Play();
        yield return new WaitForSeconds(30);
    }

    // Update is called once per frame
    void Update()
    {
        bool songPlaying = Random.Range(1, 10000) == 1;
        if (songPlaying) {
            StartCoroutine(playSong());
        }
    }
}
