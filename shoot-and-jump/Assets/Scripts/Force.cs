using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Force : MonoBehaviour
{
    [SerializeField] private Vector3 _angularForce;
    [SerializeField] private float _force;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Transform _endPoint;

    private Rigidbody _rigidbody;

    private void Start()
    {
      _rigidbody = GetComponent<Rigidbody>();  
    }
    //rigidbody.addtorque
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(_rigidbody.angularVelocity.x > 0)
              _rigidbody.angularVelocity = Vector3.right + _angularForce;
            else
                _rigidbody.angularVelocity = Vector3.left -_angularForce;

            _rigidbody.velocity += Direction();
        }
    }

    private Vector3 Direction()
    {
        var dir = _endPoint.position - _shootPoint.position;

        if (dir.z > 0)
            dir.z = 0;

        Vector3 direction = new Vector3(dir.x, dir.y, dir.z);
        return -direction * _force;
    }
}
