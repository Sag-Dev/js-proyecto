﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashIndicator : MonoBehaviour
{
    public TrashCollector player;
    public Color normalColor, fullColor;

    private Text _text;

    // Start is called before the first frame update
    void Start() {
        _text = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = player.getCurrentTrash() + " / " + player.maxTrash;

        if (player.getCurrentTrash() > player.maxTrash) _text.color = fullColor;
        else _text.color = normalColor;
    }
}
