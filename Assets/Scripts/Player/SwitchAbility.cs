using UnityEngine;
using UnityEngine.UIElements;

public class SwitchAbility : MonoBehaviour
{
    public GameObject overWorld;
    public GameObject underWorld;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1)) 
        {
            ChangeWorld1();
            ChangeWorld2();
        }
    }

    void ChangeWorld1() 
    {
        if (overWorld.activeInHierarchy == false)
        { overWorld.SetActive(true); }
        else { overWorld.SetActive(false); }
    }

    void ChangeWorld2()
    {
        if (underWorld.activeInHierarchy == false)
        { underWorld.SetActive(true); }
        else { underWorld.SetActive(false); }
    }
}
