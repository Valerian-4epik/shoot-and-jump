using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private List<Rigidbody> _ragdoll;
    [SerializeField] private SkinnedMeshRenderer _skin;
    [SerializeField] private Material _deadMaterial;

    public UnityAction EnemyDiedEvent;

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
        EnemyDiedEvent.Invoke();

        gameObject.GetComponent<Animator>().enabled = false;

        foreach(var rigidbody in _ragdoll)
        {
            rigidbody.isKinematic = false;
        }
    }
}
