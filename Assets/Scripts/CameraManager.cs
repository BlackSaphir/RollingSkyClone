﻿using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = new Vector3Self(0, this.transform.position.y, this.transform.position.z);
    }
}
