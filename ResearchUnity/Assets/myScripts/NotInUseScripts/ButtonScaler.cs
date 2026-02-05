using UnityEngine;
using UnityEngine.UI;

public class ScaleCanvas : MonoBehaviour
{
    public RectTransform panel;
    public RectTransform section1;
    public RectTransform section2;
    public RectTransform section3;

    public float paddingPercentage = 0.05f; // Adjust padding as a percentage of the panel's height
    public float horizontalPadding = 125f; // Padding to be added on the left and right sides of buttons

    void Start()
    {
        // Get the canvas scaler component
        CanvasScaler canvasScaler = GetComponent<CanvasScaler>();

        // Get the reference resolution
        Vector2 referenceResolution = canvasScaler.referenceResolution;

        // Get the current screen resolution
        Vector2 screenSize = new Vector2(Screen.width, Screen.height);

        // Calculate the scale factor for the canvas
        float scaleFactor = Mathf.Min(screenSize.x / referenceResolution.x, screenSize.y / referenceResolution.y);

        // Set the scale factor for the canvas scaler
        canvasScaler.scaleFactor = scaleFactor;

        // Scale the panel to fit the screen
        panel.sizeDelta = new Vector2(screenSize.x / scaleFactor, screenSize.y / scaleFactor);

        // Calculate the available height for sections after applying padding
        float availableHeight = panel.sizeDelta.y * (1 - paddingPercentage * 2);

        // Calculate the height of each section
        float sectionHeight = availableHeight / 3f;

        // Calculate the padding between sections
        float padding = panel.sizeDelta.y * paddingPercentage;

        // Calculate the width of each section with horizontal padding
        float sectionWidth = panel.sizeDelta.x - horizontalPadding * 2;

        // Set the size of each section
        section1.sizeDelta = new Vector2(sectionWidth, sectionHeight);
        section2.sizeDelta = new Vector2(sectionWidth, sectionHeight);
        section3.sizeDelta = new Vector2(sectionWidth, sectionHeight);

        // Position sections vertically with padding
        section1.anchoredPosition = new Vector2(0f, panel.sizeDelta.y / 2f - sectionHeight / 2f);
        section2.anchoredPosition = new Vector2(0f, section1.anchoredPosition.y - sectionHeight - padding);
        section3.anchoredPosition = new Vector2(0f, section2.anchoredPosition.y - sectionHeight - padding);
    }
}
