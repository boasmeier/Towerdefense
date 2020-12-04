using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSpeedHandler : MonoBehaviour
{
    [SerializeField] private Slider gameSpeedSlider;
    private int sliderValue = 2;

    private UIInputController uiInputController;
    private UIMenue uiMenue;
    private LevelManager levelManager;

    private void Awake()
    { 
        uiInputController = FindObjectOfType<UIInputController>();
        uiMenue = FindObjectOfType<UIMenue>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnEnable() 
    {
        gameSpeedSlider.onValueChanged.AddListener(delegate {ChangeGameSpeed();});
        uiInputController.HandleGameSpeedIncrease +=  Increase;
        uiInputController.HandleGameSpeedDecrease += Decrease; 
        uiMenue.Pause += PauseGame;
        uiMenue.Continue += ContinueGame;
        levelManager.ResetGameSpeed += ResetSlider;
    }

    private void OnDisable() {
        gameSpeedSlider.onValueChanged.RemoveListener(delegate {ChangeGameSpeed();});
        uiInputController.HandleGameSpeedIncrease -=  Increase;
        uiInputController.HandleGameSpeedDecrease -= Decrease; 
        uiMenue.Pause -= PauseGame;
        uiMenue.Continue -= ContinueGame;
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
        // Disable scripts and buttons that still work while timescale is set to 0
        PlaceholderInputController[] array = FindObjectsOfType<PlaceholderInputController>();
        foreach (PlaceholderInputController element in array) {
            element.GetComponent<PlaceholderInputController>().enabled=false;
            element.GetComponent<BoxCollider>().enabled=false;
        }
        //FindObjectOfType<EconomyManager>().enabled = false;
        GameObject.Find("StartButton").GetComponent<Button>().enabled = false;
        GameObject.Find("TowerButton1").GetComponent<Button>().enabled = false;
        GameObject.Find("TowerButton2").GetComponent<Button>().enabled = false;
        GameObject.Find("TowerButton3").GetComponent<Button>().enabled = false;
        GameObject.Find("BuyButton").GetComponent<Button>().enabled = false;
        GameObject.Find("Arrow Up").GetComponent<Button>().enabled = false;
        GameObject.Find("Arrow Left").GetComponent<Button>().enabled = false;
        GameObject.Find("Arrow Right").GetComponent<Button>().enabled = false;
        GameObject.Find("Arrow Down").GetComponent<Button>().enabled = false;
    }

    private void ContinueGame() {
        ChangeGameSpeed();
        // enable the scripts and buttons again
        PlaceholderInputController[] array = FindObjectsOfType<PlaceholderInputController>();
        foreach (PlaceholderInputController element in array) {
            element.GetComponent<PlaceholderInputController>().enabled=true;
            element.GetComponent<BoxCollider>().enabled=true;
        }
        //FindObjectOfType<EconomyManager>().enabled = true;
        GameObject.Find("StartButton").GetComponent<Button>().enabled = true;
        GameObject.Find("TowerButton1").GetComponent<Button>().enabled = true;
        GameObject.Find("TowerButton2").GetComponent<Button>().enabled = true;
        GameObject.Find("TowerButton3").GetComponent<Button>().enabled = true;
        GameObject.Find("BuyButton").GetComponent<Button>().enabled = true;
        GameObject.Find("Arrow Up").GetComponent<Button>().enabled = true;
        GameObject.Find("Arrow Left").GetComponent<Button>().enabled = true;
        GameObject.Find("Arrow Right").GetComponent<Button>().enabled = true;
        GameObject.Find("Arrow Down").GetComponent<Button>().enabled = true;
    }
}
