using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class ButtonManager : MonoBehaviour
{
    public void NewGameBtn( int newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel);
    }

    public void ExitGameBtn(string exitGameLevel)
    {
        Application.Quit();
    }

    public void LoadGameBtn(int loadGameLevel)
    {
        SceneManager.LoadScene(loadGameLevel);
    }

}
