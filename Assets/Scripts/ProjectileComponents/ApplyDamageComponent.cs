using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ApplyDamageComponent : ProjectileComponent
{
    public void ApplyDamage(GameObject owner, GameObject target)
    {
        IDamageable targetComponent = target.GetComponent<IDamageable>();
        targetComponent.Damage(Projectile.Damage);
    }
}
