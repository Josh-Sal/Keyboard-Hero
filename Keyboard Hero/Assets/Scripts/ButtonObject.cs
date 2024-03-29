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
    public KeyCode mouseClick1;
    public KeyCode mouseClick2;
    private GameObject note;
    public GameObject particleObject;
    private ParticleSystem particle;
    ParticleSystem.MainModule particleSettings;
    public AudioSource hitSound;
    public AudioSource comboBreak;
    public GameObject endStats;
    public GameObject hud;
    bool end = false;


    // Start is called before the first frame update
    void Start()
    {
        particle = particleObject.GetComponent<ParticleSystem>();
        particleSettings = particleObject.GetComponent<ParticleSystem>().main;
    }

    // Update is called once per frame
    void Update()
    {
        if (!end) {
            if (Input.GetKey(keyToHold)) {
                if (Input.GetKeyDown(click1) || Input.GetKeyDown(click2) || Input.GetKeyDown(mouseClick1) || Input.GetKeyDown(mouseClick2)) {
                    ParticleColour();
                    if (canBePressed) {
                        note.SetActive(false);
                        Score.scoreObject.combo += 1;
                        Score.scoreObject.addScore();
                        hitSound.Play();
                        particle.Play();
                    } else {
                        if (!isHolding) {
                            comboBreakAudio();
                            Score.scoreObject.misses += 1;
                            Score.scoreObject.combo = 0;
                            particleSettings.startColor = new Color(0, 0, 0);
                            particle.Play();
                        }
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

        Score.scoreObject.scoreMultiplier = 100;

        if (other.tag == "End") {
            endStats.SetActive(true);
            hud.SetActive(false);
            end = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Note") {
            canBePressed = false;

            if (other.gameObject.activeSelf) {
                comboBreakAudio();
                Score.scoreObject.combo = 0;
            }
        }

        if (other.tag == "Last Hold") {
            isHolding = false;
        }
    }

    public void ParticleColour() {
        if (keyToHold == KeyCode.A) {
            particleSettings.startColor = new Color(0, 100, 255);
        } else if (keyToHold == KeyCode.S) {
            particleSettings.startColor = new Color(255,255, 0);
        } else if (keyToHold == KeyCode.D) {
            particleSettings.startColor = new Color(255, 0, 0);
        } else if (keyToHold == KeyCode.F) {
            particleSettings.startColor = new Color(0, 255, 0);
        } else {
            particleSettings.startColor = new Color(0, 0, 0);
        }
    }

    void comboBreakAudio() {
        if (Score.scoreObject.combo >= 10) {
            comboBreak.Play();
        }
    }
}
