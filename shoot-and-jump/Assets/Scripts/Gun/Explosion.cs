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
    [SerializeField] private List<Rigidbody> _stickmanBody;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.clear;
        Gizmos.DrawSphere(_explosionPoint.transform.position, _radius);
    }

    private Vector3 Direction()
    {
        Vector3 reverseDirection = transform.position - _explosionPoint.transform.position;
        return reverseDirection;
    }

    public void Explode()
    {
        gameObject.GetComponent<Rigidbody>().AddExplosionForce(_forceExplosion, _explosionPoint.transform.position, _radius, 
            _upwardsModifier, ForceMode.Impulse);
        gameObject.GetComponent<Rigidbody>().AddForce(Direction() * _pushForce, ForceMode.Impulse);

        foreach(Rigidbody parthOfBody in _stickmanBody)
        {
            parthOfBody.AddExplosionForce(-_forceExplosion * 80, _explosionPoint.transform.position, _radius);
        }
      
    }

}
