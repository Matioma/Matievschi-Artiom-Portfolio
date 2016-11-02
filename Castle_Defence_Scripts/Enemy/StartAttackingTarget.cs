using Assets.Scripts.Buildings;
using Assets.Scripts.Defender;
using Assets.Utilities;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class StartAttackingTarget : MonoBehaviour
    {
        private GameObject _parentEnemyUnit;

        private GameObject _enemyTarget;

        private float _enemyAttackTime;

        public void Start()
        {
            _enemyAttackTime = Database.GetValue().EnemyAttackTime;

            gameObject.GetComponent<SphereCollider>().radius = Database.GetValue().TargetHitRange;

            _parentEnemyUnit = transform.parent.gameObject;
        }

        public void Update()
        {
            _enemyTarget = _parentEnemyUnit.gameObject.GetComponent<EnemyUnit>().Target;

            if ( _enemyTarget == null )
            {
                _parentEnemyUnit.gameObject.GetComponent<EnemyUnit>().StopMovement = false;
            }

            _enemyAttackTime -= Time.deltaTime;
            if ( _enemyAttackTime >= 0 )
            {
                return;
            }

            DealDamageToTarget();
            _enemyAttackTime = Database.GetValue().EnemyAttackTime;
        }

        public void OnTriggerStay(Collider col)
        {
            if ( _enemyTarget == null )
            {
                return;
            }

            if ( col.gameObject == _enemyTarget )
            {
                _parentEnemyUnit.gameObject.GetComponent<EnemyUnit>().StopMovement = true;
            }
        }

        public void OnTriggerExit(Collider col)
        {
            if ( _enemyTarget == null )
            {
                return;
            }

            if ( col.gameObject == _enemyTarget )
            {
                _parentEnemyUnit.gameObject.GetComponent<EnemyUnit>().StopMovement = false;
            }
        }

        void DealDamageToTarget()
        {
            if ( !_parentEnemyUnit.gameObject.GetComponent<EnemyUnit>().StopMovement )
            {
                return;
            }

            var enemyDamage = Database.GetValue().EnemyDamage;
            switch ( _enemyTarget.gameObject.tag )
            {
                case "Player":
                    _enemyTarget.gameObject.GetComponent<MainCharacter>().Health -= enemyDamage;
                    break;
                case "Defender":
                    _enemyTarget.gameObject.GetComponent<AlliedUnit>().Health -= enemyDamage;
                    break;
                case "CentralBuilding":
                    _enemyTarget.gameObject.GetComponent<Building>().Health -= enemyDamage;
                    break;
                case "BuildingUnderProtection":
                    _enemyTarget.gameObject.GetComponent<ProtectedBuilding>().Health -= enemyDamage;
                    break;
            }
        }
    }
}
