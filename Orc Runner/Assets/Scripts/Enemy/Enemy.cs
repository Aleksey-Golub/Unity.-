using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private ParticleSystem _puffEffect;
    [SerializeField] private int _health;
    [SerializeField] private int _damageFromPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {

            player.ApplyDamage(_damage);

            var puff = Instantiate(_puffEffect, transform.position, Quaternion.identity);
            puff.Play();

            ApplyDamage(_damageFromPlayer);
        }
        else if(collision.TryGetComponent<Destroyer>(out Destroyer destroyer))
            Die();
    }

    private void ApplyDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
