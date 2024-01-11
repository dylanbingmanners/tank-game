using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : Enemy
{
    public override void Damage(float damage)
    {
        CurrentHP -= damage;
        DamageTaken.Invoke(damage);
        if(CurrentHP <= 0)
        {
            NoHealthRemaining.Invoke();
        }
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
