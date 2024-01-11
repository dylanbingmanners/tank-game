using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DecelerateProjectileComponent : ProjectileComponent
{
    public int DecelerationDelay;
    public float DecelerationAmount;
    public float MinimumSpeed;
    public UnityEvent<GameObject> MinimumSpeedReached;

    private int _currentDelay;

    private void Start()
    {
        _currentDelay = 0;
    }

    private void FixedUpdate()
    {
        _currentDelay++;
        if(_currentDelay >= DecelerationDelay)
        {
            float newmag = Projectile.RigidBody.velocity.magnitude - DecelerationAmount;
            if (newmag <= MinimumSpeed)
            {
                Projectile.RigidBody.velocity *= MinimumSpeed / Projectile.RigidBody.velocity.magnitude;
                MinimumSpeedReached.Invoke(Projectile.Owner);
                enabled = false;
            }
            else
            {
                Projectile.RigidBody.velocity *= newmag / Projectile.RigidBody.velocity.magnitude;
            }

        }
    }
}
