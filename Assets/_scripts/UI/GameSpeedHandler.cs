using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSpeedHandler : MonoBehaviour
{
    [SerializeField]
    private Slider gameSpeedSlider;
    int sliderValue = 2;

    private UIInputController UIInputController;
    private UIGameOver UIGameOver;
    // Start is called before the first frame update
    void Awake()
    {
        gameSpeedSlider.onValueChanged.AddListener(delegate {ChangeGameSpeed();}); 
        UIInputController = FindObjectOfType<UIInputController>();
        UIGameOver = FindObjectOfType<UIGameOver>();
    }

    private void OnEnable() 
    {
        UIInputController.HandleGameSpeedIncrease +=  Increase;
        UIInputController.HandleGameSpeedDecrease += Decrease; 
        UIGameOver.ResetGameSpeed += ResetSlider;
    }

    private void OnDisable() {
        UIInputController.HandleGameSpeedIncrease -=  Increase;
        UIInputController.HandleGameSpeedDecrease -= Decrease; 
        UIGameOver.ResetGameSpeed -= ResetSlider;
    }

    private void ChangeGameSpeed() {
        sliderValue =  (int) gameSpeedSlider.value;
        
        switch(sliderValue) {
            case 1: 
                Time.timeScale = 0.5f;
                break;

            case 2:
                Time.timeScale = 1;
                break;

            case 3: 
                Time.timeScale = 2;
                break;

            case 4:
                Time.timeScale = 4;
                break;

            case 5:
                Time.timeScale = 8;
                break;
        }
        Debug.Log("Game speed set to: " + Time.timeScale + "x"); 
    }

    private void Increase() {
        sliderValue++;
        gameSpeedSlider.value = sliderValue;
    }

    private void Decrease() {
        sliderValue--;
        gameSpeedSlider.value = sliderValue;
    }

    private void ResetSlider() {
        sliderValue = 2;
        gameSpeedSlider.value = sliderValue;
    }
}
