using UnityEngine;

public class ShootDirection : MonoBehaviour
{
    private Vector3 _direction;
    private float _range = 10;
    private bool _canBeSlowed;

    public Vector3 Direction => _direction;
    public bool CanBeSlowed => _canBeSlowed;

    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);  
        Debug.DrawRay(transform.position, transform.forward * _range, Color.red);
        _direction = ray.direction;

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, _range))
        {
            if (hit.collider.gameObject.GetComponent<EnemyParth>() || hit.collider.gameObject.GetComponent<TargetBox>())
            {
                _canBeSlowed = true;
            }
            else
                _canBeSlowed = false;
        }
    }
}
