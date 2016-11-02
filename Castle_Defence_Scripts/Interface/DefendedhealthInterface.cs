using Assets.Scripts.Buildings;
using UnityEngine;

namespace Assets.Scripts.Interface
{
    public class DefendedhealthInterface : MonoBehaviour
    {
        private GameObject _protectedBuilding;

        public void Start()
        {
            _protectedBuilding = GameObject.FindGameObjectWithTag("BuildingUnderProtection");
        }

        public void Update()
        {
            if( _protectedBuilding.gameObject.GetComponent<ProtectedBuilding>().Health >0)
            {
                gameObject.GetComponent<GUIText>().text =
                 _protectedBuilding.gameObject.GetComponent<ProtectedBuilding>().Health.ToString();
            }
            else
            {
                gameObject.GetComponent<GUIText>().text = 0.ToString();
            }
        }
    }
}
