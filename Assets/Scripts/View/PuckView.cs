using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckView : MonoBehaviour
{
    //private Variables
    private PuckSpawner spawner;
    private float mouseDistance;
    private Vector2 mouseDirection;
    private Vector2 mouseStartPos;
    private Vector2 mouseEndPos;
    private bool mouseDown;
    private bool canSwipe = true;
    [SerializeField] private float forceMultiplier;
    [SerializeField] private float maxDistMultiplier;

    //private Functions
    private void Start()
    {
        mouseDown = false;
    }

    private void LateUpdate()
    {
        CalculateSwipe();
    }

    private void CalculateSwipe()
    {
        if (Input.GetMouseButtonDown(0) && mouseDown == false && canSwipe == true)
        {
            mouseDown = true;
            mouseStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            canSwipe = false;
        }
        if (Input.GetMouseButtonUp(0) && mouseDown == true)
        {
            mouseEndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseDistance = Vector2.Distance(mouseEndPos, mouseStartPos);
            mouseDirection = mouseEndPos - mouseStartPos;
            PushPuck(mouseDirection, mouseDistance);
            mouseDown = false;
        }
    }

    private void PushPuck(Vector2 direction, float distMultiplier)
    {
        distMultiplier = Mathf.Min(distMultiplier, maxDistMultiplier);
        Debug.Log("Mouse Distance" + distMultiplier);
        this.GetComponent<Rigidbody2D>().AddForce(direction * distMultiplier * forceMultiplier, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            DestroyPuck();
        }
    }

    private void DestroyPuck()
    {
        spawner.PuckDestroyed();
    }

    //Public Functions
    public void AssignSpawner(PuckSpawner puckSpawner)
    {
        spawner = puckSpawner;
    }


}
