using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovementProjectileComponent : ProjectileComponent
{
    private void Start()
    {
        Vector2 ownerpos = new Vector2(Projectile.Owner.transform.position.x, Projectile.Owner.transform.position.y);
        Projectile.RigidBody.velocity = (Projectile.Target - ownerpos).normalized * Projectile.Speed;
    }
}
