using UnityEngine;

public class RagdollAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody[] _allRigidbody;
  
    public void DisablePhysical()
    {
        _animator.enabled = true;

        for(int i = 0; i < _allRigidbody.Length; i++)
        {
            _allRigidbody[i].isKinematic = true;
        }
    }
}
