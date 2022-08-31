using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Gun _gun;
    [SerializeField] private GameObject _followPoint;
    [SerializeField] private GameObject _finishStickmanPosition;
    [SerializeField] private RagdollAnimator _stickman;
    [SerializeField] private GameObject _light;

    private void OnEnable()
    {
        _gun.LastBulletShoot += EnebleAnimator;
    }

    private void OnDisable()
    {
        _gun.LastBulletShoot -= EnebleAnimator;
    }

    public void EnebleAnimator()
    {
        _light.transform.rotation = Quaternion.Euler(10, -152, -5);
        _followPoint.transform.position = _finishStickmanPosition.transform.position;
        _gun.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        _gun.transform.rotation = Quaternion.Euler(90, 180, 0);
        _stickman.DisablePhysical();
        _stickman.transform.rotation = Quaternion.Euler(0,90,0);
    }
}
