using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Enemy : MonoBehaviour, IDamageable
{
    public UnityEvent<float> DamageTaken;
    public UnityEvent NoHealthRemaining;

    protected Rigidbody2D _rigidBody;

    public abstract void Damage(float damage);
    public float CurrentHP { get; set; }
    [field: SerializeField] public float MaxHP { get; private set; }

    private void Awake()
    {
        CurrentHP = MaxHP;
        _rigidBody = GetComponent<Rigidbody2D>();
    }
}
