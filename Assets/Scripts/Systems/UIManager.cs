using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("UI Panels")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject inGamePanel;
    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private GameObject optionsMenuPanel;
    [SerializeField] private GameObject gameOverPanel;

    ServiceHub serviceHub;

    private void Start()
    {
        ShowMainMenu();
        serviceHub = ServiceHub.Instance;
    }

    public void ShowMainMenu()
    {
        HideAllUI();
        mainMenuPanel.SetActive(true);
    }

    public void ShowGameplayUI()
    {
        HideAllUI();
        inGamePanel.SetActive(true);
    }

    public void ShowPauseMenu()
    {
        HideAllUI();
        inGamePanel.SetActive(true); // Show in-game UI behind the pause menu for context
        pauseMenuPanel.SetActive(true);
    }

    public void ShowOptionsMenu()
    {
        
        optionsMenuPanel.SetActive(true);
    }

    public void ShowGameOverScreen()
    {
        HideAllUI();
        inGamePanel.SetActive(true);
        gameOverPanel.SetActive(true);
    }

    public void HideAllUI()
    {
        mainMenuPanel.SetActive(false);
        inGamePanel.SetActive(false);
        pauseMenuPanel.SetActive(false);
        optionsMenuPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    public void StartGame()
    {
        serviceHub.StateManager.SetState(GameState.Gameplay);
    }

    public void ReturnToMainMenu()
    {
        serviceHub.StateManager.SetState(GameState.MainMenu);
    }

    public void ResumeGame()
    {
        serviceHub.StateManager.SetState(GameState.Gameplay);
    }

    public void OpenOptions()
    {
        serviceHub.StateManager.SetState(GameState.Options);
    }

    public void CloseOptions()
    {
        if (serviceHub.StateManager.previousState == GameState.Paused)
        {
            serviceHub.StateManager.SetState(GameState.Paused);
        }
        else
        {
            serviceHub.StateManager.SetState(GameState.MainMenu);
        }
    }

    public void Restart()
    {
        serviceHub.StateManager.SetState(GameState.Gameplay);
    }

    public void GameOver()
    {
        serviceHub.StateManager.SetState(GameState.GameOver);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void TogglePause()
    {
        if (serviceHub.StateManager.currentState == GameState.Gameplay)
        {
            serviceHub.StateManager.SetState(GameState.Paused);
        }
        else if (serviceHub.StateManager.currentState == GameState.Paused)
        {
            serviceHub.StateManager.SetState(GameState.Gameplay);
        }
    }
}
