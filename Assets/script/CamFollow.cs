using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float moveSpeed = 4f;
    [SerializeField] float followSpeed = 5f;

    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);

        
        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.Lerp(transform.position.x, player.position.x, followSpeed * Time.deltaTime);

        transform.position = newPosition;
    }
}