using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeatScroller : MonoBehaviour
{
    public float beatTempo;

    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
    }
}
