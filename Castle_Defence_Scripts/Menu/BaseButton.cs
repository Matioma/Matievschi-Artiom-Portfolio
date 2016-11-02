using UnityEngine;

namespace Assets.Scripts.Menu
{
    public class BaseButton : MonoBehaviour
    {
        public Texture InitialTexture;
        public Texture PressedTexture;

        public void OnMouseEnter()
        {
            GetComponent<GUITexture>().texture = PressedTexture;
        }

        public void OnMouseExit()
        {
            GetComponent<GUITexture>().texture = InitialTexture;
        }
    }
}
