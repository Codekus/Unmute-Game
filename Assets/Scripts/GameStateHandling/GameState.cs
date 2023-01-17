using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameState
{
    [SerializeField] private TextField textField;
    public static int wave = 0;
    public static float timeScale = 1f;
    public static float score = 0;
    public static float multiplyer = 1;
    public static bool gamePaused = false;

    public static bool isDead = false;
    public static void resetCombo() {
        multiplyer = 1;
    }

    public static void ememieDestoyed() {
        score += multiplyer * 100;
        multiplyer += 0.05f;
    }

}
