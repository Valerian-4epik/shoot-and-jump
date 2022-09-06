using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Gun _gun;

    private int _coinNumber = 5;
    private List<GameObject> _coins = new List<GameObject>();

    private void OnEnable()
    {
        _enemy.EnemyDiedEvent += Create;
    }

    private void OnDisable()
    {
         _enemy.EnemyDiedEvent -= Create;
    }
        
    private void Create()
    {
        float stepAngle = 20;
        float angleRotation = -50;

        for(int i = 0; i < _coinNumber; i++)
        {
           GameObject coin = Instantiate(_coin.gameObject, _enemy.gameObject.transform.position, Quaternion.identity);
            coin.GetComponent<Coin>().SetTarget(_gun.gameObject.transform);
           _coins.Add(coin);
        }

        foreach(GameObject coin in _coins)
        {
            coin.transform.rotation = Quaternion.Euler(angleRotation, 0,0);
            angleRotation += stepAngle;            
        }
    }
}
