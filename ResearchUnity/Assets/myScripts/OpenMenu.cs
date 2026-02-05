using UnityEngine;
using UnityEngine.UI;

public class OpenMenu : MonoBehaviour
{
    public GameObject canvasA; // Assign Canvas A in the Inspector
    public GameObject canvasB; // Assign Canvas B in the Inspector

    void Start()
    {
        canvasB.SetActive(false);
    }

    // This method will be called when the UI button is clicked
    public void ToggleMenus()
    {
        if (canvasA.activeSelf)
        {
            // Hide Canvas A and show Canvas B
            canvasA.SetActive(false);
            canvasB.SetActive(true);
        }
        else
        {
            // Hide Canvas B and show Canvas A
            canvasB.SetActive(false);
            canvasA.SetActive(true);
        }
    }
}