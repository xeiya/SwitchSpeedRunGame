using UnityEngine;

public class PlayerReset : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 spawnPos;
    private Quaternion spawnRot;

    private void Awake()
    {
        spawnPos = transform.position;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) || rb.transform.position.y < -20) 
        { 
            ResetPlayer();
            GameManager.gm.ResetTime();
        }
    }

    private void ResetPlayer() 
    {
        rb.linearVelocity = Vector3.zero;
        transform.position = spawnPos;
        transform.rotation = spawnRot;
    }
}
