using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StickmanController : MonoBehaviour
{
    [SerializeField] private GameObject _followingPoint;
    [SerializeField] private Transform _body;
    [SerializeField] private Rigidbody _rigidbody;

    void Update()
    {
        //_rigidbody.DOMove(_followingPoint.transform.position, 0.005f);
        _body.DOMove(_followingPoint.transform.position, 0.05f);
    }
}
