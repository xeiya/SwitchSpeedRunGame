using UnityEngine;

public class SaveandLoadVelocity : MonoBehaviour
{
    private PlayerMovement pm;
    private Rigidbody rb;

    Vector3 currentLinearVelo;
    Vector3 currentAngularVelo;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameStateManager.Instance.CurrentGameState == GameState.Paused)
            { SaveVelocity(); }
            else { LoadVelocity(); }
        }
    }

    private void SaveVelocity()
    {
        currentLinearVelo = rb.linearVelocity;
        rb.linearVelocity = Vector3.zero;
        currentAngularVelo = rb.angularVelocity;
        rb.angularVelocity = Vector3.zero;
    }

    private void LoadVelocity()
    {
        rb.linearVelocity = currentLinearVelo;
        rb.angularVelocity = currentAngularVelo;
    }
}
