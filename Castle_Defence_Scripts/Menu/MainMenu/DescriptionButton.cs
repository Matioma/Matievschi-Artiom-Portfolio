using UnityEngine;

namespace Assets.Scripts.Menu.MainMenu
{
    public class DescriptionButton : BaseButton
    {
        public void OnMouseOver()
        {
            if ( Input.GetMouseButtonDown(0) )
            {
#pragma warning disable 618
                Application.LoadLevel("Description");
#pragma warning restore 618
            }
        }
    }
}
