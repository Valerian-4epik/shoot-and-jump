using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Explosion))]
public class Gun : MonoBehaviour
{
    [SerializeField] private ProjectileBullet _bullet;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private ShootDirection _direction;
    [SerializeField] private GameObject[] _effects;
    [SerializeField] private ParticleSystem _confitti;

    private Explosion _force;
    private TrailRenderer _trail;

    public UnityAction LastBulletShoot;

    private void Start()
    {
       _force = gameObject.GetComponent<Explosion>();
       _trail = gameObject.GetComponentInChildren<TrailRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           Shoot();
        }
    }

    private void PlayOnEffects(GameObject[] effects)
    {
        for(int i = 0; i < effects.Length; i++)
        {
            effects[i].GetComponent<ParticleSystem>().Play();
        }
    }

    private IEnumerator ShootConfitti()
    {
        yield return new WaitForSeconds(3f);
        _confitti.Play();
    }

    private IEnumerator PlayTrail(float time)
    {
        _trail.enabled = true;
        yield return new WaitForSeconds(time);
        _trail.enabled = false;
    }

    public void Shoot()
    {
        if (_direction.CanBeSlowed)
            Time.timeScale = 0.5f;

        PlayOnEffects(_effects);
        ProjectileBullet bullet = Instantiate(_bullet, _shootPoint.position, Quaternion.LookRotation(_direction.Direction));
        bullet.Init(this, _direction.Direction);
        _force.Explode();
        bullet.Destroy();

        if (_trail.enabled)
        {
            StopCoroutine(PlayTrail(_trail.time));
            StartCoroutine(PlayTrail(_trail.time));
        }
        else
            StartCoroutine(PlayTrail(_trail.time));
    }

    public void ShootCinfitti()
    {
        StartCoroutine(ShootConfitti());
    }

}
 