using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBehaviour : MonoBehaviour
{
    GameObject player;
    Collider goalCollider;
    [SerializeField] SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        goalCollider = GetComponentInChildren<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colisioned :D with" + collision.gameObject.name);
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Should Start New Lvl");
            sceneLoader.loadNextScene();
        }
    }

}
