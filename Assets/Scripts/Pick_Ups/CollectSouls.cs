using UnityEngine;
using TMPro;

public class CollectSouls : MonoBehaviour
{
    public TMP_Text collectedSoulsUI;
    public TMP_Text requiredSoulsUI;
    public int collectedSouls;
    public int requiredSouls;
    public EndBarrier endBarrier;

    public string collectableTag = "PickUp";

    private void Start()
    {
        requiredSoulsUI.text = requiredSouls.ToString();
    }

    void Update()
    {
        collectedSoulsUI.text = collectedSouls.ToString();

        if (collectedSouls == requiredSouls) 
        { 
            endBarrier.DestroyGate();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == collectableTag)
        {
            collectedSouls++;
            Destroy(other.gameObject);
        }
    }
}