using UnityEngine;

public class ProjectileBullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _impactEffect;
    [SerializeField] private ParticleSystem _muzzleEffect;

    private Vector3 _direction;
    private Gun _gun;
    private Vector3 _offset = new Vector3(0, 0.001f, 0);
    private float _delayedDeath = 4f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Ground>())
        {
            Vector3 position = collision.contacts[0].point;
            Quaternion rotation = Quaternion.Euler(90, 0, 0);
            
            Instantiate(_impactEffect, position + _offset, rotation);
        }

        Time.timeScale = 1.0f;
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<TargetBox>())
        {
            _gun.LastBulletShoot?.Invoke();
            _gun.ShootCinfitti();
        }
    }

    private void Start()
    {
        _muzzleEffect.Play();
    }

    private void Update()
    {
        Fly(); 
    }

    public void Destroy()
    {
        Destroy(gameObject, _delayedDeath);
    }

    public void Init(Gun gun, Vector3 direction)
    {
        _gun = gun;
        _direction = direction;
    }

    private void Fly()
    {
       gameObject.GetComponent<Rigidbody>().velocity = _direction * _speed * Time.deltaTime;
    }
}
