using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public AudioSource music;

    public void Pause() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        music.Pause();
    }

    public void Resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        music.Play();
    }

    public void Leave(int sceneID) {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }

    public void Restart() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Pause();
        }

        if (Time.timeScale == 0f) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                Resume();
            }
        }
    }
}
