using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("UI Panels")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject inGamePanel;
    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private GameObject optionsMenuPanel;
    [SerializeField] private GameObject gameOverPanel;

    StateManager stateManager = ServiceHub.Instance.StateManager;

    private void Start()
    {
        ShowMainMenu();
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
        stateManager.SetState(GameState.Gameplay);
    }

    public void ReturnToMainMenu()
    {
        stateManager.SetState(GameState.MainMenu);
    }

    public void ResumeGame()
    {
        stateManager.SetState(GameState.Gameplay);
    }

    public void OpenOptions()
    {
        stateManager.SetState(GameState.Options);
    }

    public void CloseOptions()
    {
        if (stateManager.previousState == GameState.Paused)
        {
            stateManager.SetState(GameState.Paused);
        }
        else
        {
            stateManager.SetState(GameState.MainMenu);
        }
    }

    public void Restart()
    {
        stateManager.SetState(GameState.Gameplay);
    }

    public void GameOver()
    {
        stateManager.SetState(GameState.GameOver);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void TogglePause()
    {
        if (stateManager.currentState == GameState.Gameplay)
        {
            stateManager.SetState(GameState.Paused);
        }
        else if (stateManager.currentState == GameState.Paused)
        {
            stateManager.SetState(GameState.Gameplay);
        }
    }
}
