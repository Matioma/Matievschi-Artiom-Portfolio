using Assets.Scripts.Enemy;
using Assets.Utilities;
using UnityEngine;

namespace Assets.Scripts.Defender
{
    public class DefenderStartAttack : MonoBehaviour
    {
        private float _targetHitRange;
        private GameObject _parentEnemyUnit;
        private GameObject _allyTarget;
        private int _allyDamage;
        private float _enemyAttackTime;

        public void Start()
        {
            _enemyAttackTime = Database.GetValue().EnemyAttackTime;
            _allyDamage = Database.GetValue().AllyDamage;
            _targetHitRange = Database.GetValue().TargetHitRange;
            gameObject.GetComponent<SphereCollider>().radius = _targetHitRange;

            _parentEnemyUnit = transform.parent.gameObject;
        }

        public void Update()
        {
            _enemyAttackTime -= Time.deltaTime;
            if (_enemyAttackTime <= 0)
            {
                _enemyAttackTime = Database.GetValue().EnemyAttackTime;
                DealDamageToTarget();
            }

            _allyTarget = _parentEnemyUnit.gameObject.GetComponent<AlliedUnit>().Target;

            if ( _allyTarget == null )
            {
                _parentEnemyUnit.gameObject.GetComponent<AlliedUnit>().StopMovement = false;
            }
        }

        public void OnTriggerStay(Collider col)
        {
            if ( _allyTarget == null )
            {
                return;
            }

            if ( col.gameObject == _allyTarget )
            {
                _parentEnemyUnit.gameObject.GetComponent<AlliedUnit>().StopMovement = true;
            }
        }
        
        public void OnTriggerExit(Collider col)
        {
            if ( _allyTarget == null )
            {
                return;
            }

            if ( col.gameObject == _allyTarget )
            {
                _parentEnemyUnit.gameObject.GetComponent<AlliedUnit>().StopMovement = false;
            }
        }

        public void DealDamageToTarget()
        {
            if ( !_parentEnemyUnit.gameObject.GetComponent<AlliedUnit>().StopMovement )
            {
                return;
            }

            if ( _allyTarget.gameObject.tag == "Enemy" )
            {
                _allyTarget.gameObject.GetComponent<EnemyUnit>().EnemyHealth -= _allyDamage;
            }
        }
    }
}

