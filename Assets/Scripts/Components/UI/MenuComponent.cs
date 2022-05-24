
using Model;
using UnityEngine;

namespace Components.UI
{
    public class MenuComponent : MonoBehaviour
    {
        private GameSession _gameSession;

        private void Awake() => _gameSession = FindObjectOfType<GameSession>();

        public void Resume() => _gameSession.PauseController.isPause = false;
    }
}