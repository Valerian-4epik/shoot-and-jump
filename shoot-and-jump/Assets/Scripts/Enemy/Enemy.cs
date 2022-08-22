using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private List<Rigidbody> _ragdoll;
    [SerializeField] private SkinnedMeshRenderer _skin;
    [SerializeField] private Material _deadMaterial;

    private void Start()
    {
        foreach(var rigidbody in _ragdoll)
        {
            rigidbody.isKinematic = true;
        }
    }

    public void Die()
    {
        _skin.material = _deadMaterial;

        foreach(var rigidbody in _ragdoll)
        {
            rigidbody.isKinematic = false;
        }
    }
}
