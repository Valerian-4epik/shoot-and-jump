using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Explosion))]
public class Gun : MonoBehaviour
{
    [SerializeField] private ProjectileBullet _bullet;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private ShootDirection _direction;
    [SerializeField] private GameObject[] _effects;

    private Explosion _force;

    private void Start()
    {
       _force = gameObject.GetComponent<Explosion>();  
    }

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
        //if (_direction.CanBeSlowed)
        //    Time.timeScale = 0.6f;
        PlayOnEffect(_effects);
        ProjectileBullet bullet = Instantiate(_bullet, _shootPoint.position, Quaternion.LookRotation(_direction.Direction));
        bullet.SetDirection(-_direction.Direction);
        _force.Explode();
        bullet.Destroy();
    }

}
 