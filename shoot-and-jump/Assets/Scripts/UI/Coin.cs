using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    [SerializeField] private Rigidbody _coin;
    [SerializeField] private float _force;
    [SerializeField] private Transform _target;

    private Transform _player;

    private void Start()
    {
        Move();
        Rotation();
    }

    private void Move()
    {
        Vector3 direction = _target.position - _coin.position;
        _coin.AddForce(Vector3.up * _force);
        _coin.AddForce(direction * _force);
        StartCoroutine(MoveToPLayer());
    }

    private void Rotation()
    {
        float forceRotate = 1000f;
        _coin.AddTorque(0, 0, forceRotate);
    }

    public void SetTarget(Transform target)
    {
        _player = target;
    }

    IEnumerator MoveToPLayer()
    {
        float delay = 0.2f;
        yield return new WaitForSeconds(2);
        transform.DOMove(_player.transform.position, delay);

        yield return new WaitForSeconds(0.4f);
        gameObject.SetActive(false);
    }
}
