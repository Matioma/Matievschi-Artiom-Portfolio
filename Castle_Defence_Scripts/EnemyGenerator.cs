using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Enemy;
using Assets.Scripts.Interface;
using Assets.Utilities;
using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyGenerator : MonoBehaviour
    {
        private Vector3 _spawnPos;          // Enemy Spawn position

        private readonly List<GameObject> _enemyUnitsPooled = new List<GameObject>();

        private float _timeBetweenWaves;    //	Timer Variables
        private float _timeBetweenUnits;    //

        private int _wave;          //represents the wave number,it is the index of 
        private int _unitNumber;	//array numberOfEnemiesInEachWave

        public void Start()
        {
            var path = Database.GetValue().Path.First();
            _spawnPos = path.gameObject.transform.position;

            var obj = Instantiate(Database.GetValue().EnemyPrefab);
            obj.SetActive(false);
            _enemyUnitsPooled.Add(obj);

            _timeBetweenWaves = Database.GetValue().TimeBetweenWaves;
            _timeBetweenUnits = Database.GetValue().TimeBetweenUnitCreation;
        }

        public void Update()
        {
            Waves();
        }

        private void Waves()
        {
            NextWaveIn.NextWaveTime = _timeBetweenWaves;
            _timeBetweenWaves -= Time.deltaTime;
            if ( _timeBetweenWaves > 0 )
            {
                return;
            }

            _timeBetweenUnits -= Time.deltaTime;
            if ( _timeBetweenUnits < 0
                 && _unitNumber < Database.GetValue().NumberOfEnemiesInEachWave[_wave] )
            {
                EnemyUnitPooling();
                _unitNumber++;
                _timeBetweenUnits = Database.GetValue().TimeBetweenUnitCreation;
            }

            if ( _unitNumber != Database.GetValue().NumberOfEnemiesInEachWave[_wave] )
            {
                return;
            }

            _unitNumber = 0;
            _wave++;

            _timeBetweenWaves = Database.GetValue().TimeBetweenWaves;
        }

        /// <summary>
        /// Fill list of Enemies
        /// </summary>
        private void EnemyUnitPooling()
        {
            var addNewObject = false;

            foreach ( var enemyItem in _enemyUnitsPooled )
            {
                if ( enemyItem.activeInHierarchy )
                {
                    addNewObject = true;
                    continue;
                }

                enemyItem.transform.position = _spawnPos;
                var enemy = enemyItem.gameObject.GetComponent<EnemyUnit>();

                enemy.EnemyHealth = Database.GetValue().EnemyHealth;
                enemy.Target = null;
                enemy.PathPointIndex = 0;

                enemyItem.SetActive(true);
                addNewObject = false;
                break;
            }

            if ( !addNewObject )
            {
                return;
            }

            var obj = Instantiate(Database.GetValue().EnemyPrefab);
            _enemyUnitsPooled.Add(obj);
            obj.transform.position = _spawnPos;
        }
    }
}
