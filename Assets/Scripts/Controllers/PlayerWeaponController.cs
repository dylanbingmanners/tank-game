using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerWeaponController : MonoBehaviour
{
    public Weapon PrimaryWeapon;
    public Weapon SecondaryWeapon;

    public void FirePrimaryDown()
    {
        PrimaryWeapon.FireWeaponDown();
    }

    public void FirePrimaryUp()
    {
        PrimaryWeapon.FireWeaponUp();
    }

    public void FirePrimaryHold()
    {
        PrimaryWeapon.FireWeaponHold();
    }

    public void FireSecondaryDown()
    {
        SecondaryWeapon.FireWeaponDown();
    }

    public void FireSecondaryUp()
    {
        SecondaryWeapon.FireWeaponUp();
    }

    public void FireSecondaryHold()
    {
        SecondaryWeapon.FireWeaponHold();
    }
}
