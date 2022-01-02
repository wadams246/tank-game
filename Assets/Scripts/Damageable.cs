using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    public int MaxHealth = 100;
    [SerializeField]
    private int health;

    public int Health
    {
        get { return health; }
        set
        {
            health = value;
            OnHealthChange?.Invoke((float)Health / MaxHealth);
        }
    }

    public UnityEvent OnDead, OnHit, OnHeal;
    public UnityEvent<float> OnHealthChange;

    private void Start()
    {
        Health = MaxHealth;
    }

    internal void Hit(int damagePoints)
    {
        Health -= damagePoints;
        if (Health <= 0)
        {
            OnDead?.Invoke();
        }
        else
        {
            OnHit?.Invoke();
        }
    }

    public void Heal(int healthBoost)
    {
        Health += healthBoost;
        Health = Mathf.Clamp(Health, 0, MaxHealth);
        OnHeal?.Invoke();
    }
}
