using System.Collections;
using System.Collections.Generic;
using Model;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void StartGame()
    {
        Core.TryLoad();
        SceneManager.LoadScene("House");
    }

    public void QuitGame()
    {
        if (!Core.TrySave())
            return;

        Debug.Log("Выход из игры завершен");
        Application.Quit();
    }
}
