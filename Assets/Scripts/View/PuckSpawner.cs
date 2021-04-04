using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckSpawner : MonoBehaviour
{
    //private Variable
    [SerializeField] private GameObject puckPrefab;
    [SerializeField] private SpawnController spawnController;
    [SerializeField] private ScoreController scoreController;

    private PuckView currentPuckView;

    //private functions
    private void SpawnBack()
    {
        //change destory
        Destroy(currentPuckView.gameObject);
        InstantiatePuck();
    }

    //public Variable
    public void SpawnPuck()
    {
        if (scoreController.CheckBonusZone())
        {
            SpawnBack();
        }

        if (!scoreController.CheckBonusZone())
        {
            spawnController.DecrementPuckCount();
            currentPuckView.SetPuckSate(PuckState.INACTIVE);
        }

        if (spawnController.CheckSpawn())
        {
            InstantiatePuck();
        }

        else
        {
            Debug.Log("<color=red>No Pucks Left</color>");
            //game over
        }

    }

    public void InstantiatePuck()
    {
        currentPuckView = Instantiate(puckPrefab, transform).GetComponent<PuckView>();
        currentPuckView.AssignSpawner(this.GetComponent<PuckSpawner>());
        spawnController.AssignCurrentPuckView(currentPuckView);
    }


    public void PuckDestroyed()
    {
        spawnController.PuckDestroyed();
    }

    public void CurrentPuckStoped()
    {
        scoreController.StoreCurrentPuckScore();
        SpawnPuck();
    }
}
