using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{

    [SerializeField]
    private Vector3 targetLocation;
    private Vector3 startingLocation;
    private bool canMove = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startingLocation = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            MovePlatform();
        }
    }

    private void MovePlatform()
    {
        Vector3 direction = (targetLocation - startingLocation).normalized;
        transform.position += direction * Time.deltaTime;
        if (Vector3.Distance(transform.position, targetLocation) < 0.2f)
        {
            targetLocation = startingLocation;
            startingLocation = transform.position;
            canMove = false;
            Invoke(nameof(CanMoveSet), 1f);

        }
    }

    private void CanMoveSet()
    {

        canMove = true;
    }
}
