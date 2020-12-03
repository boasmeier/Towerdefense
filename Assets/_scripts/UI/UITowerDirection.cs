using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITowerDirection : MonoBehaviour, IArrowsInputController
{
    public event Action HandleLeft = delegate { };
    public event Action HandleRight = delegate { };
    public event Action HandleUp = delegate { };
    public event Action HandleDown = delegate { };
    public event Action HandleTowerDirectionClickSound = delegate { };

    [SerializeField] Button upButton;
    [SerializeField] Button leftButton;
    [SerializeField] Button rightButton;
    [SerializeField] Button downButton;

    private Button selected;

    public void OnEnable()
    {
        upButton.onClick.AddListener(() => HandleUp()) ;
        downButton.onClick.AddListener(() => HandleDown());
        leftButton.onClick.AddListener(() => HandleLeft());
        rightButton.onClick.AddListener(() => HandleRight());

        upButton.onClick.AddListener(() => HandleTowerDirectionClickSound()) ;
        downButton.onClick.AddListener(() => HandleTowerDirectionClickSound());
        leftButton.onClick.AddListener(() => HandleTowerDirectionClickSound());
        rightButton.onClick.AddListener(() => HandleTowerDirectionClickSound());

        EconomyManager.DirectionSelected += HighlightSelected;
    }

    public void OnDisable()
    {
        EconomyManager.DirectionSelected -= HighlightSelected;
    }

    public void HighlightSelected(int direction)
    {
        if (direction == 0)
        {  
            select(upButton);
        }
        else if (direction == 90)
        {
            select(rightButton);
        }
        else if (direction == 180)
        {
            select(downButton);
        }
        else
        {
            select(leftButton);
        }
    }

    private void select(Button select)
    {
        var previous = selected;
        this.selected = select;
        if(previous != null)
        {
            UIColors.UnHighlight(previous);
        }
        UIColors.Highlight(selected);
    }
}
