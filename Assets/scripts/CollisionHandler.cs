﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region PRIVATE Methods

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        SendMessage("OnPlayerDeath");
    }

    #endregion
}
