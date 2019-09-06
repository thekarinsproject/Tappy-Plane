using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndBehaviour : MonoBehaviour
{
    private bool isOver = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayQuit());
        GameControllerBehaviour controller = GameObject.Find("GameController")
                                                       .GetComponent<GameControllerBehaviour>();
        controller.CancelInvoke(); // Stops the coroutine spawnRock.
    }

    // Update is called once per frame
    void Update()
    {
        if ( (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) ) && isOver) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    IEnumerator DelayQuit() {
        yield return new WaitForSeconds(1.0f);
        isOver = true;
    }
}
