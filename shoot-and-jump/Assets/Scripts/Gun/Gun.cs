using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private ProjectileBullet _bullet;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private ShootDirection _direction;
    [SerializeField] private GameObject[] _effects;   

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           Shoot();
        }
    }

    private void PlayOnEffect(GameObject[] effects)
    {
        for(int i = 0; i < effects.Length; i++)
        {
            effects[i].GetComponent<ParticleSystem>().Play();
        }
    }

    public void Shoot()
    {
        PlayOnEffect(_effects);
        ProjectileBullet bullet = Instantiate(_bullet, _shootPoint.position, Quaternion.LookRotation(_direction.Direction));
        bullet.SetDirection(_direction.Direction);
        bullet.Destroy();
    }

}
 