using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool pauseGame;
    public GameObject pauseGameMenu;

    private bool checkingEscape = true;
    private DateTime startChecking = DateTime.MaxValue;

    void Update()
    {
        if (!checkingEscape && DateTime.Now > startChecking)
            StartEscapeChecking();
        if (!Input.GetKeyDown(KeyCode.Escape) || !checkingEscape) 
            return;
        
        if (pauseGame)
            Resume();
        else
            Pause();
    }

    public void SetEscapeChecking(bool value)
    {
        if (value)
            startChecking = DateTime.Now + TimeSpan.FromMilliseconds(10);
        else
            checkingEscape = false;
    }

    private void StartEscapeChecking()
    {
        checkingEscape = true;
        startChecking = DateTime.MaxValue;
    }

    public void Resume()
    {
        pauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
        pauseGame = false;
    }

    public void Pause()
    {
        pauseGameMenu.SetActive(true);
        Time.timeScale = 0f;
        pauseGame = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
