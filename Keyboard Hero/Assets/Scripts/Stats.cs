using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    int misses;
    int combo;
    int score;
    int highest = 0;
    bool fullCombo;
    bool isDone = false;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI comboText;
    public TextMeshProUGUI missesText;

    // Start is called before the first frame update
    void Start()
    {
        misses = 0;
        fullCombo = true;
    }

    // Update is called once per frame
    void Update()
    {
        combo = Score.scoreObject.combo;
        HighestCombo(combo);
        score = Score.scoreObject.score;
        misses = Score.scoreObject.misses;

        if (combo > 0) {
            isDone = false;
        } else {
            if (!isDone) {
                misses++;
                isDone = true;
            }
        }
        
        
        if (misses != 0) {
            fullCombo = false;
        }

        scoreText.text = "Score: " + score;
        missesText.text = "Misses: " + misses;
        if (fullCombo) {
            comboText.text = "Highest Combo: " + highest + " (FC!)";
        } else {
            comboText.text = "Highest Combo: " + highest;
        }
    }

    void HighestCombo(int lastCombo) {
        if (lastCombo > highest) {
            highest = lastCombo;
        }
    }

    public void PlayAgain() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Home() {
        SceneManager.LoadScene(0);
    }
}
