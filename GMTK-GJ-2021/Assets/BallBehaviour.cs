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
    // Start is called before the first frame update

    void Start()
    {
        ring = GetChildWithName(this.gameObject, "Joinable_Highlight");
        hideRing();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

        if (distanceToPlayer < activationDistance)
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
    }

    void hideRing()
    {
        ring.SetActive(false);
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
}
