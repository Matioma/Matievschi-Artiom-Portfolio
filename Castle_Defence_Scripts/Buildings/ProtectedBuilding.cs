using Assets.Utilities;
using UnityEngine;

namespace Assets.Scripts.Buildings
{
    public class ProtectedBuilding : MonoBehaviour {

        public int Health;
        public GameObject DefeatMenu;

        public void Start () 
        {
            Health = Database.GetValue().DefendedBuildingHealth;
        }

        public void Update () 
        {
            if (Health > 0)
            {
                return;
            }

            DefeatMenu.gameObject.SetActive(true);
           // PauseMechanics.MenuActive = true;
        }
    }
}
