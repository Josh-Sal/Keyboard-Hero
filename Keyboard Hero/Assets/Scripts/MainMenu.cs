using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject quit;
    public GameObject levelSelector;

    public void PlayLevelOne()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayLevelTwo()
    {
        SceneManager.LoadScene(2);
    }

    public void Quit() {
        Application.Quit();
    }

    void Update() {

        if (!levelSelector.activeSelf) {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                gameObject.SetActive(false);
                quit.SetActive(true);
            }
        }
    }
}
