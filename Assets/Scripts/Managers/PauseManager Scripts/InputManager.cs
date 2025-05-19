using UnityEngine;

public class InputManager : MonoBehaviour

{
    [SerializeField]private Rigidbody rb;

    private void Awake()
    {
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
        OnGameStateChanged(GameStateManager.Instance.CurrentGameState);
    }

    private void OnGameStateChanged(GameState newGameState) 
    {
        switch (newGameState) 
        { 
            case GameState.Gameplay:
                rb.constraints = RigidbodyConstraints.None;
                rb.constraints = RigidbodyConstraints.FreezeRotation;
                break;
            case GameState.Paused:
                rb.constraints = RigidbodyConstraints.FreezePosition;
                break;
            default:
                break;
        }
    }
}
