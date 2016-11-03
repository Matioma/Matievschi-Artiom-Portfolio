using UnityEngine;
using System.Collections;

public class MainMenuExit : MonoBehaviour
{
    public Texture Initial, final;

    private bool ButtonPressed;

    private void OnMouseEnter()
    {
        guiTexture.texture = final;
        ButtonPressed = true;
    }

    private void OnMouseExit()
    {
       guiTexture.texture = Initial;
       ButtonPressed = false;
    }

    void Update ()
    {
        if (Input.GetMouseButton(0) && ButtonPressed == true)
        {
            Application.Quit();
        }
    }
}
