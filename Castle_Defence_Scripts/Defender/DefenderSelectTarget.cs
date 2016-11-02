using Assets.Utilities;
using UnityEngine;

namespace Assets.Scripts.Defender
{
    public class DefenderSelectTarget : MonoBehaviour
    {
        private GameObject _parentEnemyUnit;

        private AlliedUnit _allyUnit;

        public void Start()
        {
            gameObject.GetComponent<SphereCollider>().radius = Database.GetValue().TargetDetactionRange;
            _parentEnemyUnit = transform.parent.gameObject;
        }

        public void Update()
        {
            _allyUnit = _parentEnemyUnit.gameObject.GetComponent<AlliedUnit>();
        }

        public void OnTriggerStay(Collider col)
        {
            if ( _allyUnit == null
                || _allyUnit.Target != null )
            {
                return;
            }

            if ( col.gameObject.tag == "Enemy" )
            {
                _allyUnit.Target = col.gameObject;
            }
        }

        public void OnTriggerExit(Collider col)
        {
            if ( _allyUnit != null
                && col.gameObject == _allyUnit.Target )
            {
                _allyUnit.Target = null;
            }
        }
    }
}
