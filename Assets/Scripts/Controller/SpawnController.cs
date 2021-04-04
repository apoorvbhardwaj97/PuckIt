using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    //private variables
    [SerializeField] private PuckSpawner puckSpawnerView;
    [SerializeField] private UIView uIView;
    [SerializeField] private int puckCount;

    //private functions
    private void Start()
    {
        SpawnPuck();
        UpdateUI();
    }

    void Update()
    {

    }

    private void UpdateUI()
    {
        uIView.UpdateUI(puckCount);
    }

    private void SpawnPuck()
    {
        puckSpawnerView.SpawnPuck();
    }

    //public functions

    public void PuckDestroyed()
    {
        UpdateUI();
        SpawnPuck();
    }

    public void DecrementPuckCount()
    {
        puckCount--;
        UpdateUI();
    }

    public void PuckStoped()
    {
        SpawnPuck();
    }

    public bool CheckSpawn()
    {
        return puckCount < 0 ? false : true;
    }
}
