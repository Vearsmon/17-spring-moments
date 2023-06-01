using Model;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneTransition.SwitchToScene("Intro");
    }

    public void ContinueGame()
    {
        Core.TryLoad();
        SceneTransition.SwitchToScene(Core.CurrentScene);
    }

    public void QuitGame()
    {
        Debug.Log("Выход из игры завершен");
        Application.Quit();
    }
}