﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static void EndGame()
    {
        Application.LoadLevel("MainScene");
    }
}
