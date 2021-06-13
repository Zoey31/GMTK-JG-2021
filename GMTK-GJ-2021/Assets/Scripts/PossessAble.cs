using UnityEngine;
using System.Collections;

public class PossessAble : MonoBehaviour
{
    public bool isPossessed = false;

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void OnPossessionStart(Animator playerAnimator, Transform playerPossition)
    {
        isPossessed = true;
        playerAnimator.SetBool("chaining", true);
        StartCoroutine(WaitForAnimation(playerAnimator, 2));
        playerPossition.transform.position = this.transform.position;
        this.transform.parent = playerPossition;
    }

    public virtual void OnAction(Rigidbody rb)
    {

    }

    public virtual void OnPossessionEnd(Animator playerAnimator, Transform playerPossition)
    {
        isPossessed = false;
        playerAnimator.SetBool("is_chained", false);
        this.transform.parent = null;
        playerPossition.transform.position += 
            new Vector3(2,2,2);
    }

    IEnumerator WaitForAnimation(Animator playerAnimator, float delayTime)
    {
        playerAnimator.SetBool("chaining", false);
        yield return new WaitForSeconds(delayTime);
        playerAnimator.SetBool("is_chained", true);
    }
}
