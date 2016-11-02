using Assets.Utilities;
using UnityEngine;

namespace Assets.Scripts.Interface
{
    public class FarmLine : MonoBehaviour
    {
        public void Awake()
        {
            gameObject.GetComponent<GUIText>().text =
                "To build farm press F.It's price is "
                + Database.GetValue().FarmPrice;
        }
    }
}
