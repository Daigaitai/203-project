using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public string map;
    public void LoadScene(string map)
    {
        SceneManager.LoadScene(map);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
