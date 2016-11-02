using Assets.Utilities;
using UnityEngine;

namespace Assets.Scripts.Buildings
{
    public class Barracks : MonoBehaviour
    {
        private float _workVariable;

        public void Start()
        {
            _workVariable = Database.GetValue().TimeBetweenAlliedCreation;
        }

        public void Update()
        {
            _workVariable -= Time.deltaTime;
            if ( _workVariable > 0 )
            {
                return;
            }

            DefenderCreation();
            _workVariable = Database.GetValue().TimeBetweenAlliedCreation;
        }

        private static void DefenderCreation()
        {
            var dataBase = GameObject.FindWithTag("DataBase");
            dataBase.gameObject.GetComponent<AllyGenerator>().CreateDefender = true;
        }
    }
}
