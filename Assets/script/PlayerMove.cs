using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float moveSpeed = 4;
    [SerializeField] float xPos;
    [SerializeField] float zPos;
    [SerializeField] int sideSpeed = 9;
    [SerializeField] int trackNumber = 1;
    [SerializeField] bool currentMove;
    [SerializeField] int moveDirection;
    [SerializeField] AudioSource Aahh;
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        xPos = gameObject.transform.position.x;
        zPos = gameObject.transform.position.z;

        if(currentMove == true && moveDirection == 1)       //moving left
        {
            transform.Translate(Vector3.left * Time.deltaTime * sideSpeed, Space.World);
            if(xPos <= trackNumber)
            {
                moveDirection = 0;
                currentMove = false;
                transform.position = new Vector3(trackNumber, 1, zPos);
            }
        }
        if(currentMove == true && moveDirection == 2)       //moving right
        {
            transform.Translate(Vector3.left * Time.deltaTime * sideSpeed * -1, Space.World);
            if(xPos >= trackNumber)
            {
                currentMove = false;
                moveDirection = 0;
                transform.position = new Vector3(trackNumber, 1, zPos);
            }
        }
    }

    public void LeftMove()
    {
        if(trackNumber == 1)
        {
            Aahh.Play();
            moveDirection = 1;
            currentMove = true;
            trackNumber = 0;
        }
        if(trackNumber == 2)
        {
            Aahh.Play();
            moveDirection = 1;
            currentMove = true;

            trackNumber = 1;
        }
    }


    public void RightMove()
    {
        if(trackNumber == 1)
        {
            Aahh.Play();
            moveDirection = 2;
            currentMove = true;
            trackNumber = 2;
        }
        if(trackNumber == 0)
        {
            Aahh.Play();
            moveDirection = 2;
            currentMove = true;
            trackNumber = 1;
        }
        
    }
}
