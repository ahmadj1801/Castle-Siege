﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateKey : MonoBehaviour
{
	
	public float turnSpeed = 50f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
    }
}
