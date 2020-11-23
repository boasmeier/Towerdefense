using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenue : MonoBehaviour
{

    [SerializeField]
    private RectTransform menuePanel;

    [SerializeField]
    private Button resumeButton;

    [SerializeField]
    private Button restartButton;
    [SerializeField]
    private Button exitButton;

    public event Action HandleRestart = delegate { };
    public event Action ResetGameSpeed = delegate { };

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
        resumeButton.GetComponentInChildren<Text>().text = "Start";
        restartButton.onClick.AddListener(Restart);
        exitButton.onClick.AddListener(Exit); 
    }

    private void OnDisable() 
    {
        UIInputController.ToggleMenue -= Toggle; 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Toggle() {
        if(menuePanel.gameObject.activeSelf) {
            menuePanel.gameObject.SetActive(false);
        } else {
            menuePanel.gameObject.SetActive(true);
            resumeButton.GetComponentInChildren<Text>().text = "Resume";
            restartButton.gameObject.SetActive(true);
        }    
    }

    private void Resume() {
        this.Toggle();
    }

    private void Restart() {
        ResetGameSpeed();
        HandleRestart();
    }

    private void Exit() {
        Application.Quit();
    }
}
