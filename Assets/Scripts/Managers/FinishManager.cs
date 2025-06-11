using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinishManager : MonoBehaviour
{
    public List<string> Messages = new List<string>();
    public TMP_Text winText;

    private void Start()
    {
        Messages.Add("You fell so hard, even Atlas felt that impact!");
        Messages.Add("You’ve died so many times, Hades is charging rent.");
        Messages.Add("You’ve turned divine potential into a cautionary tale.");
        Messages.Add("You died so fast, I thought you were speedrunning the afterlife.");
        Messages.Add("You fell so fast, even Hermes couldn't keep up—what an embarrassment to your bloodline!");
        Messages.Add("By the gods, I actually killed you? I was bracing for a fight, not a tragic comedy.");
        Messages.Add("I thought I was the king of terrible descents—but you just dethroned me!");
        Messages.Add("You’ve made dying your most consistent skill.");
        Messages.Add("You’ve wasted my time, my patience, and somehow—my immortality. Impressive.");
        Invoke("ChangeText", 1f);
    }

    public void ChangeText()
    {
        winText.text = Messages[Random.Range(0, Messages.Count)];
    }
}
