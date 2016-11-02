using Assets.Utilities;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyUnit : MonoBehaviour
    {
        public GameObject Target;
        public bool StopMovement = false;
        
        public int EnemyHealth;

        public int PathPointIndex = 0;

        public void Start()
        {
            EnemyHealth = Database.GetValue().EnemyHealth;
        }

        public void Update()
        {
            if ( EnemyHealth <= 0 )
            {
                Database.GetValue().Money += Database.GetValue().AmountOfMoneyForKill;
                gameObject.SetActive(false);
            }

            if ( Target != null )
            {
                if ( !StopMovement )
                {
                    MovementAfterTarget(Target);
                }

                if ( !Target.activeInHierarchy )
                {
                    Target = null;
                }
            }
            else
            {
                MovementToPathPoint(PathPointIndex);
            }
        }

        /// <summary>
        /// Look at enemy target and move forwadr to it
        /// </summary>
        /// <param name="target"></param>
        private void MovementAfterTarget(GameObject target)
        {
            transform.LookAt(target.transform);
            transform.Translate(0, 0, Database.GetValue().EnemyMovementSpeed);
        }

        /// <summary>
        /// Look paht point and move forward to it
        /// </summary>
        /// <param name="pathPointIndex"></param>
        private void MovementToPathPoint(int pathPointIndex)
        {
            var pathPoint = Database.GetValue().Path[pathPointIndex];
            transform.LookAt(pathPoint.transform);
            transform.Translate(0, 0, Database.GetValue().EnemyMovementSpeed);
        }
    }
}
