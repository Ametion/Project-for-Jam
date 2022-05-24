using System;
using Model;
using Model.Armor;
using Model.Rings;
using UnityEngine;

namespace Components.Shop
{
    public class GeneralShopComponent : MonoBehaviour
    {
        private GameSession _gameSession;

        private void Awake() => _gameSession = FindObjectOfType<GameSession>();

        public void BuyArmor(string PeaceOfArmor)
        {
            Armor newArmor = new Armor(PeaceOfArmor, 5);
            
            if(PeaceOfArmor == "Helmet") _gameSession.PlayerProtectionModel.Helmet ??= newArmor;
            if(PeaceOfArmor == "Chestplate") _gameSession.PlayerProtectionModel.Chestplate ??= newArmor;
            if(PeaceOfArmor == "Pants") _gameSession.PlayerProtectionModel.Pants ??= newArmor;
            if(PeaceOfArmor == "Boots") _gameSession.PlayerProtectionModel.Boots ??= newArmor;
        }
        
        public void BuyRing(string RingElement)
        {
            Ring newRing = new Ring(RingElement);

            if (_gameSession.PlayerProtectionModel.firstRing == null)
            {
                _gameSession.PlayerProtectionModel.firstRing = newRing;
                Debug.Log("BuyRing");
            }
            else if (_gameSession.PlayerProtectionModel.secondRing == null)
            {
                _gameSession.PlayerProtectionModel.secondRing = newRing;
                Debug.Log("BuyRing");
            }
            else if (_gameSession.PlayerProtectionModel.thirdRing == null)
            {
                _gameSession.PlayerProtectionModel.thirdRing = newRing;
                Debug.Log("BuyRing");
            }
            else
                throw new Exception($"You already have ring with {RingElement} element");
        }
    }
}