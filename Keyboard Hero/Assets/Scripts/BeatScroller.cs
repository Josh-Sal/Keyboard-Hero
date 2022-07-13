using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeatScroller : MonoBehaviour
{
    public float beatTempo;
    public bool hasStarted;

    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 60f;
        hasStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted) {
            if (Input.anyKeyDown) {
                hasStarted = true;
            }
        } else {
            transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
        }
    }
}
