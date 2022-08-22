using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParth : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<ProjectileBullet>())
        {
            _enemy.Die();
        }
    }
}
