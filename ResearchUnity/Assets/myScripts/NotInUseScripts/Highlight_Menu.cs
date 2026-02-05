using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Highlight_Menu : MonoBehaviour
{

    private Outline outline;

    void OnMouseEnter()
    {
        // Check if the Outline component already exists on the GameObject
        outline = GetComponent<Outline>();

        // If the Outline component doesn't exist, add it
        if (outline == null)
        {
            // Add the Outline component to the GameObject
            outline = gameObject.AddComponent<Outline>();

            // Configure the outline properties
            outline.OutlineMode = Outline.Mode.OutlineAll;
            outline.OutlineColor = Color.white;
            outline.OutlineWidth = 25;
        }
        else
        {
            // If the Outline component already exists, override its properties
            outline.OutlineMode = Outline.Mode.OutlineAll;
            outline.OutlineColor = Color.white;
            outline.OutlineWidth = 25;
        }
    }

    void OnMouseExit()
    {
        // Check if the outline variable is not null before destroying it
        if (outline != null)
        {
            Destroy(outline);
            outline = null;
        }
    }

    
}
