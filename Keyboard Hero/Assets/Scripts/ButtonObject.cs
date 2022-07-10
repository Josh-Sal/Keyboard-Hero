using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonObject : MonoBehaviour
{
    private bool canBePressed;
    private bool isHolding;
    public KeyCode keyToHold;
    public KeyCode click1;
    public KeyCode click2;
    private GameObject note;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(keyToHold)) {
            if (Input.GetKeyDown(click1) || Input.GetKeyDown(click2)) {
                if (canBePressed) {
                    note.SetActive(false);
                    Score.scoreObject.combo += 1;
                    Score.scoreObject.addScore();
                } else {
                    if (!isHolding) {
                        Score.scoreObject.combo = 0;
                    }
                }
            }         
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Note") {
            canBePressed = true;
            note = other.gameObject;
        }

        if (other.tag == "Hold" || other.tag == "Last Hold") {
            isHolding = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Note") {
            canBePressed = false;

            if (other.gameObject.activeSelf) {
                Score.scoreObject.combo = 0;
            }
        }

        if (other.tag == "Last Hold") {
            isHolding = false;
        }
    }
}
