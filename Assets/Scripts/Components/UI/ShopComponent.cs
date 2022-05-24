using Model;
using UnityEngine;

namespace Components.UI
{
    public class ShopComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _shopLayout;
        
        private GameSession _gameSession;

        private void Awake() => _gameSession = FindObjectOfType<GameSession>();

        private void Pause() => _gameSession.PauseController.isPause = true;

        private void SetActive() => _shopLayout.SetActive(true);
    }
}
