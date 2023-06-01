using Model;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private Button settingButton;
    
    public void StartGame()
    {
        Core.Reset();
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

    private void Start()
    {
        if (!System.IO.File.Exists("save"))
            settingButton.interactable = false;

    }
}