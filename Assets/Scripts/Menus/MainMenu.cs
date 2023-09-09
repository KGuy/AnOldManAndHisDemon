using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool gameOn = false;

    public GameObject pauseMenu,
                      optionsMenu,
                      creditsMenu,
                      quitMenu,
                      quitFromGameOffMenu,
                      quitFromGameOnMenu;

    public GameObject startGameButton,
                      resumeGameButton,
                      pauseFirstButton,
                      optionsFirstButton, 
                      optionsClosedButton,
                      creditsFirstButton,
                      creditsClosedButton,
                      quitFirstButton,
                      quitClosedButton;

    // Start is called before the first frame update
    void Start()
    {
        PauseUnpause();
    }

    // Update is called once per frame
    void Update()
    {
        if(!pauseMenu.activeInHierarchy && Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Fire3"))
        {
            PauseUnpause();
        }
    }

    public void StartGame()
    {
        if(!gameOn)
        {
            if(!SceneManager.GetSceneByBuildIndex(1).isLoaded)
            {
                try
                {
                    SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    gameOn = true;
                    PauseUnpause();
                }
            }
        }
    }

    public void PauseUnpause()
    {
        if(!pauseMenu.activeInHierarchy)
        {
            if(gameOn)
            {
                resumeGameButton.SetActive(true);
                startGameButton.SetActive(false);
            }
            else
            {
                resumeGameButton.SetActive(false);
                startGameButton.SetActive(true);
            }
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;

            //Clear selected object. Unexplained arcana of the system.
            EventSystem.current.SetSelectedGameObject(null);
            //Set a new slected object
            EventSystem.current.SetSelectedGameObject(pauseFirstButton);
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            optionsMenu.SetActive(false);
        }
    }

    public void OpenOptions()
    {
        optionsMenu.SetActive(true);

        //Clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //Set a new slected object
        EventSystem.current.SetSelectedGameObject(optionsFirstButton);
    }

    public void CloseOptions()
    {
        optionsMenu.SetActive(false);

        //Clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //Set a new slected object
        EventSystem.current.SetSelectedGameObject(optionsClosedButton);
    }

    public void OpenCredits()
    {
        creditsMenu.SetActive(true);

        //Clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //Set a new slected object
        EventSystem.current.SetSelectedGameObject(creditsFirstButton);
    }

    public void CloseCredits()
    {
        creditsMenu.SetActive(false);

        //Clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //Set a new slected object
        EventSystem.current.SetSelectedGameObject(creditsClosedButton);
    }

    public void OpenQuit()
    {
        if (gameOn)
        {
            resumeGameButton.SetActive(true);
            startGameButton.SetActive(false);
            quitFromGameOffMenu.SetActive(false);
            quitFromGameOnMenu.SetActive(true);
        }
        else
        {
            resumeGameButton.SetActive(false);
            startGameButton.SetActive(true);
            quitFromGameOffMenu.SetActive(true);
            quitFromGameOnMenu.SetActive(false);
        }

        quitMenu.SetActive(true);
        //Clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //Set a new slected object
        EventSystem.current.SetSelectedGameObject(quitFirstButton);
    }

    public void CloseQuit()
    {
        quitMenu.SetActive(false);

        //Clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //Set a new slected object
        EventSystem.current.SetSelectedGameObject(quitClosedButton);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
