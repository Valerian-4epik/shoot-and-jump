using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootDirection : MonoBehaviour
{
    private Vector3 _direction;
    private float _range = 100;

    public Vector3 Direction => _direction;

    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);  
        Debug.DrawRay(transform.position, -transform.forward*10, Color.red);
        _direction = ray.direction;

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, _range))
        {     
            //Debug.Log(hit.transform.name);
        }
    }
}
