using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Player;

public class UseHealthTest : MonoBehaviour
{
    private void OnEnable() {
        EventHandler.OnUse += Use;
    }

    private void OnDisable() {
        EventHandler.OnUse -= Use;
    }

    void Use(GameObject target) {
        // Checks if the used object is this object
        if (gameObject == target) {
            // log that the object has been used
            Debug.Log(gameObject.name + " has been used!");
            UseObject();
        }
    }

    void UseObject() {
        player.TakeDamage(10);
    }
}
