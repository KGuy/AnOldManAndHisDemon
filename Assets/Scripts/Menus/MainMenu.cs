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

    [Space(10)]
    [Header("Spælobjektir sum hava/eru menuir")]
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public GameObject creditsMenu;
    public GameObject quitMenu;
    public GameObject versionMenu;

    [Space(10)]
    [Header("Knappar hvørs sjónligheit mugu avgerast dynamiskt.")]
    // So at sama menu-scenan kann brúkast til at byrja spælið, og til at pausa tað miðskeiðis. Eitt sindur meiri innviklað kanska, men afturfyri býr øll menu kotan/designið á einum stað.
    public GameObject startGameButton;
    public GameObject resumeGameButton;
    // Options knappurin noyðist ikki her tí hann er altíð tøkur tá man trýstur á pausu.
    public GameObject creditsButton;
    // quitButton og quitToDesktopButton are needed for similar reasons to startGameButton and resumeGameButton; their applicability/visibility is determined at runtime!
    public GameObject quitButton;
    public GameObject quitToDesktopButton;

    [Space(10)]
    [Header("Knappar sum dynamiskt mugu fokuserast/endur-fokuserast.")]
    public GameObject optionsFirstButton;
    public GameObject optionsClosedButton;

    public GameObject creditsFirstButton;
    public GameObject creditsClosedButton;

    public GameObject quitFirstButton;
    public GameObject quitClosedButton;

    // Start is called before the first frame update
    void Start()
    {
        // Gongur út frá at allar menuirnar eru deaktiveraðar í "Main Menu" scenuni.
        PauseUnpause();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Fire3"))
        {
            // Um valmyndin er deaktivera, so aktiverast hon!
            if (!pauseMenu.activeInHierarchy)
            {
                PauseUnpause();
            }

            // Um valmyndin er aktivera, so mugu vit avgerða hvat verður gjørt alt eftir hvør sub-valmynd er aktivera.
            // Um ein ávís valmynd longu er aktiv, íðan so vilja vit deaktivera hana!
            // Hetta er tað sama sum hendur tá trýst verður á "Back" knøttin, á teimum relevantu valmyndunum.
            else
            {   
                if (optionsMenu.activeInHierarchy)
                {
                    CloseOptions();
                }
                
                else if (creditsMenu.activeInHierarchy)
                {
                    CloseCredits();
                }

                else if (quitMenu.activeInHierarchy)
                {
                    CloseQuit();
                }

                // Og um ongin valmynd er aktiv, so vilja vit fjala valmyndina! So at spæli kann halda áfram!
                // Men hov! Um vit ikki ansa eftir, so er vandi fyri at valmyndin hvørvir áðrenn nakað spæl er startað!
                // Tískil fjala vit bert valmyndina um eitt spæl er í gongd.
                else if(gameOn)
                {
                    PauseUnpause();
                    versionMenu.SetActive(false);
                }
            }
        }
    }

    public void StartGame()
    {
        if(!gameOn)
        {
            gameOn = true;
            versionMenu.SetActive(false);
            if (!SceneManager.GetSceneByBuildIndex(1).isLoaded)
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
                    PauseUnpause();
                }
            }
        }
    }

    public void SetSelectedGameObjectInCurrentEventSystem(GameObject inputGameObject)
    {
        // Óforklára arcana í Unity skipanini. Úrvaldaða tingið má "clearast"/nullast áðrenn man ásetur nýtt virðið.
        EventSystem.current.SetSelectedGameObject(null);
        // Áseting av úrvaldum tingið í verandi event skipan.
        EventSystem.current.SetSelectedGameObject(inputGameObject);
    }

    public void PauseUnpause()
    {
        if(!pauseMenu.activeInHierarchy)
        {
            if(gameOn)
            {
                startGameButton.SetActive(false);
                resumeGameButton.SetActive(true);
                // Options knappurin er ikki við her, tí sýni á tí knappinum er ikki tengt at gameOn booleanin.
                creditsButton.SetActive(false);
                quitButton.SetActive(true);
                quitToDesktopButton.SetActive(false);
                versionMenu.SetActive(false);
            }
            else
            {
                startGameButton.SetActive(true);
                resumeGameButton.SetActive(false);
                creditsButton.SetActive(true);
                quitButton.SetActive(false);
                quitToDesktopButton.SetActive(true);
                versionMenu.SetActive(true);
            }
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;

            GameObject activeButton = gameOn ? resumeGameButton: startGameButton;
            SetSelectedGameObjectInCurrentEventSystem(activeButton);
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

        SetSelectedGameObjectInCurrentEventSystem(optionsFirstButton);
    }

    public void CloseOptions()
    {
        optionsMenu.SetActive(false);

        SetSelectedGameObjectInCurrentEventSystem(optionsClosedButton);
    }

    public void OpenCredits()
    {
        creditsMenu.SetActive(true);

        SetSelectedGameObjectInCurrentEventSystem(creditsFirstButton);
    }

    public void CloseCredits()
    {
        creditsMenu.SetActive(false);

        SetSelectedGameObjectInCurrentEventSystem(creditsClosedButton);
    }

    public void OpenQuit()
    {
        if (!gameOn)
        {
            Debug.LogWarning("Hey! Hey You! How in the blazes did you get here!?");
        }
        else
        {
            quitMenu.SetActive(true);
        }

        SetSelectedGameObjectInCurrentEventSystem(quitFirstButton);
    }

    public void CloseQuit()
    {
        quitMenu.SetActive(false);
        SetSelectedGameObjectInCurrentEventSystem(quitButton);
    }

    public void QuitToMainMenu()
    {

        if (SceneManager.GetSceneByBuildIndex(1).isLoaded)
        {
            quitMenu.SetActive(false);

            try
            {
                SceneManager.UnloadSceneAsync(1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                
                PauseUnpause();
                gameOn = false;
                SetSelectedGameObjectInCurrentEventSystem(startGameButton);
                PauseUnpause();
            }
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        // "Application.Quit()" riggar ikki í ritil(i)num[EN: editor], men bara tá projektið/spælið er kompilerað.
        // Tískil noyðist "UnityEditor.EditorApplication.isPlaying" setast til "false", fyri at steðga spælinum.
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
