using System.Collections.Generic;
using Assets.Utilities;
using UnityEngine;

namespace Assets.Scripts.Buildings
{
    public class ArrowLauncher : MonoBehaviour
    {
        private readonly List<GameObject> _arrowList = new List<GameObject>();

        public GameObject ParentGameObject;
        public GameObject Target;

        private float _shotTime;

        public void Start()
        {
            ParentGameObject = gameObject.transform.parent.gameObject;

            gameObject.GetComponent<SphereCollider>().radius = Database.GetValue().TowerRange;

            _shotTime = Database.GetValue().TowerAtackSpeed;

            var obj = Instantiate(Database.GetValue().ArrowPrefab);
            obj.SetActive(false);
            _arrowList.Add(obj);
        }

        // Update is called once per frame
        public void Update()
        {
            _shotTime -= Time.deltaTime;
            if ( Target == null )
            {
                return;
            }

            transform.LookAt(Target.transform);
            if ( _shotTime <= 0 )
            {
                ArrowPooling();
                _shotTime = Database.GetValue().TowerAtackSpeed;
            }
            if ( !Target.activeInHierarchy )
            {
                Target = null;
            }
        }

        public void ArrowPooling()//Adding to list new GameObjects
        {
            var addNewObject = false; // check if it is required to create new object

            foreach ( var arrow in _arrowList )
            {
                if ( arrow.activeInHierarchy )
                {
                    addNewObject = true;
                    continue;
                }

                arrow.transform.position = gameObject.transform.position;
                arrow.transform.rotation = gameObject.transform.rotation;
                arrow.SetActive(true);
                arrow.gameObject.GetComponent<Rigidbody>().velocity = transform.forward *
                                                                      Database.GetValue().ArrowSpeed;
                addNewObject = false;
                break;
            }

            if ( !addNewObject )
            {
                return;
            }

            var arrowInstance = Instantiate(Database.GetValue().ArrowPrefab);
            _arrowList.Add(arrowInstance);
            arrowInstance.transform.position = gameObject.transform.position;
            arrowInstance.transform.rotation = gameObject.transform.rotation;
            arrowInstance.gameObject.GetComponent<Rigidbody>().velocity = transform.forward *
                                                                Database.GetValue().ArrowSpeed;
        }

        public void OnTriggerStay(Collider col)
        {
            if ( Target != null )
            {
                return;
            }

            if ( col.gameObject.tag == "Enemy" )
            {
                Target = col.gameObject;
            }
        }
    }
}
