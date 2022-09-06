using DG.Tweening;
using UnityEngine;

public class RagdollAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody[] _allRigidbody;
    [SerializeField] private Transform _stickmanFinishPosition;
    [SerializeField] private Transform _pelvis;
  
    public void DisablePhysical()
    {
        float duration = 0.05f;

        _pelvis.DOMove(_stickmanFinishPosition.position, duration);
        gameObject.transform.DORotate(Vector3.zero, duration);

        _animator.enabled = true;

        for(int i = 0; i < _allRigidbody.Length; i++)
        {
            _allRigidbody[i].isKinematic = true;
        }
    }
}
