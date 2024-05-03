using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Howtoplay : MonoBehaviour
{
    public void LoadScene(string scene1)
    {
        SceneManager.LoadScene(scene1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
