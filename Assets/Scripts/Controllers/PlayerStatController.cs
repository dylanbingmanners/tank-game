using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatController : MonoBehaviour
{
    public BasePlayerStatsScriptableObject stats;

    public float GetSpeed()
    {
        return stats.BaseSpeed;
    }

    public float GetAcceleration()
    {
        return stats.BaseAcceleration;
    }

    public float GetDeceleration()
    {
        return stats.BaseDeceleration;
    }

    public float GetMaxHealth()
    {
        return stats.BaseMaxHealth;
    }
}
