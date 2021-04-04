﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckSpawner : MonoBehaviour
{
    //private Variable
    [SerializeField] private GameObject puckPrefab;
    [SerializeField] private SpawnController spawnController;
    private PuckView currentPuckView;

    //public Variable
    public void SpawnPuck()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        currentPuckView = Instantiate(puckPrefab, transform).GetComponent<PuckView>();
        currentPuckView.AssignSpawner(this.GetComponent<PuckSpawner>());

    }

    public void PuckDestroyed()
    {
    }
}