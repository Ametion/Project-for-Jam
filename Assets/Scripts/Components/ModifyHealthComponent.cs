using UnityEngine;

namespace Components
{
    public class ModifyHealthComponent : MonoBehaviour
    {
        [SerializeField] private int hpDelta;
        
        public void ModifyHealth(GameObject go)
        {
            var healthComponent = go.GetComponent<HealthComponent>();

            if (healthComponent != null)
                healthComponent.ModifyHealth(hpDelta);

        }
    }
}