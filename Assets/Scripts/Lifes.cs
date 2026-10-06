using UnityEngine;
using System;
public class Lifes : MonoBehaviour
{
    [SerializeField] private int maxLife = 6;
    public int currLife { get; private set; }
    public bool Dead => currLife <= 0;
    public event Action<int> onChangeQuantLife;
    public event Action OnDamage;
    public event Action OnDead;

    void Awake()
    {
        currLife = maxLife;
    }
    void Start(){ 
        onChangeQuantLife?.Invoke(currLife);
    }
    public void TakeDamage(int hit = 1)
    {
        if (Dead) return;
        currLife = Mathf.Max(0, currLife - hit);
        onChangeQuantLife?.Invoke(currLife);
        if (currLife == 0) OnDead?.Invoke();
    }
}