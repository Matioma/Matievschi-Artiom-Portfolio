using UnityEngine;

namespace Assets.Scripts.Menu.DescriptionScene
{
    public class BackButton : BaseButton
    {
        public void OnMouseOver()
        {
            if ( Input.GetMouseButtonDown(0) )
            {
#pragma warning disable 618
                Application.LoadLevel("Menu");
#pragma warning restore 618
            }
        }
    }
}
