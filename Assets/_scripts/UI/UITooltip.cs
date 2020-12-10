using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITooltip : MonoBehaviour
{
    [SerializeField] Text tipText;
    [SerializeField] List<string> tips = new List<string>();

    private int currentTip = 0;

    //Show a new tip every 3 seconds
    private void Start()
    {
        ShowTip();
    }
        
    //Shows the next tip
    private void ShowTip()
    {
        float timescale = Time.timeScale;
        if(timescale < 1f) {
            timescale = 1f;
        }
        Invoke("ShowTip", 3.0f * timescale);  
        tipText.text = tips[currentTip];
        currentTip++;
        if (currentTip >= tips.Count)
        {
            currentTip = 0;
        }
    }
}
