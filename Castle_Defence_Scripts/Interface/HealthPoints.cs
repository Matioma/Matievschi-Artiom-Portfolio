using UnityEngine;

namespace Assets.Scripts.Interface
{
    public class HealthPoints : MonoBehaviour
    {
        private GameObject _player;

        public void Awake()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
        }

        // Update is called once per frame
        public void Update()
        {
            if ( _player.GetComponent<MainCharacter>().Health > 0 )
            {
                gameObject.GetComponent<GUIText>().text = _player.GetComponent<MainCharacter>().Health.ToString();
            }
            else
            {
                gameObject.GetComponent<GUIText>().text = 0.ToString();
            }
        }
    }
}
