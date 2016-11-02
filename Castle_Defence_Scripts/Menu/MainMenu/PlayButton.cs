using UnityEngine;

namespace Assets.Scripts.Menu.MainMenu
{
    public class PlayButton : BaseButton
    {
        public void OnMouseOver()
        {
            if ( Input.GetMouseButtonDown(0) )
            {
#pragma warning disable 618
                Application.LoadLevel("1");
#pragma warning restore 618
            }
        }
    }
}
