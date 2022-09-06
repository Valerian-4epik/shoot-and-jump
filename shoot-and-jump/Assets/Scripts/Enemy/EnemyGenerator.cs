using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private Enemy _Enemy;

    private void Start()
    {
        _Enemy.gameObject.SetActive(true);
    }
}
