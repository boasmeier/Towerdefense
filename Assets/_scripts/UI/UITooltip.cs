using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITooltip : MonoBehaviour
{
    [SerializeField] Text tipText;
    [SerializeField] List<string> tips = new List<string>();

    private int currentTip = 0;

    //Show a new tip every 10 seconds
    private void Start()
    {
        InvokeRepeating("ShowTip", 0.0f, 10f);
    }
        
    //Shows the next tip
    private void ShowTip()
    {
        tipText.text = tips[currentTip];
        currentTip++;
        if (currentTip >= tips.Count)
        {
            currentTip = 0;
        }
    }
}
