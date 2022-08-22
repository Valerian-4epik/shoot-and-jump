using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileBullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _impactEffect;

    private Rigidbody _rigidbody;
    private Vector3 _direction;

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 position = collision.contacts[0].point;
        Quaternion rotation = Quaternion.LookRotation(collision.contacts[0].normal);
        Instantiate(_impactEffect, position, rotation);

        if (collision.gameObject.GetComponent<Ground>())
        {
            Debug.Log(collision.gameObject.name);
            Destroy(gameObject);         
        }
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Fly(); 
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }

    public void Fly()
    {
       _rigidbody.velocity = -_direction * _speed * Time.deltaTime;
    }

    public void Destroy()
    {
        Destroy(gameObject, 3f);
    }
}
