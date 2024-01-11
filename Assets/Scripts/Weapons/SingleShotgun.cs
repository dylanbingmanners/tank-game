using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShotgun : Weapon
{
    public int Cooldown;
    public int Pellets;
    public float SpreadRandomness;
    public bool FirstShotAlwaysAccurate;

    private int _currentCooldown = 0;

    public override void FireWeaponDown()
    {
        if (_currentCooldown == 0)
        {
            for(int i = 0; i < Pellets; i++)
            {
                Projectile shot = Instantiate(GetProjectile());
                shot.Owner = gameObject;
                shot.transform.position = shot.Owner.transform.position;

                float offset;
                if (i == 0 && FirstShotAlwaysAccurate)
                {
                    offset = 0f;
                }
                else
                {
                    offset = Random.Range(-SpreadRandomness, SpreadRandomness);
                }

                Vector3 shottarget = CameraController.Instance.Camera.ScreenToWorldPoint(Input.mousePosition);
                shot.Target = Quaternion.AngleAxis(offset, Vector3.forward)
                    * (shottarget - shot.Owner.transform.position)
                    + shot.Owner.transform.position;
            }

            _currentCooldown = Cooldown;
        }
    }

    public override void FireWeaponUp() { }

    public override void FireWeaponHold() { }

    private void FixedUpdate()
    {
        if (_currentCooldown > 0)
        {
            _currentCooldown--;
        }
    }
}