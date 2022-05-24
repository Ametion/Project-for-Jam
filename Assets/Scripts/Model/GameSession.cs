using UnityEngine;

namespace Model
{
    public class GameSession : MonoBehaviour
    {
        [SerializeField] private PlayerDataModel _playerData;
        [SerializeField] private PlayerStatisticModel _playerStatistic;
        [SerializeField] private PauseControllerModel _pauseController;
        [SerializeField] private PlayerProtectionModel _playerProtection;
        
        public PlayerDataModel PlayerData => _playerData;
        public PauseControllerModel PauseController => _pauseController;
        public PlayerStatisticModel PlayerStatisticModel => _playerStatistic;
        public PlayerProtectionModel PlayerProtectionModel => _playerProtection;

        private void Awake()
        {
            if (IsSessionExit())
                DestroyImmediate(gameObject);
            else
                DontDestroyOnLoad(this);
        }

        private bool IsSessionExit()
        {
            var sessions = FindObjectsOfType<GameSession>();
            
            foreach (var gameSession in sessions)
                if (gameSession != this)
                    return true;

            return false;
        }

        public void SetDefoultValues()
        {
            _playerData.SetDefoultValues();
            _pauseController.SetDefoultValues();
        }
    }
}