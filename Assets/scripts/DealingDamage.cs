using UnityEngine;

public class DealingDamage : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private Health _health; 

    public void Click()
    {
        _health.TakeDamage(_damage); 
    }
}
