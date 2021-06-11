using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [SerializeField] GameObject playerGO;
    [SerializeField] float moveSpeedScaler = 10f;
    Animator playerAnimator;

    float moveHorizontal = 0;
    float moveVertical = 0;

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
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        if (moveHorizontal + moveVertical > 0)
        {
            playerAnimator.SetFloat("move_speed", moveHorizontal + moveVertical);
        }
        
        transform.Translate(moveVertical * Time.deltaTime * moveSpeedScaler * Vector3.forward);
    }
}
