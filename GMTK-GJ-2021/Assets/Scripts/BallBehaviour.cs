using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublicSettings : PossessAble
{
    public GameObject player;
    public float activationDistance = 100;
}

public class ProtectedSettings : PublicSettings
{
    public GameObject ring;
}

public class BallBehaviour : ProtectedSettings
{
    public bool isInPlayerRange = false;
    Animator ballanimator;
    bool isAnimationPlaying = false;
    float jumpHight = 2.0f;

    private void Awake()
    {
        ballanimator = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        ring = GetChildWithName(this.gameObject, "Joinable_Highlight");
        hideRing();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

        isInPlayerRange = distanceToPlayer < activationDistance;

        if (isInPlayerRange && !isPossessed)
        {
            displayRing();
        }
        else
        {
            hideRing();
        }
    }

    void displayRing()
    {
        ring.SetActive(true);
        if (!isAnimationPlaying)
        {
            StartCoroutine(PlayIdleAnimation(3.0f));
        }
    }

    void hideRing()
    {
        ring.SetActive(false);
        isAnimationPlaying = false;
        ballanimator.SetBool("is_bored", isAnimationPlaying);
    }

    IEnumerator PlayIdleAnimation(float delay_time)
    {
        isAnimationPlaying = true;
        yield return new WaitForSeconds(delay_time);
        ballanimator.SetBool("is_bored", isAnimationPlaying);
    }

    GameObject GetChildWithName(GameObject obj, string name)
    {
        Transform trans = obj.transform;
        Transform childTrans = trans.Find(name);
        if (childTrans != null)
        {
            return childTrans.gameObject;
        }
        else
        {
            return null;
        }
    }

    public void OnAction(Rigidbody rb, Vector3 movementVector)
    {
        
        rb.AddForce(movementVector.x, jumpHight, movementVector.z, ForceMode.Impulse);
    }
}