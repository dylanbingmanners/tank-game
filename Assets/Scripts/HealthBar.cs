using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject _damageableGameObject;
    [SerializeField] private Image _healthBarImage;
    private IDamageable _damageable;
    private void OnValidate()
    {
        if(_damageableGameObject != null)
        {
            if (_damageableGameObject.GetComponent<IDamageable>() == null)
            {
                Debug.LogException(new Exception("Game object '" + _damageableGameObject.name + "' does not implement interface IDamageable"));
            }
        }
    }

    private void Awake()
    {
        _damageable = _damageableGameObject.GetComponent<IDamageable>();
    }

    public void UpdateBar()
    {
        _healthBarImage.fillAmount = _damageable.CurrentHP / _damageable.MaxHP;
    }
}
