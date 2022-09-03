using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _roadPrefab;
    [SerializeField] private GameObject _finish;
    [SerializeField] private int _roadLength;
    [SerializeField] private FinishPanel _finishPanel;

    private List<GameObject> _road = new List<GameObject>();
    private Vector3 _finishRotation = new Vector3(0,180,0);

    private void Start()
    {
        CreateRoad();
    }

    private void CreateRoad()
    {
        Vector3 position = Vector3.zero;
        Vector3 width = new Vector3(0, 0, 6);
        Vector3 finishWidth = new Vector3(0, 0, 9);

        for (int i = 0; i < _roadLength; i++)
        {
            if (_road.Count > 0) { position = _road[_road.Count - 1].transform.position + width; }

            //тут магическое число, нужно будет смещать на ширину.(ширина _roadPrefab)
            GameObject road = Instantiate(_roadPrefab, position, Quaternion.identity);
            road.transform.SetParent(transform);
            _road.Add(road);
        }

        GameObject finish = Instantiate(_finish, position + finishWidth, Quaternion.Euler(_finishRotation), transform);
        finish.GetComponentInChildren<DartsManager>().Panel(_finishPanel);
    }
}
