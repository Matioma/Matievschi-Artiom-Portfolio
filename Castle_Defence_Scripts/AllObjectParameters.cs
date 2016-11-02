using UnityEngine;

namespace Assets.Scripts
{
    public class AllObjectParameters : MonoBehaviour
    {
        //fortress parameters
        public int FortressHealth;
        public int FortressPrice;
        //types of central buildings
        public int CentralBuildingsHealth;

        //farm parameters
        public int FarmPrice;
        public int FarmIncome;

        //barracks parameters
        public int BarracksPrice;
        public float TimeBetweenAlliedCreation;

        // tower parameters
        public float TowerRange;
        public int TowerPrice;
        public float TowerAtackSpeed;
        //
        //Arrow
        public GameObject ArrowPrefab;
        public int ArrowDamage;
        public float ArrowSpeed;
        //
        //Allied
        public GameObject AllyPrefab;
        //ally Parameters
        public GameObject AllySpawnPos;
        public float AllyMovementSpeed;
        public int AllyHealth;
        public int AllyDamage;
        //
        //Enemy
        public GameObject EnemyPrefab;
        //EnemyParameters
        public int EnemyHealth;
        public int EnemyDamage;
        public int AmountOfMoneyForKill;
        public float EnemyMovementSpeed;
        public float TargetDetactionRange;
        public float TargetHitRange;
        public float EnemyAttackTime;
        //
        //Waves Parameters
        public int[] NumberOfEnemiesInEachWave;
        public float TimeBetweenWaves;
        public float TimeBetweenUnitCreation;
        //
        //Main Character
        public int CharacterHealth;
        public float Money;
        public float TimeBetweenShot;
        // Use this for initialization

        //Path
        public GameObject[] Path;

        //Defended building
        public int DefendedBuildingHealth;

        //Building sign
        public float SignActivationRange;
        public GameObject FortressBuyMenu, CentralBuildingBuyMenu;

        //Not enough money warning
        public GameObject NotEnoughMoney;
    }
}
