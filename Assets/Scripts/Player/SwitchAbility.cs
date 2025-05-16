using UnityEngine;
using UnityEngine.UI;

public class SwitchAbility : MonoBehaviour
{
    [Header("Game Objects")]
    public GameObject overWorld;
    public GameObject underWorld;

    [Header("Cooldown")]
    public float switchCooldown;
    private float lastTimeCasted;
    private bool switchReady = true;

    [Header("Cooldown Image")]
    public Image switchCooldownBar;

    private void Start()
    {
        switchReady = true;
        switchCooldownBar.fillAmount = 1;
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && switchReady == true) 
        {
            ChangeWorld();
            SwitchBarEmpty();
        }

        switchCooldownBar.fillAmount = Mathf.MoveTowards(switchCooldownBar.fillAmount, 1, Time.deltaTime / switchCooldown);
        if (switchCooldownBar.fillAmount >= 1) 
        { 
            switchReady = true;
        }
    }

    void ChangeWorld() 
    {
        /*Checks for the last time casted by the.
         *Time.time, if Time.time is more than last time casted
         *Cast the ability else, return
        */
        if (Time.time < lastTimeCasted + switchCooldown && switchReady == false)
            return;
        lastTimeCasted = Time.time;

        if (Time.time < lastTimeCasted + switchCooldown && switchReady == true) 
        {
            
            if (overWorld.activeInHierarchy == false)
            { overWorld.SetActive(true); }
            else if (overWorld.activeInHierarchy == true)
            { overWorld.SetActive(false); }
            
            if (underWorld.activeInHierarchy == false)
            { underWorld.SetActive(true); }
            else if (underWorld.activeInHierarchy == true)
            { underWorld.SetActive(false); }
            
            switchReady = false;
        } 
    }

    public void SwitchBarEmpty() 
    {
        switchCooldownBar.fillAmount = 0;
    }
}
