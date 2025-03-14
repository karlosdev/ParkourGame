using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BringSettings : MonoBehaviour
{
    public GameObject setting;
    public bool issettingactive;
    public GameObject Menu;
    public GameObject Options;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (issettingactive == false)
            {
                Pause();
            }

            else
            {
                Resume();
            }
        }
    }

    public void Pause()
    {
        setting.SetActive(true);
        issettingactive = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Resume()
    {
        setting.SetActive(false);
        issettingactive = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ShowOptions(bool isActive)
    {
        Options.SetActive(isActive);

        if (isActive)
        {
            Menu.SetActive(false);
            Options.SetActive(true);
        }
    }

    public void BackToMenu(bool isActive)
    {
        Menu.SetActive(true);
        Options.SetActive(false);
    }

    public void RestartFirstLevel(bool isActive)
    {
        SceneManager.LoadScene("MainMap", LoadSceneMode.Single);
        Resume();
    }

    public void RestartSecondLevel(bool isActive)
    {
        SceneManager.LoadScene("Level2", LoadSceneMode.Single);
        Resume();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}