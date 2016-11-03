using UnityEngine;
using System.Collections;

public class RestartButtonFromMenu : MonoBehaviour
{
    public Texture Initial, Final;

    private bool MouseEnter;

    private void OnMouseEnter()
    {
        guiTexture.texture = Final;
        MouseEnter = true;
    }
    private void OnMouseExit()
    {
        guiTexture.texture = Initial;
        MouseEnter = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && MouseEnter == true)
        {
            Movement.restartButtonPressed = true;
            DefeatMenu.Defeat = false;
            MenuSetActive.Victory = false;
        }
     
    }
}
