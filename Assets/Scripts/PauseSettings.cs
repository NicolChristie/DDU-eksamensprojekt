using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PauseSettings : MonoBehaviour
{
    public Button backButton;
    public Button exitButton;
    public Button settingsButton;
    public Button goToMenuButton; 
    public GameObject settingsUI;  

    void Start()
    {
        if (settingsUI != null)
            settingsUI.SetActive(false);

        if (backButton != null) backButton.onClick.AddListener(ResumeGame);
        if (exitButton != null) exitButton.onClick.AddListener(ExitGame);
        if (settingsButton != null) settingsButton.onClick.AddListener(OpenSettings);
        if (goToMenuButton != null) goToMenuButton.onClick.AddListener(exitToMenu);
    }

    void ExitGame()
    {
        Debug.Log("Exiting Game...");
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    void OpenSettings()
    {
        Debug.Log("Settings would be opened.");
        if (settingsUI != null)
            settingsUI.SetActive(true);
    }

    public void ResumeGame()
    {
        var pauseManager = Object.FindFirstObjectByType<PauseMenu>();
        pauseManager.ResumeGame();
    }

    void exitToMenu(){
        SceneManager.LoadScene("Start Menu");
        
    }
}

