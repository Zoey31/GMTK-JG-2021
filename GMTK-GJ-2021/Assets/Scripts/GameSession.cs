using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    public Vector3 playerStartingPos;
    public Vector3 ballStartingPos;
    public GameObject player;
    public GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        Debug.Log("Starting game" + player.transform.position + " got childen: " + player.transform.childCount);
        {

        }
        if (player.transform.childCount >= 2)
        {
            Debug.Log("Shoulda spawn a ball");
            var ballRef = Instantiate(ball, ballStartingPos, Quaternion.identity);
            ballRef.GetComponent<Transform>().position = playerStartingPos;
        }
        var playerRef = Instantiate(player, playerStartingPos, Quaternion.identity) as GameObject;
        playerRef.GetComponent<Transform>().position = playerStartingPos;
    }

    public void ResetGame()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Transform>().position = playerStartingPos;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(playerStartingPos, 0.5f);
    }
}
