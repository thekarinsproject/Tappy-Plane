using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBehaviour : MonoBehaviour
{
    [Tooltip("Amount of force applied")]
    public Vector2 jumpForce = new Vector2(0, 300);

    private Rigidbody2D rb2D;
    private bool beenHit;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = this.GetComponent<Rigidbody2D>();
        beenHit = false;
    }

    // LateUpdate is called after Update()
    void LateUpdate()
    {
        // Applies the jump if not dead
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !beenHit) {
            // 1st, plane's speed is reduced to zero before perform the impulse in Y axe
            rb2D.velocity = Vector2.zero;

            // 2nd, force is applied to the plane can get the impulse
            rb2D.AddForce(jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameControllerBehaviour.speedModifier = 0;
        beenHit = true;
        GetComponent<Animator>().speed = 0.0f;

        if (!gameObject.GetComponent<GameEndBehaviour>()) {
            gameObject.AddComponent<GameEndBehaviour>();
        }
    }
}
