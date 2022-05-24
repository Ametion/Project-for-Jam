using UnityEngine;

namespace Components.UI
{
    public class LiveBarComponent : MonoBehaviour
    {
        [SerializeField] private GameObject[] hearts;

        private Player _player;
        private HealthComponent _playerHealthComponent;

        private void Awake()
        {
            _player = FindObjectOfType<Player>();
            _playerHealthComponent =  _player.GetComponent<HealthComponent>();
        }

        private void Update()
        {
            var health = _playerHealthComponent.GetHealth();

            for (int i = 0; i < 3; i++)
            {
                if(health > i) hearts[i].SetActive(true);
                else hearts[i].SetActive(false);
            }
        }
    }
}