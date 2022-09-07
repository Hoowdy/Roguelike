using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int _currentHealth;
    [SerializeField] private int _protection;
    [SerializeField] private int _shield;
    [Range(0, 180)][SerializeField] private float _shieldAngle; 
    [SerializeField] private int healCount;
    private int _maxHealth = 10;

    private Vector2 _attackDirection;
    private Vector2 _enemyDirection;

    private void Update()
    {
        _attackDirection = PlayerAttack.attackDir;
        _enemyDirection = PlayerAttack.enemyDir;

        if (Input.GetButtonDown("H"))
        {
            HealPlayer(healCount);
        }
    }

    public void HurtPlayer(int damage)
    {
        if (Input.GetMouseButton(1) || Vector3.Angle(_attackDirection, _enemyDirection) <= _shieldAngle)
        {
            _currentHealth -= Mathf.Clamp((damage - _shield) * (100 / (100 + _protection)), 0, _currentHealth);
        } else
        {
            _currentHealth -= Mathf.Clamp(damage * (100 / (100 + _protection)), 0, _currentHealth);
        }

        if (_currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void HealPlayer(int healCount)
    {
        _currentHealth += Mathf.Clamp(healCount, 0, _maxHealth - _currentHealth);
    }
}
