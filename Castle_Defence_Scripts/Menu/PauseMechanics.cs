using UnityEngine;

namespace Assets.Scripts.Menu
{
    public class PauseMechanics : MonoBehaviour
    {
        public GameObject MenuObject;

        public static bool MenuActive;

        public void Start()
        {
            MenuObject.gameObject.SetActive(MenuActive);
        }

        public void Update()
        {
            if ( Input.GetKeyDown(KeyCode.Escape) )
            {
                MenuActive = !MenuActive;
            }

            MenuObject.gameObject.SetActive(MenuActive);
        }
    }
}
