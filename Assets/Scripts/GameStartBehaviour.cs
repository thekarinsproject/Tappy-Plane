using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartBehaviour : MonoBehaviour
{

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        player.GetComponent<Rigidbody2D>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            GameControllerBehaviour controller = GetComponent<GameControllerBehaviour>();
            controller.InvokeRepeating("spawnRock", 1.5f, 1);
            player.GetComponent<Rigidbody2D>().isKinematic = false;
            Destroy(this);
        }
    }
}
