using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Skin[] _skins;

    private bool isDied = false;
    private Animator _animator;

    public bool IsDied => isDied;

    public event UnityAction<int> HealthChanged;
    public event UnityAction Died;

    private void Start()
    {
        HealthChanged?.Invoke(_health);
        _skins[GameManager.Instance.ActiveSkinIndex].ShowSkin();
        _animator = _skins[GameManager.Instance.ActiveSkinIndex].GetComponent<Animator>();
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);

        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _animator.updateMode = AnimatorUpdateMode.UnscaledTime;
        _animator.SetTrigger("IsDead");
        isDied = true;
        Died?.Invoke();
    }
}
