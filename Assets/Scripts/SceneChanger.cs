using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Opcje;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainMap", LoadSceneMode.Single);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ShowOptions(bool isActive)
    {
        Opcje.SetActive(isActive);

        if (isActive)
        {
            Menu.SetActive(false);
            Opcje.SetActive(true);
        }
    }

    public void BackToMenu(bool isActive)
    {
        Menu.SetActive(true);
        Opcje.SetActive(false);
    }

    public void EndingButton(bool isActive)
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void SecondLevel(bool isActive)
    {
        SceneManager.LoadScene("Level2", LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }


}
