using Unity.Cinemachine;
using UnityEngine;

public class MapTransition : MonoBehaviour
{
    [SerializeField] PolygonCollider2D mapBoundary;
    CinemachineConfiner2D confiner;
    [SerializeField] Direction direction;
    [SerializeField] float addPos = 1.75f;

    enum Direction { Up, Down, Left, Right }

    private void Awake()
    {
        confiner = FindFirstObjectByType<CinemachineConfiner2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            confiner.BoundingShape2D = mapBoundary;
            UpdatePlayerPosition(collision.gameObject);
        }
    }

    private void UpdatePlayerPosition(GameObject player)
    {
        Vector3 newPos = player.transform.position;

        switch (direction)
        {
            case Direction.Up:
                newPos.y += addPos;
                break;
            case Direction.Down: 
                newPos.y -= addPos;
                break;
            case Direction.Left:
                newPos.x += addPos;
                break;
            case Direction.Right:
                newPos.x -= addPos;
                break;
        }

        player.transform.position = newPos;
    }
}
