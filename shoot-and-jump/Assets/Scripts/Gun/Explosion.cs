using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private Rigidbody _gun;
    [SerializeField] private float _force;
    [SerializeField] private float _radius;

    public void Explode()
    {
        _gun.AddExplosionForce(_force, transform.position, _radius);
    }
}
