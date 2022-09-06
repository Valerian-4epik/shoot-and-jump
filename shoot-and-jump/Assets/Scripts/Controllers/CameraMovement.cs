using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _smooth;
    [SerializeField] private Vector3 _offset;

    private void Start()
    {
        Time.timeScale = 0.9f;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _target.position + _offset, Time.deltaTime * _smooth);
    }

    public void AddNewTarget(Transform newTarget)
    {
        _target = newTarget;
    }
}
