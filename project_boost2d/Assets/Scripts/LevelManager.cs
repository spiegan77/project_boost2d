using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    // TODO Create Credits Scene and Controls Scene
    // Level Manager video appoximately 4:00
    /*
    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    */

    // Probably won't need this because LoadNextScene is on CollisionHandler.cs
    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void QuitGame()
    {
        Debug.Log("You have selected: Quit");
        Application.Quit(); // Does not work on WEBGL builds
    }
}
