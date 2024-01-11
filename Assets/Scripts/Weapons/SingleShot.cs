using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShot : Weapon
{
    public int Cooldown;

    private int _currentCooldown = 0;
    public override void FireWeaponDown()
    {
        if(_currentCooldown == 0)
        {
            Projectile shot = Instantiate(GetProjectile());
            shot.Owner = gameObject;
            shot.transform.position = shot.Owner.transform.position;

            Vector3 shottarget = CameraController.Instance.Camera.ScreenToWorldPoint(Input.mousePosition);
            shot.Target = Quaternion.AngleAxis(AccuracyAngleOffset, Vector3.forward)
                * (shottarget - shot.Owner.transform.position)
                + shot.Owner.transform.position;

            _currentCooldown = Cooldown;
        }
    }

    public override void FireWeaponUp() { }

    public override void FireWeaponHold() { }

    private void FixedUpdate()
    {
        if(_currentCooldown > 0)
        {
            _currentCooldown--;
        }
    }
}
