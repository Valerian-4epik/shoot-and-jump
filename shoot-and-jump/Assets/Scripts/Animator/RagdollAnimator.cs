using UnityEngine;

public class RagdollAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody[] _allRigidbody;
  
    void Awake()
    {
        for(int i = 0; i < _allRigidbody.Length; i++)
        {
            _allRigidbody[i].isKinematic = true;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            MakePhysical();
        }
    }

    private void MakePhysical()
    {
        _animator.enabled = false;

        for(int i = 0; i < _allRigidbody.Length; i++)
        {
            _allRigidbody[i].isKinematic = false;
        }
    }
}
