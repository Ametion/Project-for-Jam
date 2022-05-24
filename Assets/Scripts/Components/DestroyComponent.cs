using UnityEngine;

namespace Components
{
    public class DestroyComponent : MonoBehaviour
    {
        public void DestroySelf() => Destroy(gameObject);

        public void DestroyTarget(GameObject _target) => Destroy(_target);

        public void DestroyByName(string name) => Destroy(GameObject.Find(name));
    }
}