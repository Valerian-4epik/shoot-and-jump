using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private GameObject _explosionPoint;
    [SerializeField] private Transform _endPoint;
    [SerializeField][Range(0,1000)] private float _forceExplosion;
    [SerializeField][Range(0,1000)] private float _pushForce;
    [SerializeField] private float _upwardsModifier;
    [SerializeField] private List<Rigidbody> _stickmanBody;

    private float _radius = 2;

    public void Explode()
    {
        gameObject.GetComponent<Rigidbody>().AddExplosionForce(_forceExplosion, _explosionPoint.transform.position, _radius, 
            _upwardsModifier, ForceMode.VelocityChange);
        gameObject.GetComponent<Rigidbody>().AddForce(Direction() * _pushForce, ForceMode.Impulse);
    }

    private Vector3 Direction()
    {
        Vector3 reverseDirection = _explosionPoint.transform.position - _endPoint.transform.position;
        return reverseDirection;
    }
}
