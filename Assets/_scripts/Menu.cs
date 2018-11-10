using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public string startLevel;

    public string levelChoice; 

    public void NewGame()
    {
        SceneManager.LoadScene(startLevel);
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene(levelChoice);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
