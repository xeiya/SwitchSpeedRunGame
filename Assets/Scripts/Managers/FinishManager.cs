using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinishManager : MonoBehaviour
{
    public List<string> Messages = new List<string>();
    public TMP_Text winText;

    private void Start()
    {
        Messages.Add("Speed, wit, and good cheekbones? Truly, the divine genes are thriving.");
        Messages.Add("Mortals dream of wings. You just used yours to fly past fate itself.");
        Messages.Add("You didn’t just win—you outplayed, outpaced, and out-sassed the competition. Frankly? Iconic.");
        Messages.Add("If speed were illegal, you’d be serving a life sentence in Tartarus by now.");
        Messages.Add("That win was so fast even I missed it—and I see everything.");
        Messages.Add("You’re not just part of Hermes’ bloodline—you’re the upgrade.");
        Messages.Add("Mortals ran. You vanished. There's a difference—and it's dazzling.");
        Messages.Add("With style like that, Olympus might need a new runway. Preferably one that doesn't catch fire.");
        Messages.Add("You make outrunning fate look like a warm-up lap. Apollo’s harp just went off-key.");
        Messages.Add("Victory looks easy when you turn time itself into a footnote.");
        Invoke("ChangeText", 1f);
    }

    public void ChangeText()
    {
        winText.text = Messages[Random.Range(0, Messages.Count)];
    }
}
