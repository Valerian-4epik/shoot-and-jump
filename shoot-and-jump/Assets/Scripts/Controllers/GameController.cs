using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Gun _gun;
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
        Vector3 lightPosition = new Vector3(10, -152, -5);
        Vector3 gunPosition = new Vector3(90, 180, 0);
        _light.transform.rotation = Quaternion.Euler(lightPosition);
        _gun.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        _gun.transform.rotation = Quaternion.Euler(gunPosition);
        _stickman.DisablePhysical();
    }
}
