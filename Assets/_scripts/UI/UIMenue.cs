using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenue : MonoBehaviour
{
    [SerializeField] private RectTransform menuePanel;
    [SerializeField] private GameObject controlsPanel;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button controlsButton;
    [SerializeField] private Button exitButton;

    public event Action HandleRestart = delegate { };
    public event Action Pause = delegate { };
    public event Action Continue = delegate { };
    public event Action HandleMenueButtonClickSound = delegate { };

    private UIInputController UIInputController;
    private UIManager UIManager;
    private void Awake()
    { 
        UIInputController = FindObjectOfType<UIInputController>();
        UIManager = FindObjectOfType<UIManager>();
    }

    private void OnEnable() 
    {
        UIInputController.ToggleMenue += Toggle;
        UIManager.ToggleMenue += Toggle;

        resumeButton.onClick.AddListener(Resume);
        resumeButton.onClick.AddListener(PlayClickSound);

        restartButton.onClick.AddListener(Restart);
        restartButton.onClick.AddListener(PlayClickSound);

        controlsButton.onClick.AddListener(ToggleControls);
        controlsButton.onClick.AddListener(PlayClickSound);

        exitButton.onClick.AddListener(Exit);
        exitButton.onClick.AddListener(PlayClickSound);
    }

    private void OnDisable() 
    {
        UIInputController.ToggleMenue -= Toggle; 
        UIManager.ToggleMenue -= Toggle;

        resumeButton.onClick.RemoveListener(Resume);
        resumeButton.onClick.RemoveListener(PlayClickSound);

        restartButton.onClick.RemoveListener(Restart);
        restartButton.onClick.RemoveListener(PlayClickSound);

        controlsButton.onClick.RemoveListener(ToggleControls);
        controlsButton.onClick.RemoveListener(PlayClickSound);

        exitButton.onClick.RemoveListener(Exit);
        exitButton.onClick.RemoveListener(PlayClickSound);
    }

    private void Start() {
        if(FirstTimeCheck.notFirstTime) {
            Toggle();
        } else {
            resumeButton.GetComponentInChildren<Text>().text = "Start";
            FirstTimeCheck.notFirstTime = true;
            Pause();
        }
    }

    private void Toggle() {
        if(menuePanel.gameObject.activeSelf) {
            Continue();
            menuePanel.gameObject.SetActive(false);
        } else {
            Pause();
            menuePanel.gameObject.SetActive(true);
            resumeButton.GetComponentInChildren<Text>().text = "Resume";
            restartButton.gameObject.SetActive(true);
        }    
    }

    private void Resume() {
        this.Toggle();
    }

    private void Restart() {
        HandleRestart();
    }

    private void ToggleControls()
    {
        controlsPanel.SetActive(!controlsPanel.activeSelf);
    }

    private void Exit() {
        Application.Quit();
    }

    private void PlayClickSound() {
        HandleMenueButtonClickSound();
    }
}
