using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    //private variables
    [SerializeField] private PuckSpawner puckSpawnerView;
    [SerializeField] private UIView uIView;
    [SerializeField] private int numberOfPucks;

    //private functions
    private void Start()
    {
        puckSpawnerView.SpawnPuck();
        --numberOfPucks;
        UpdateUI();
    }

    void Update()
    {

    }

    private void UpdateUI()
    {
        uIView.UpdateUI(numberOfPucks);
    }

    //public functions
}
