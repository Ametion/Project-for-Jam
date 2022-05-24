using UnityEngine;

namespace Components
{
    public class SpawnComponent : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private Transform _transform;
        [SerializeField] private Transform parent;

        public void Spawn() => Instantiate(prefab);
        public void SpawnInParent() => Instantiate(prefab, parent);
        public void SpawnInParentByPos() => Instantiate(prefab, _transform.position, _transform.rotation, parent);
    }
}