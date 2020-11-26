using System;
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
    private UIMenue UIMenue;
    private LevelManager levelManager;

    void Awake()
    {
        gameSpeedSlider.onValueChanged.AddListener(delegate {ChangeGameSpeed();}); 
        UIInputController = FindObjectOfType<UIInputController>();
        UIMenue = FindObjectOfType<UIMenue>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnEnable() 
    {
        UIInputController.HandleGameSpeedIncrease +=  Increase;
        UIInputController.HandleGameSpeedDecrease += Decrease; 
        UIMenue.Pause += PauseGame;
        UIMenue.Continue += ContinueGame;
        levelManager.ResetGameSpeed += ResetSlider;
    }

    private void OnDisable() {
        UIInputController.HandleGameSpeedIncrease -=  Increase;
        UIInputController.HandleGameSpeedDecrease -= Decrease; 
        UIMenue.Pause += PauseGame;
        UIMenue.Continue += ContinueGame;
        levelManager.ResetGameSpeed -= ResetSlider;
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

    private void PauseGame() {
        Time.timeScale = 0;
        //Disable scripts that still work while timescale is set to 0
        PlaceholderInputController[] array = FindObjectsOfType<PlaceholderInputController>();
        foreach (PlaceholderInputController element in array) {
            element.GetComponent<PlaceholderInputController>().enabled=false;
            element.GetComponent<BoxCollider>().enabled=false;
        }
        FindObjectOfType<EconomyController>().enabled = false;
        GameObject.Find("StartButton").GetComponent<Button>().enabled = false;
    }

    private void ContinueGame() {
        this.ChangeGameSpeed();
        //enable the scripts again
        PlaceholderInputController[] array = FindObjectsOfType<PlaceholderInputController>();
        foreach (PlaceholderInputController element in array) {
            element.GetComponent<PlaceholderInputController>().enabled=true;
            element.GetComponent<BoxCollider>().enabled=true;
        }
        FindObjectOfType<EconomyController>().enabled = true;
        GameObject.Find("StartButton").GetComponent<Button>().enabled = true;
    }
}
