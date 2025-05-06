using UnityEngine;

public class SwitchAbility : MonoBehaviour
{
    public string targetTag = "Switchable";
    private bool isSwitched = false;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1)) 
        {
            Debug.Log(isSwitched);
            if (isSwitched == true)
            {
                Switch();
                isSwitched = false;
            }
            else 
            {
                Switch();
                isSwitched = true;
            }   
        }
    }

    public void Switch()
    {
        if (isSwitched == true)
        {
            GameObject[] taggedObject = GameObject.FindGameObjectsWithTag(targetTag);
            foreach (GameObject go in taggedObject)
            {
                go.SetActive(false);
            }
        }
        if (isSwitched == false)
        {

        }
    }
}
