using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPickup : MonoBehaviour {

    public int addPoints;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() == null)
            return;

        ScoreManager.AddPoints(addPoints);

        Destroy(gameObject);
    }
}
