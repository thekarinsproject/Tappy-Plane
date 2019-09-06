using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : RepeatBackground
{
    protected override void Offscreen(ref Vector3 pos)
    {
        Destroy(this.gameObject);
    }


}
