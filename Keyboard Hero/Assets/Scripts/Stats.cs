using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    int misses;
    int score;
    int highest = 0;
    bool fullCombo;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI comboText;
    public TextMeshProUGUI missesText;

    // Start is called before the first frame update
    void Start()
    {
        misses = 0;
        fullCombo = true;
        highest = 0;
    }

    // Update is called once per frame
    void Update()
    {
        score = Score.scoreObject.score;
        misses = Score.scoreObject.misses;
        highest = Score.scoreObject.highest;      
        
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

    public void PlayAgain() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Home() {
        SceneManager.LoadScene(0);
    }
}
