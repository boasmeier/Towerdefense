using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSpeedHandler : MonoBehaviour
{
    [SerializeField]
    private Slider gameSpeedSlider;
    // Start is called before the first frame update
    void Start()
    {
        gameSpeedSlider.onValueChanged.AddListener(delegate {ChangeGameSpeed();});   
    }

    private void ChangeGameSpeed() {
        int value =  (int) gameSpeedSlider.value;
        
        switch(value) {
            case 1: 
                Time.timeScale = 1;
                break;

            case 2:
                Time.timeScale = 2;
                break;

            case 3: 
                Time.timeScale = 4;
                break;

            case 4:
                Time.timeScale = 8;
                break;
        }
        Debug.Log("Game speed set to: " + Time.timeScale + "x"); 
    }
}
