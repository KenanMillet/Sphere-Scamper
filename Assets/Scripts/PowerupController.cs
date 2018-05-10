using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupController : PickupController {


    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (player.getPoweredUp() == false)
            {
                player.setPoweredUp(true);
                gameController.AddScore(1);
                Destroy(this);
            }
        }
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(this);
        }
    }
}
