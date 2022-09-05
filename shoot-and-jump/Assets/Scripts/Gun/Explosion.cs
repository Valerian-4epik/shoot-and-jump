using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private GameObject _explosionPoint;
    [SerializeField][Range(0,1000)] private float _forceExplosion;
    [SerializeField][Range(0,1000)] private float _pushForce;
    [SerializeField] private float _upwardsModifier;
    [SerializeField] private List<Rigidbody> _stickmanBody;

    private Vector3 Direction()
    {
        Vector3 reverseDirection = transform.position - _explosionPoint.transform.position;
        return reverseDirection;
    }

    public void Explode()
    {
        gameObject.GetComponent<Rigidbody>().AddExplosionForce(_forceExplosion, _explosionPoint.transform.position, 2, 
            _upwardsModifier, ForceMode.VelocityChange);
        gameObject.GetComponent<Rigidbody>().AddForce(Direction() * _pushForce, ForceMode.Impulse);
    }
}
