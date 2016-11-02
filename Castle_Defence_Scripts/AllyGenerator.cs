using System.Collections.Generic;
using Assets.Scripts.Defender;
using Assets.Utilities;
using UnityEngine;

namespace Assets.Scripts
{
    public class AllyGenerator : MonoBehaviour
    {
        private GameObject _allyUnit;

        private Vector3 _spawnPos;
        public List<GameObject> AllyUnitsPooled = new List<GameObject>();

        public bool CreateDefender;

        public void Start()
        {
            _allyUnit = Database.GetValue().AllyPrefab;
            _spawnPos = Database.GetValue().AllySpawnPos.transform.position;

            var obj = Instantiate(_allyUnit);
            obj.SetActive(false);
            AllyUnitsPooled.Add(obj);
        }

        public void Update()
        {
            if ( !CreateDefender )
            {
                return;
            }

            EnemyUnitPooling();
            CreateDefender = false;
        }

        private void EnemyUnitPooling()
        {
            var addNewObject = false;
            foreach ( var allyUnit in AllyUnitsPooled )
            {
                if ( allyUnit.activeInHierarchy )
                {
                    addNewObject = true;
                    continue;
                }

                allyUnit.transform.position = _spawnPos;

                allyUnit.gameObject.GetComponent<AlliedUnit>().Health
                    = Database.GetValue().AllyHealth;
                allyUnit.gameObject.GetComponent<AlliedUnit>().Target = null;

                allyUnit.SetActive(true);
                addNewObject = false;
                break;
            }

            if ( !addNewObject )
            {
                return;
            }

            var obj = Instantiate(_allyUnit);
            AllyUnitsPooled.Add(obj);
            obj.transform.position = _spawnPos;
        }
    }
}
