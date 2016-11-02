using UnityEngine;

namespace Assets.Scripts.Menu
{
    public class ContinueButton : BaseButton
    {
        public GameObject MenuObject;

        public void OnMouseOver()
        {
            if ( Input.GetMouseButtonDown(0) )
            {
                PauseMechanics.MenuActive = false;
            }
        }
    }
}
