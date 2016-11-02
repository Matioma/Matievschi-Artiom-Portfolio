using Assets.Utilities;
using UnityEngine;

namespace Assets.Scripts
{
    public class Building : MonoBehaviour
    {
        public int Health;

        public void Start()
        {
            switch ( gameObject.tag )
            {
                case "Fortress":
                    Health = Database.GetValue().FortressHealth;
                    break;
                case "CentralBuilding":
                    Health = Database.GetValue().CentralBuildingsHealth;
                    break;
            }
        }

        public void Update()
        {
            if ( Health > 0 )
            {
                return;
            }

            gameObject.SetActive(false);
        }
    }
}
