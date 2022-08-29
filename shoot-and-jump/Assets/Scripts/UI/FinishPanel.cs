using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinishPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _bonusText;
    [SerializeField] private Image _image;
    [SerializeField] private CameraController _camera;
    [SerializeField] private GameObject _wayPanel;
    [SerializeField] private TMP_Text _coinPanel;
    [SerializeField] private TMP_Text _score;

    private int _maxScore = 150;
    private int _step = 10;

    private void Start()
    {
        StartCoroutine(ChangeAmount(_maxScore));
    }

    public void ShowResults(Color color, string bonus)
    {
        _camera.SwitchOffCamera();
        _image.color = color;
        _bonusText.text = bonus;
        _wayPanel.SetActive(false);
    }

    private IEnumerator ChangeAmount(int _maxPoints)
    {
        yield return new WaitForSeconds(1.5f);

        for(int i = 0; i <= _maxPoints; i += _step)
        {
            _score.text = i.ToString();
            yield return new WaitForSeconds(0.09f);
        }

        _coinPanel.text = _score.text;
    }
}
