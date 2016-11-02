using UnityEngine;

namespace Assets.Scripts.Menu
{
    public class MenuButton : BaseButton
    {
        public void OnMouseOver()
        {
            if ( Input.GetMouseButtonDown(0) )
            {
                PauseMechanics.MenuActive = false;
#pragma warning disable 618
                Application.LoadLevel("Menu");
#pragma warning restore 618

            }
        }
    }
}
