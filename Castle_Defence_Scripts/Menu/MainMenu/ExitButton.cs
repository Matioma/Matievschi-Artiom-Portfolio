using UnityEngine;

namespace Assets.Scripts.Menu.MainMenu
{
    public class ExitButton : BaseButton
    {
        public void OnMouseOver()
        {
            if ( Input.GetMouseButtonDown(0) )
            {
                Application.Quit();
            }
        }
    }
}
