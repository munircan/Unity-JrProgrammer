using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour
{
    //[SerializeField] private AnimationCurve _animationCurve;
    [SerializeField] private MeshRenderer Renderer;
    [SerializeField] private float current,target;
    [SerializeField] private Vector3 goalPosition;
    void Start()
    {
        InvokeRepeating("ChangeColor",0.0f,1.0f);
        InvokeRepeating("ScaleChange", 1.0f, 2.0f);
    }
    
    void Update()
    {
        // Rotate the cube
        RotateCube();
        // Move the cube
        MoveCube();
    }

    private void ChangeColor()
    {
        Renderer.material.color = new Color(Random.Range(0f,1f), Random.Range(0f,1f),  Random.Range(0f,1f), 1.0f);
    }
    private void MoveCube()
    {
        if (Input.GetMouseButtonDown(0)) target = target == 0 ? 1 : 0;
        current = Mathf.MoveTowards(current,target, 0.5f*Time.deltaTime);
        transform.position = Vector3.Lerp(Vector3.zero, goalPosition,current);
    }
    
    private void ScaleChange()
    {
        transform.localScale = new Vector3(Random.Range(1f,10f) ,Random.Range(1f,10f) ,Random.Range(1f,10f) );
    }

    private void RotateCube()
    {
        transform.Rotate(Random.Range(1f,60f) * Time.deltaTime, Random.Range(1f,60f) * Time.deltaTime, Random.Range(1f,60f) * Time.deltaTime);
    }
}
