using UnityEngine;
using UnityEngine.UIElements;

public class SwitchAbility : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject playerObject;
    public Transform targetObject;

    bool isSwitched;

    public void Start()
    {
        playerObject = GetComponent<GameObject>();
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Debug.Log(isSwitched);
            if (isSwitched)
            {
                isSwitched = true;
                isSwitching();
            }
            else 
            { 
                isSwitched = false;
                isSwitching();
            }
        }
    }

    public void isSwitching() 
    {
        if (isSwitched)
        {
            playerObject.transform.position = targetObject.transform.position;
            Physics.SyncTransforms();
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0.0001f, rb.linearVelocity.z);
        }
        else if (!isSwitched) 
        {
            playerObject.transform.position = targetObject.transform.position;
            Physics.SyncTransforms();
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0.0001f, rb.linearVelocity.z);
        }
    }
}
