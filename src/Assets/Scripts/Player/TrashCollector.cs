﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class TrashCollector : MonoBehaviour
{
    public int maxTrash;
    private int currentTrash = 0;

    private Player _player;

    void Start() {
        _player = GetComponent<Player>();
    }

    public bool addTrash(int trash = 1) {
        if (trash < 0) return false;

        currentTrash += trash;
        _player.updateTrash();
        return true;
    }

    public void clearTrash() {
        currentTrash = 0;
        _player.updateTrash();
    }

    public int getCurrentTrash() {
        return currentTrash;
    }

    public float getTrashPercentage() {
        return (float)currentTrash / maxTrash;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Trash trash = collision.gameObject.GetComponent<Trash>();
        if (trash != null && addTrash()) {
            collision.gameObject.SetActive(false);
            TrashManager.collectGarbage(collision.transform.GetSiblingIndex());
        }
    }

    public void updateLevel()
    {
        maxTrash = Player.GetProgress().getMaxTrash();
    }
}
