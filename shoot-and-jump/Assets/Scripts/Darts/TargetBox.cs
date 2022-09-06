using UnityEngine;
using RayFire;
using UnityEngine.UI;
using TMPro;

public class TargetBox : MonoBehaviour
{
    [SerializeField] private RayfireRigidRoot _root;
    [SerializeField] private RayfireBomb _bomb;
        
    private DartsManager _darts;
    private Color _color;
    private string _bonusName;

    private void Start()
    {
        _darts = GetComponentInParent<DartsManager>();
        _color = GetComponent<Image>().color;
        _bonusName = GetComponentInChildren<TMP_Text>().text;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ProjectileBullet>())
        {
            _root.Initialize();
            _bomb.Explode(0);
            _darts.SetValue(_color, _bonusName);
            gameObject.SetActive(false);
        }
    }
}
