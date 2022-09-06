using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject _camera1;

    public void SwitchOffCamera()
    {
        _camera1.SetActive(false);
    }
}
