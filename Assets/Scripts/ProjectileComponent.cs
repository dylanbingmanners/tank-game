using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Projectile))]
public abstract class ProjectileComponent : MonoBehaviour
{
    protected Projectile Projectile;

    protected virtual void Awake()
    {
        Projectile = GetComponent<Projectile>();
    }
}
