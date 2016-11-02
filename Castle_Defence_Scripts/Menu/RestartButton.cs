using UnityEngine;

namespace Assets.Scripts.Menu
{
    public class RestartButton : BaseButton
    {
        public void OnMouseOver()
        {
            if ( Input.GetMouseButtonDown(0) )
            {
                PauseMechanics.MenuActive = false;
#pragma warning disable 618
                Application.LoadLevel("1");
#pragma warning restore 618
            }
        }
    }
}