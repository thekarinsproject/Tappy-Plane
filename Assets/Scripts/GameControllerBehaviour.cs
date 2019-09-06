using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerBehaviour : MonoBehaviour
{
    // if 0, game is over and BG is stopped
    [HideInInspector]
    public static float speedModifier;

    [Header("Rocks information")]
    [Tooltip("Rock's spawn")]
    public GameObject rockSpawn;

    [Tooltip("Rock's min Y")]
    public float rockMinY = -1.2f;
    [Tooltip("Rock's max Y")]
    public float rockMaxY = 1.2f;

    // Start is called before the first frame update
    void Start()
    {
        speedModifier = 1.0f;
        this.gameObject.AddComponent<GameStartBehaviour>();
        

        // Invokes spawnRock after 1.5 seconds every second
        //InvokeRepeating("spawnRock", 1.5f, 1);
    }

    void spawnRock() {
        Vector3 pos = new Vector3(RepeatBackground.scrollWidth, Random.Range(rockMinY,rockMaxY), 0.0f); // x = 8, y = 2.5 +- 1.2
        Instantiate(rockSpawn, pos, Quaternion.identity);
    }

}
