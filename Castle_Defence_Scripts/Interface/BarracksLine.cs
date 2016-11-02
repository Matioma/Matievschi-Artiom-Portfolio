using Assets.Utilities;
using UnityEngine;

namespace Assets.Scripts.Interface
{
    public class BarracksLine : MonoBehaviour
    {
        public void Awake()
        {
            gameObject.GetComponent<GUIText>().text =
                "To build  barracks press B.It's price is "
                + Database.GetValue().BarracksPrice;
        }

        public void Update()
        {
            gameObject.GetComponent<GUIText>().text =
                "To build barracks press B.It's price is "
                + Database.GetValue().BarracksPrice;
        }
    }
}
