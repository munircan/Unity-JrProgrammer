using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   [SerializeField] private GameObject player;
   [SerializeField] private Vector3 offset;

   private void LateUpdate()
   {
      transform.position = player.transform.position + offset;
   }
}
