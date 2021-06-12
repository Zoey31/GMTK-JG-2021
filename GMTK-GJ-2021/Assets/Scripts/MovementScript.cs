using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [SerializeField] GameObject playerGO;
    [SerializeField] float moveSpeedScaler = 100f;
    Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = playerGO.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    // This method should be refactored, that makes more sense ^^
    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeedScaler;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeedScaler;
        Debug.Log("DeltaX: " + deltaX);
        Debug.Log("DeltaY: " + deltaY);

        //var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        //var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        var movementVector = new Vector3(deltaX, 0, deltaY);
        transform.position += movementVector;

        if (deltaX + deltaY > 0)
        {
            playerAnimator.SetFloat("move_speed", deltaX + deltaY);
        }
        
        //transform.Translate(moveVertical * Time.deltaTime * moveSpeedScaler * Vector3.forward);
    }
}
