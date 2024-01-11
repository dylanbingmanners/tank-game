using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private List<Projectile> _projectiles;
    [SerializeField] private List<float> _distribution;
    [SerializeField] private float _accuracyRandomness;

    public abstract void FireWeaponDown();
    public abstract void FireWeaponUp();
    public abstract void FireWeaponHold();

    public float AccuracyAngleOffset
    {
        get
        {
            return UnityEngine.Random.Range(-_accuracyRandomness, _accuracyRandomness);
        }
    }

    private void OnValidate()
    {
        if(_projectiles.Count() != _distribution.Count())
        {
            Debug.LogException(new Exception("Game object '" + gameObject.name + "' weapon projectile and distribution list are not the same length"));
        }
        if(_distribution.Sum() != 1.0)
        {
            Debug.LogException(new Exception("Game object '" + gameObject.name + "' weapon projectile distribution does not total 1.0"));
        }
    }

    protected Projectile GetProjectile()
    {
        float chosen = UnityEngine.Random.Range(0f, 1f);
        float total = 0f;
        for(int i = 0; i < _distribution.Count; i++)
        {
            total += _distribution[i];
            if(chosen <= total)
            {
                return _projectiles[i];
            }
        }
        return _projectiles.Last();
    }

    protected Projectile GetProjectile(int i)
    {
        return _projectiles[i];
    }
}
