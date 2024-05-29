using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }

    public void loadLevel(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }

}
