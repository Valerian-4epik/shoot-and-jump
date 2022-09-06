using System.Collections;
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
    private float _slowedTime = 0.4f;

    public UnityAction LastBulletShoot;

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

    public void Shoot()
    {
        if (_direction.CanBeSlowed)
            Time.timeScale = _slowedTime;
        else
            Time.timeScale = 1.0f;

        PlayOnEffects(_effects);
        ProjectileBullet bullet = Instantiate(_bullet, _shootPoint.position, Quaternion.LookRotation(_direction.Direction));
        bullet.Init(this, _direction.Direction);
        _force.Explode();
        bullet.Destroy();
    }

    public void ShootCinfitti()
    {
        StartCoroutine(ShootConfitti());
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
}
 