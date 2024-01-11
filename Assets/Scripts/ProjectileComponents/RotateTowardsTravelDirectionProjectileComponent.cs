using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsTravelDirectionProjectileComponent : ProjectileComponent
{
    public float Offset;

    private void Update()
    {
        float angle = Mathf.Atan2(Projectile.RigidBody.velocity.x, Projectile.RigidBody.velocity.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + Offset, Vector3.back);
    }
}
