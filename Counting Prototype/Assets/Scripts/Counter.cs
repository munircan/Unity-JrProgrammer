using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [FormerlySerializedAs("CounterText")] [SerializeField]
    private Text counterText;

    private int _count = 0;
    [SerializeField] private int point;
    [SerializeField] private GameObject spherePrefab;

    private void Start()
    {
        _count = 0;
        StartCoroutine(SphereMaker());
    }

    private void OnTriggerEnter(Collider other)
    {
        _count += point;
        counterText.text = "Count : " + _count;
    }

    private int GetCount()
    {
        return _count;
    }
    private IEnumerator SphereMaker()
    {
        while (GetCount() < 100)
        {
            yield return new WaitForSeconds(5);
            Instantiate(spherePrefab);
        }
        
    }
}