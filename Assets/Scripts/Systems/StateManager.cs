using UnityEngine;

public enum GameState
{
    None,
    Init,
    MainMenu,
    Gameplay,
    Paused,
    Options,
    GameOver
}

public class StateManager : MonoBehaviour
{
    ServiceHub serviceHub;
    UIManager uIManager;

    public GameState currentState { get; private set; }
    public GameState previousState { get; private set; }

    [SerializeField] string currentStateName;
    [SerializeField] string previousStateName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        serviceHub = ServiceHub.Instance;
        uIManager = serviceHub.UIManager;

        SetState(GameState.Init);
    }

    public void SetState(GameState newstate)
    {
        previousState = currentState;
        currentState = newstate;
        
        previousStateName = previousState.ToString();
        currentStateName = currentState.ToString();

        OnStateChange(previousState, currentState);
    }

    private void OnStateChange(GameState previousState, GameState currentState)
    {
        Time.timeScale = 1f; // Ensure time is running when changing states
        switch (currentState)
        {
            case GameState.Init:
                break;
            case GameState.MainMenu:
                uIManager.ShowMainMenu();
                break;
            case GameState.Gameplay:
                uIManager.ShowGameplayUI();
                break;
            case GameState.Paused:
                uIManager.ShowPauseMenu();
                Time.timeScale = 0f; // Pause the game when in paused state
                break;
            case GameState.Options:
                uIManager.ShowOptionsMenu();
                Time.timeScale = 0f; // Pause the game when in options menu
                break;
            case GameState.GameOver:
                uIManager.ShowGameOverScreen();
                break;
        }
    }
}