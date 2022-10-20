using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonControls : MonoBehaviour
{
    [SerializeField]
    protected TextMeshProUGUI hitBox;
    [SerializeField]
    protected TextMeshProUGUI misBox;
    [SerializeField]
    protected TextMeshProUGUI loseBox;

    public MyInstantiator hitlink;
    public MyTrigger mislink;

    private void Update()
    {
        int theHits = hitlink.shotDown;
        int theMiss = mislink.missed;
        hitBox.text = "Hits: " + theHits.ToString();
        misBox.text = "Misses: " + theMiss.ToString();
        //textBox.text = "Score: " + _score.ToString();
        if (theMiss >= 50)
        {
            loseBox.text = "YOU LOSE";
        }
        else
        {
            loseBox.text = "";
        }
    }
    public void buttonClick()
    {
        hitlink.shotDown = 0;
        mislink.missed = 0;
    }
}
