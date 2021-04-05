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
        currentPuckView.gameObject.SetActive(false);
        InstantiatePuck();
    }

    //public Variable
    public void SpawnPuck()
    {
        if (scoreController.CheckBonusZone() && !currentPuckView.hitWall)
        {
            if (spawnController.CheckSpawn())
            {
                currentPuckView.SetPuckSate(PuckState.INACTIVE);
                SpawnBack();
            }
        }
        else if (currentPuckView.hitWall)
        {
            if (spawnController.CheckSpawn())
            {
                InstantiatePuck();
                spawnController.DecrementPuckCount();
            }
        }
        //changed if
        else if (!scoreController.CheckBonusZone())
        {
            currentPuckView.SetPuckSate(PuckState.INACTIVE);
            if (spawnController.CheckSpawn())
            {
                spawnController.DecrementPuckCount();
                InstantiatePuck();
            }
        }

        else
        {
            Debug.Log("<color=red>No Pucks Left</color>");
            //game over
            scoreController.UpdateHighScore();
        }

        if (!spawnController.CheckSpawn())
        {
            scoreController.GameEnd();
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
        if (currentPuckView.hitWall == false)
        {
            scoreController.StoreCurrentPuckScore();
        }
        SpawnPuck();
    }
}
