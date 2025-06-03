using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SwitchAbility : MonoBehaviour
{
    [Header("Game Objects")]
    public GameObject overWorld;
    public GameObject underWorld;
    private Rigidbody rb;

    [Header("Switch Effects")]
    [SerializeField] private Volume volume;
    private ColorAdjustments colorAdjustments;

    [Header("Cooldown")]
    public float switchCooldown;
    private float lastTimeCasted;
    private bool switchReady = true;

    [Header("Cooldown Image")]
    public Image switchCooldownBar;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        volume.profile.TryGet(out colorAdjustments);
    }
    private void Start()
    {
        ResetWorld();
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

        if (Input.GetKeyDown(KeyCode.R) || rb.transform.position.y < -20)
        {
            ResetWorld();
        }
    }
    #region World Change
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
            { 
                overWorld.SetActive(true);
                colorAdjustments.hueShift.value = 0;
            }
            else if (overWorld.activeInHierarchy == true)
            { overWorld.SetActive(false); }
            
            if (underWorld.activeInHierarchy == false)
            { 
                underWorld.SetActive(true);
                colorAdjustments.hueShift.value = 130;
            }
            else if (underWorld.activeInHierarchy == true)
            { underWorld.SetActive(false); }
            
            switchReady = false;
        } 
    }

    public void SwitchBarEmpty() 
    {
        switchCooldownBar.fillAmount = 0;
    }

    public void ResetWorld() 
    {
        overWorld.SetActive(true);
        underWorld.SetActive(false);
        colorAdjustments.hueShift.value = -20;
    }
    #endregion 
}
