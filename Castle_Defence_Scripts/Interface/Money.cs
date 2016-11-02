using System.Globalization;
using Assets.Utilities;
using UnityEngine;

namespace Assets.Scripts.Interface
{
    public class Money : MonoBehaviour
    {
        public void Update()
        {
            gameObject.GetComponent<GUIText>().text = Database.GetValue().Money.ToString(CultureInfo.InvariantCulture);
        }
    }
}
