using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public delegate void UseAction(GameObject target);
    public static event UseAction OnUse;

    public static void PressUse(GameObject target) {
        OnUse?.Invoke(target);
    }
}
