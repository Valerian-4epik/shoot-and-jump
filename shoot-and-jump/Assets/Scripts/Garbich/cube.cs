using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
            Debug.Log("��� �� ����� !");
        GetComponent<Transform>().localScale = new Vector3(2,2,2);
    }
}
