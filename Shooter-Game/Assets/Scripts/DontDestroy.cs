using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    static DontDestroy dontDestroy;
    private void Awake() {
        if (dontDestroy != null && dontDestroy != this) {
            Destroy(this.gameObject);
        } else {
            dontDestroy = this;
        }

        Object.DontDestroyOnLoad(this.gameObject);
    }
}
