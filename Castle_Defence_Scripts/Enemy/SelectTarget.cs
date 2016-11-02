using Assets.Utilities;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class SelectTarget : MonoBehaviour
    {
        private GameObject _parentEnemyUnit;
        private GameObject _enemyTarget;

        public void Start()
        {
            gameObject.GetComponent<SphereCollider>().radius = Database.GetValue().TargetDetactionRange;
            _parentEnemyUnit = transform.parent.gameObject;
        }

        public void Update()
        {
            _enemyTarget = _parentEnemyUnit.gameObject.GetComponent<EnemyUnit>().Target;
        }

        public void OnTriggerStay(Collider col)
        {
            if ( _enemyTarget != null ) // if enemy doesn't have any target he will get do following  
            {
                return;
            }

            if ( col.gameObject.tag == "CentralBuilding"
                 || col.gameObject.tag == "Defender"
                 || col.gameObject.tag == "BuildingUnderProtection"
                 || col.gameObject.tag == "Player" )
            {
                _parentEnemyUnit.gameObject.GetComponent<EnemyUnit>().Target = col.gameObject;
            }
        }
    }
}
