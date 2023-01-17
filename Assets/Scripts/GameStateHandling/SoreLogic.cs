using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SoreLogic : MonoBehaviour
{
    [SerializeField] private Text text;

    // Update is called once per frame
    private void Update()
    {
        if(!GameState.gamePaused && !GameState.isDead) GameState.score += Time.deltaTime * 10;
        text.text = "" + (int) GameState.score;
    }
}
