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

    public void ShowResults(Color color, string bonus)
    {
        _camera.SwitchOffCamera();
        _image.color = color;
        _bonusText.text = bonus;
        _wayPanel.SetActive(false);
    }

}
