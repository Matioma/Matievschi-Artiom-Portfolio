using System.Collections.Generic;
using Assets.Utilities;
using UnityEngine;

namespace Assets.Scripts
{
    public class MainCharacter : MonoBehaviour
    {
        public int Health;

        private float _timeBetweenShot;

        private GameObject _launcher;
        private readonly List<GameObject> _arrowList = new List<GameObject>();

        public GameObject DefeatMenu;
        public GameObject PauseMenu;

        public void Awake()
        {
            Cursor.visible = false;
        }

        public void Start()
        {
            _timeBetweenShot = Database.GetValue().TimeBetweenShot;

            Health = Database.GetValue().CharacterHealth;

            _launcher = GameObject.FindWithTag("CharacterBulletLauncher");
            //_arrowLauncher = GameObject.FindWithTag("MainCamera");

            var arrowInstance = Instantiate(Database.GetValue().ArrowPrefab);
            transform.position = _launcher.transform.position;
            transform.rotation = _launcher.transform.rotation;
            arrowInstance.SetActive(false);
            _arrowList.Add(arrowInstance);
        }

        public void Update()
        {
            ShotDelay();

            if ( Health <= 0 )
            {
                DefeatMenu.gameObject.SetActive(true);
            }
        }

        /// <summary>
        /// Check time between shots
        /// </summary>
        private void ShotDelay()
        {
            _timeBetweenShot -= Time.deltaTime;
            if ( _timeBetweenShot > 0 )
            {
                return;
            }

            if ( Input.GetMouseButtonDown(0) )
            {
                BulletPooling();
                _timeBetweenShot = Database.GetValue().TimeBetweenShot;
            }
        }

        private void BulletPooling()
        {
            var addNewObject = false;

            foreach ( var arrowItem in _arrowList )
            {
                if ( arrowItem.activeInHierarchy )
                {
                    addNewObject = true;
                    continue;
                }

                arrowItem.transform.position = _launcher.transform.position;
                arrowItem.transform.rotation = _launcher.transform.rotation;
                arrowItem.gameObject.GetComponent<Rigidbody>().velocity = transform.forward *
                                                                      Database.GetValue().ArrowSpeed;

                arrowItem.SetActive(true);
                addNewObject = false;
                break;
            }

            if ( !addNewObject )
            {
                return;
            }

            var arrowInstance = Instantiate(Database.GetValue().ArrowPrefab);
            _arrowList.Add(arrowInstance);
            arrowInstance.transform.position = _launcher.transform.position;
            arrowInstance.transform.rotation = _launcher.transform.rotation;
            arrowInstance.gameObject.GetComponent<Rigidbody>().velocity = transform.forward *
                                                                      Database.GetValue().ArrowSpeed;
        }
    }
}
