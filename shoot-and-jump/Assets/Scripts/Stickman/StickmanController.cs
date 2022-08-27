using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StickmanController : MonoBehaviour
{
    [SerializeField] private GameObject _followingPoint;
    [SerializeField] private Transform _body;

    void Update()
    {
        _body.DOMove(_followingPoint.transform.position, 0.05f);
    }
}
