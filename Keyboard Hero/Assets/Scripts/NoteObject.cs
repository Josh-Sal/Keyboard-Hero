using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToHold;
    public KeyCode click1;
    public KeyCode click2;

    public KeyCode keyNotToHold1;
    public KeyCode keyNotToHold2;
    public KeyCode keyNotToHold3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(keyToHold)) {
            if (Input.GetKey(click1) || Input.GetKey(click2)) {
                if (Input.GetKey(keyNotToHold1) || Input.GetKey(keyNotToHold2) || Input.GetKey(keyNotToHold3)) {

                } else {
                    if (canBePressed) {
                        gameObject.SetActive(false);
                    
                    }
                }
            }         
        }
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
