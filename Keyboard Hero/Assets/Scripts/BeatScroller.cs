using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeatScroller : MonoBehaviour
{
    public float beatTempo;
    public AudioSource music;
    bool hasStarted = false;
    float timer = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0) {
            transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
            if (!hasStarted) {
                music.Play();
                hasStarted = true;
            }
        } else {
            timer -= Time.deltaTime;
        }
    }
}
