using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private GameObject _explosionPoint;
    [SerializeField] private float _forceExplosion;
    [SerializeField] private float _pushForce;
    [SerializeField] private float _radius;
    [SerializeField] private float _upwardsModifier;

    private void Explode()
    {
        gameObject.GetComponent<Rigidbody>().AddExplosionForce(_forceExplosion, _explosionPoint.transform.position, _radius, 
            _upwardsModifier, ForceMode.Impulse);
        gameObject.GetComponent<Rigidbody>().AddForce(Direction() * _pushForce, ForceMode.Impulse);
    }

    private Vector3 Direction()
    {
        Vector3 reverseDirection = _explosionPoint.transform.position - transform.position;
        return reverseDirection;
    }
}
