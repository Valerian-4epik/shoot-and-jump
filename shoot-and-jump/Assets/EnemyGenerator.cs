using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameObject _enemy;

    void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        Instantiate(_enemy, _spawnPoint.position, Quaternion.identity) ;
    }
}
