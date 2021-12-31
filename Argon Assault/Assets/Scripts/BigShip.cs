using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigShip : Enemy
{ 
    protected override void ProcessHit()
    {
        HitPoints -= 2;
    }
   
}
