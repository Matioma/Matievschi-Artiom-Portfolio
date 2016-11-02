using Assets.Utilities;
using UnityEngine;

namespace Assets.Scripts.Interface
{
    public class FortressLine : MonoBehaviour
    {
        public void Awake()
        {
            gameObject.GetComponent<GUIText>().text =
                "To build fortress press F.It's price is "
                + Database.GetValue().FortressPrice;
        }
    }
}
