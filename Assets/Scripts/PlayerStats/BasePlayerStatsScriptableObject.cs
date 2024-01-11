using UnityEngine;

[CreateAssetMenu(menuName = "Create Base Player Stats")]
public class BasePlayerStatsScriptableObject : ScriptableObject
{
    public float BaseMaxHealth;
    public float BaseAcceleration;
    public float BaseDeceleration;
    public float BaseSpeed;
}