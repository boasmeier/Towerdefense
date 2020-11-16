using UnityEngine;
using UnityEngine.UI;

public class UIColors 
{
    private static Color highlightColor = Color.cyan;
    private static Color normalColor = Color.white;

    public static void Highlight(Button button)
    {
        var colors = button.colors;
        colors.normalColor = highlightColor;
        colors.selectedColor = highlightColor;
        button.colors = colors;
    }

    public static void UnHighlight(Button button)
    {
        var colors = button.colors;
        colors.normalColor = normalColor;
        colors.selectedColor = normalColor;
        button.colors = colors;
    }
}
