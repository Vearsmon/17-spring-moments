using System.Reflection;
using Model;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseGameMenu;
    [SerializeField] private GameObject settingsMenu;
    
    private EscapeManager escapeManager;

    private void Start()
    {
        escapeManager = GameObject.FindGameObjectWithTag("EscapeManager").GetComponent<EscapeManager>();
        escapeManager.ifToCloseStackEmpty.Add(Pause);
    }

    public void Resume()
    {
        pauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        pauseGameMenu.SetActive(true);
        Time.timeScale = 0f;
        escapeManager.AddCloseTask(Resume);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneTransition.SwitchToScene("Menu");
    }

    public void SaveGame()
    {
        Core.CurrentScene = SceneManager.GetActiveScene().name;
        
        Debug.Log($"{Core.CurrentScene}State");
        var value = typeof(Core).GetProperty($"{Core.CurrentScene}State")!.GetValue(null);
        value!.GetType().GetProperty("PlayerPosition")!
            .SetValue(value, new Vector(GameObject.FindGameObjectWithTag("Player").transform.position));
        
        if (!Core.TrySave())
            Debug.Log("Unable to save progress");
    }

    public void LoadSettings()
    {
        settingsMenu.SetActive(true);
        escapeManager.AddCloseTask(() => settingsMenu.SetActive(false));
    }
}
