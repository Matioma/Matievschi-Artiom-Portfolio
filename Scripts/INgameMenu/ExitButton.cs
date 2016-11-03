using UnityEngine;
using System.Collections;

public class ExitButton : MonoBehaviour {

    public Texture Initial, Final;

    private bool ButtonPressed;
    private void OnMouseEnter()
    {
        guiTexture.texture = Final;
        ButtonPressed = true;
    }
    private void OnMouseExit()
    {
        guiTexture.texture = Initial;
        ButtonPressed = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ButtonPressed)
        {
            Application.LoadLevel("Main Menu");
            MenuSetActive.Victory = false;
        }
    }
}
