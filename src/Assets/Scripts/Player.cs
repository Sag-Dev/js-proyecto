﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField]
    private uint _id;
    [SerializeField]
    private bool _spotlight_active = true;
    [SerializeField]
    private float _waterGravityScale = 0.1f;
    [SerializeField]
    private float _airGravityScale = 1f;
    [SerializeField]
    private float _waterUpperLimit = -1.3f;

    private bool _insideWater = false;
    private Rigidbody2D _rb;
    private PlayerMovement _playerMovement;

    public void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    public bool isSpotlightActive() {
        return _spotlight_active;
    }

    public void setSpotlightActive(bool spotlight_active) {
        _spotlight_active = spotlight_active;
    }

    public uint getID() {
        return _id;
    }

    public void enterWater()
    {
        if (_insideWater && transform.position.y < _waterUpperLimit) return;

        _insideWater = true;
        _rb.gravityScale = _waterGravityScale;
    }

    public void exitWater()
    {
        if (!_insideWater && transform.position.y < _waterUpperLimit) return;

        _insideWater = false;
        _rb.gravityScale = _airGravityScale;
    }

    public bool insideWater()
    {
        return _insideWater;
    }
}