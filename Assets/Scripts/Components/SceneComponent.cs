using System;
using Model;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Components
{
    public class SceneComponent : MonoBehaviour
    {
        private GameSession _gameSession;

        private void Awake() => _gameSession = FindObjectOfType<GameSession>();

        public void LoadSceneById(int id) => SceneManager.LoadScene(id);

        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            _gameSession.SetDefoultValues();
        }
    }
}