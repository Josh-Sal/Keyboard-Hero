using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;

    public KeyCode keyToPress;

    public KeyCode click1;

    public KeyCode click2;

    public bool isInside = false;

    public static ButtonController buttonControllerObject;

    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
        buttonControllerObject = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress)) {
            theSR.sprite = pressedImage;
        }

        if (Input.GetKeyUp(keyToPress)) {
            theSR.sprite = defaultImage;
        }

        if (Input.GetKeyDown(click1) || Input.GetKeyDown(click2))
        {
            if (!isInside)
            {
                Score.scoreObject.combo = 0;
            }
        }
    }
}
