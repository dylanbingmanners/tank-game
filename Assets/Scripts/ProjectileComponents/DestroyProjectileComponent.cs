using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectileComponent : ProjectileComponent
{
    public void DestroyProjectile(GameObject owner)
    {
        Destroy(gameObject);
    }

    public void DestroyProjectile(GameObject owner, GameObject target)
    {
        Destroy(gameObject);
    }
}
