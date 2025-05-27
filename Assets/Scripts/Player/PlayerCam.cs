using UnityEngine;
using DG.Tweening;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;
    public Transform camHolder;

    float xRotation;
    float yRotation;

    [SerializeField] Rigidbody rb;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        rb = GetComponent<Rigidbody>();

        camHolder.rotation = Quaternion.Euler(yRotation, 0, 0);
        orientation.rotation = Quaternion.Euler(xRotation, 45, yRotation);
    }

    private void Update()
    {
        if (GameStateManager.Instance.CurrentGameState == GameState.Paused) return;

        //get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //rotate cam and orientation
        camHolder.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

        if (Input.GetKeyDown(KeyCode.R) || rb.linearVelocity.y < -20) 
        { 
            ResetCamera();
        }
    }

    public void ResetCamera() 
    {
        camHolder.rotation = Quaternion.Euler(yRotation, 0, 0);
        orientation.rotation = Quaternion.Euler(xRotation, 45, yRotation);
    }

    public void DoFov(float endValue) 
    {
        GetComponent<Camera>().DOFieldOfView(endValue, 0.25f);
    }

    public void DoTilt(float zTilt) 
    {
        transform.DOLocalRotate(new Vector3(0, 0, zTilt), 0.25f);
    }
}
