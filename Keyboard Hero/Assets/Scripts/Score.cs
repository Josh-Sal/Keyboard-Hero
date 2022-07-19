using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public int score = 0;

    public int combo = 0;

    public int misses = 0;

    public int highest = 0;

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI comboText;

    public static Score scoreObject;

    public int scoreMultiplier = 100;

    // Start is called before the first frame update
    void Start()
    {
        //scoreText = scoreKeeper.GetComponent<UnityEngine.UI.Text>();
        scoreObject = this;
        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
       scoreText.text = "Score: " + score;
       comboText.text = "Combo: " + combo;

        HighestCombo(combo);
        print(misses);
    }

    public void addScore() 
    {
        score += combo * scoreMultiplier;
    }

    void HighestCombo(int lastCombo) {
        if (lastCombo > highest) {
            highest = lastCombo;
        }
    }
}
