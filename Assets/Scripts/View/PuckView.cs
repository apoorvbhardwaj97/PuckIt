using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PuckState
{
    ACTIVE,
    DESTROYED,
    INACTIVE
}

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
    private Rigidbody2D puckRb;
    private bool puckThrown = false;
    private PuckState thisPuckState = PuckState.ACTIVE;
    private Vector2 initialPosition;
    private bool puckStoped = false;
    private SpriteRenderer puckSprite;
    [SerializeField] private float forceMultiplier;
    [SerializeField] private float maxDistMultiplier;

    //private Functions
    private void Start()
    {
        mouseDown = false;
        puckRb = GetComponent<Rigidbody2D>();
        puckSprite = GetComponent<SpriteRenderer>();
        initialPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (canSwipe)
        {
            CalculateSwipe();
        }
        if (!puckStoped && puckThrown == true)
        {
            CheckPuckStopped();
        }
    }

    private void CalculateSwipe()
    {
        if (Input.GetMouseButtonDown(0) && mouseDown == false)
        {
            Debug.Log("mouseDown");
            mouseDown = true;
            mouseStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButtonUp(0) && mouseDown == true)
        {
            Debug.Log("Mouse Up");
            mouseEndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseDistance = Vector2.Distance(mouseEndPos, mouseStartPos);
            mouseDirection = mouseEndPos - mouseStartPos;
            PushPuck(mouseDirection, mouseDistance);
            mouseDown = false;
            puckThrown = true;
            canSwipe = false;
        }
    }

    private void PushPuck(Vector2 direction, float distMultiplier)
    {
        distMultiplier = Mathf.Min(distMultiplier, maxDistMultiplier);
        this.GetComponent<Rigidbody2D>().AddForce(direction * distMultiplier * forceMultiplier, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Touched SOmething: " + other.gameObject.name);
        if (other.gameObject.tag == "Wall")
        {
            DestroyPuck();
            spawner.PuckDestroyed();
        }
    }

    private void CheckPuckStopped()
    {

        if (puckRb.velocity.sqrMagnitude < .01)
        {
            Debug.Log("Puck Stoped");
            spawner.CurrentPuckStoped();
            puckStoped = true;
        }
    }

    private void DestroyPuck()
    {
        SetPuckSate(PuckState.DESTROYED);
    }

    //Public Functions
    public void AssignSpawner(PuckSpawner puckSpawner)
    {
        spawner = puckSpawner;
    }

    public void SetPuckSate(PuckState puckState)
    {
        thisPuckState = puckState;
        switch (thisPuckState)
        {
            case PuckState.DESTROYED:
                {
                    //diffrent sprite non swipable
                    var destroyedPuckColor = Color.red;
                    destroyedPuckColor.a = 30;
                    puckSprite.color = destroyedPuckColor;
                }
                break;
            case PuckState.INACTIVE:
                {
                    //diffrent sprite non swipable
                    var lightPuckColor = puckSprite.color;
                    lightPuckColor.a -= 0.5f;
                    puckSprite.color = lightPuckColor;
                }
                break;
        }
    }

    public void SpawnBack()
    {

    }


}
