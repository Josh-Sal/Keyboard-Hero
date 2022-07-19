using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayLevelOne()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayLevelTwo()
    {
        SceneManager.LoadScene(2);
    }
}
