using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject hudCanvas = null;
    [SerializeField] private GameObject pauseCanvas = null;
    [SerializeField] private GameObject endCanvas = null;

    public bool paused = false;
    PauseAction action;
    

    private void Awake()
    {
        action = new PauseAction();
    }

    private void Start()
    {
        SetActiveHud(true);
        action.Pause.PauseGame.performed += _ => DeterminePause();
    }

    public void SetActiveHud(bool state)
    {
        hudCanvas.SetActive(state);
        pauseCanvas.SetActive(!state);
        endCanvas.SetActive(!state);
    }

    private void DeterminePause()
    {
        if(paused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public bool ReturnPause()
    {
        return paused;
    }
    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }

    public void Restart()
    {
        Time.timeScale = 1;
        paused = false;
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        paused = false;
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseCanvas.SetActive(true);
        hudCanvas.SetActive(false);
        paused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        SetActiveHud(true);
        paused = false;
    }

}










































