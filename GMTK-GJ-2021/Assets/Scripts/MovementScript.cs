using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [SerializeField] GameObject playerGO;
    [SerializeField] float moveSpeedScaler = 100f;
    [SerializeField] float rotateSpeedScaler = 10f;
    [SerializeField] ParticleSystem dustParticles;
    Animator playerAnimator;
    public bool hasPossession = false;

    void Start()
    {
        playerAnimator = playerGO.GetComponentInChildren<Animator>();
    }

    void Update()
    {
        var movementVector = Move();
        Rotate(movementVector);
        Animate(movementVector);
        Possess(movementVector);
    }

    private void Animate(Vector3 targetVector)
    {
        if (targetVector.magnitude > 0)
        {
            playerAnimator.SetFloat("move_speed", targetVector.magnitude);
            var meshTranform = GetComponentInChildren<Transform>();
            Instantiate(
                dustParticles,
                meshTranform.position,
                Quaternion.Euler(transform.position.x, 180 - transform.position.y, transform.position.z)
                );
        }
    }

    private Vector3 Move()
    {
        var targetVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (!hasPossession)
        {
            var speed = moveSpeedScaler * Time.deltaTime;
            var targetPosition = transform.position + targetVector * speed;
            transform.position = targetPosition;
        }

        return targetVector;
    }

    private void Rotate(Vector3 movementVector)
    {
        if (movementVector.magnitude == 0) { return; }
        var rotation = Quaternion.LookRotation(movementVector);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeedScaler);
    }

    private void Possess(Vector3 movementVector)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var possessAble = GameObject.FindGameObjectWithTag("PossesAble").GetComponent<BallBehaviour>();
            if (possessAble.isInPlayerRange && !possessAble.isPossessed)
            {
                possessAble.OnPossessionStart(playerAnimator, transform);
                hasPossession = possessAble.isPossessed;
            }
            else
            {
                possessAble.OnAction(GetComponentInChildren<Rigidbody>(), movementVector);
            }
        }

        if (Input.GetKeyDown(KeyCode.Q)) {
            var possessAble = GameObject.FindGameObjectWithTag("PossesAble").GetComponent<BallBehaviour>();
            if (possessAble.isPossessed) // should also check is its not in the air
            {
                possessAble.OnPossessionEnd(playerAnimator, transform);
                hasPossession = possessAble.isPossessed;
            }
        }

    }
}
