using UnityEngine;

public class Healing : MonoBehaviour
{
    [SerializeField] private float _heal;
    [SerializeField] private Health _health; 

    public void HealHp()
    {
        _health.RecoverHealth(_heal); 
    }
}
