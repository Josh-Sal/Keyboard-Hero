using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToHold;
    public KeyCode click1;
    public KeyCode click2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKey(keyToHold)) {
        //     if (Input.GetKeyDown(click1) || Input.GetKeyDown(click2)) {
        //         if (canBePressed) {
        //             ButtonController.buttonControllerObject.isInside = true;
        //             gameObject.SetActive(false);
        //             Score.scoreObject.combo += 1;
        //             Score.scoreObject.addScore();
        //         } else {
        //         }
        //     }         
        // }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Activator") {
            canBePressed = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Activator") {
            canBePressed = false;
        }
    }
}
