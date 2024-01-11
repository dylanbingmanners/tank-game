using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    public UnityEvent<GameObject> RangeReached;
    public UnityEvent<GameObject> LifetimeReached;
    public UnityEvent<GameObject> ObjectCollision;
    public UnityEvent<GameObject, GameObject> EnemyCollision;

    [SerializeField] private float _baseSpeed;
    [SerializeField] private float _speedRandomness;
    [SerializeField] private float _baseRange;
    [SerializeField] private float _rangeRandomness;
    [SerializeField] private float _baseDamage;
    [SerializeField] private float _damageRandomness;
    [SerializeField] private int _baseLifetime;
    [SerializeField] private int _lifetimeRandomness;

    [System.NonSerialized] public GameObject Owner;
    [System.NonSerialized] public Rigidbody2D RigidBody;
    [System.NonSerialized] public Vector2 Target;

    private Vector2 _origin;
    private float _currentRange;
    private int _currentLifetime;

    public float Speed
    {
        get { return _baseSpeed + Random.Range(-_speedRandomness, _speedRandomness); }
    }

    public float Range
    {
        get{ return _baseRange + Random.Range(-_rangeRandomness, _rangeRandomness); }
    }

    public float Damage
    {
        get { return _baseDamage + Random.Range(-_damageRandomness, _damageRandomness); }
    }

    public int Lifetime
    {
        get { return _baseLifetime + Random.Range(-_lifetimeRandomness, _lifetimeRandomness); }
    }

    private void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();

        _origin = Owner.transform.position;
        _currentRange = 0f;
        _currentLifetime = 0;
    }

    private void FixedUpdate()
    {
        _currentRange = Vector2.Distance(transform.position, _origin);
        if(_currentRange >= Range && Range != 0)
        {
            if(RangeReached.GetPersistentEventCount() > 0)
            {
                RangeReached.Invoke(Owner);
            }
            else
            {
                RangeReachedDefault();
            }
        }

        _currentLifetime++;
        if(_currentLifetime > Lifetime && Lifetime != 0)
        {
            if(LifetimeReached.GetPersistentEventCount() > 0)
            {
                LifetimeReached.Invoke(Owner);
            }
            else
            {
                LifetimeReachedDefault();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Enemy>() != null)
        {
            if(EnemyCollision.GetPersistentEventCount() > 0)
            {
                EnemyCollision.Invoke(Owner, collision.gameObject);
            }
            else
            {
                EnemyCollisionDefault();
            }

        }
        // TODO Object collision
        /*if(collision.gameObject.GetComponent<Enemy>() != null)
        {

        }*/
    }

    private void RangeReachedDefault()
    {
        Destroy(gameObject);
    }

    private void LifetimeReachedDefault()
    {
        Destroy(gameObject);
    }

    private void EnemyCollisionDefault()
    {
        Destroy(gameObject);
    }
}
