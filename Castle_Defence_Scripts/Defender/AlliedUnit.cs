using Assets.Utilities;
using UnityEngine;

namespace Assets.Scripts.Defender
{
    public class AlliedUnit : MonoBehaviour
    {
        public GameObject Target;
        public bool StopMovement = false;

        public float MovementSpeed;
        public int Health;

        private GameObject _spawnPos;

        public void Start()
        {
            MovementSpeed = Database.GetValue().AllyMovementSpeed;
            Health = Database.GetValue().AllyHealth;
            _spawnPos = Database.GetValue().AllySpawnPos;
        }

        public void Update()
        {
            if ( Health <= 0 )
            {
                gameObject.SetActive(false);
            }

            if ( Target == null )
            {
                MovementAfterTarget(_spawnPos);
                return;
            }

            if ( !StopMovement )
            {
                MovementAfterTarget(Target);
            }

            if ( !Target.activeInHierarchy )
            {
                Target = null;
            }
        }
        /// <summary>
        /// Looking enemy target and move forward to it
        /// </summary>
        /// <param name="target"></param>
        private void MovementAfterTarget(GameObject target)
        {
            transform.LookAt(target.transform);
            transform.Translate(0, 0, MovementSpeed);
        }
    }
}
