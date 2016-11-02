using Assets.Utilities;
using UnityEngine;

namespace Assets.Scripts.Interface
{
    public class TowerLine : MonoBehaviour
    {
        public void Awake()
        {
            gameObject.GetComponent<GUIText>().text =
                string.Format(
                    "To build Tower press T.It's price is {0}",
                    Database.GetValue().TowerPrice);
        }
    }
}
