using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Parallax Effect */

public class RepeatBackground : MonoBehaviour
{

    [Tooltip("Speed of background display")]
    public float scrollSpeed;
    
    // How big is the background image
    public const float scrollWidth = 8;

    // Physhics and natural movement goes here (Such as BG movement)
    void FixedUpdate()
    {
        // Get the position of the BG
        Vector3 pos = this.transform.position;

        // Now the BG will be moving at a fixed time (space = velocity * time)
        pos.x -= this.scrollSpeed * Time.deltaTime * GameControllerBehaviour.speedModifier;

        // If background is gone from the screen, it will be moved forward
        if (this.transform.position.x < -scrollWidth) {
            Offscreen(ref pos); 
        }

        // if BG is not destroyed, the BG is repositioned
        this.transform.position = pos;
    }

    // Virtual allows to modify the method implementation in children classes,
    protected virtual void Offscreen(ref Vector3 pos) {
        pos.x += 2 * scrollWidth;
    }

}
