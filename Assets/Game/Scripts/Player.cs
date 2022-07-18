﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;

    // Settings
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private float _gravity = 9.81f;
    [SerializeField]
    private int _maxAmmo = 50;
    [SerializeField]
    private int _currentAmmo;

    // Weapon
    [SerializeField]
    private GameObject _muzzleFlash;
    [SerializeField]
    private GameObject _hitMarker;
    private AudioSource _weaponSound;
    private bool _isReloading = false;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        if (!_controller)
        {
            Debug.LogError("Failed to get component Character Controller on Game Object: Player");
        }

        _weaponSound = GameObject.Find("Weapon/Weapon").GetComponent<AudioSource>();
        if (!_weaponSound)
        {
            Debug.LogError("Failed to get component Audio Source on Game Object: Player");
        }

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        _currentAmmo = _maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        CalcMovement();
        Shoot();
        if (Input.GetKeyDown(KeyCode.R) && _isReloading == false)
        {
            _isReloading = true;
            StartCoroutine(Reload());
        }
        UnHideCursor();
    }

    void CalcMovement()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(xInput, 0, zInput);
        Vector3 velocity = direction * _speed;
        velocity.y -= _gravity;
        velocity = transform.TransformDirection(velocity);
        _controller.Move(velocity * Time.deltaTime);
    }

    void Shoot()
    {
        Vector3 centerScreen = new Vector3(0.5f, 0.5f, 0);

        if (Input.GetMouseButton(0) && _currentAmmo > 0)
        {
            _muzzleFlash.SetActive(true);

            Ray rayOrigin = Camera.main.ViewportPointToRay(centerScreen);
            RaycastHit hitInfo;

            if (!_weaponSound.isPlaying)
            {
                _weaponSound.Play();
            }

            if (Physics.Raycast(rayOrigin, out hitInfo, Mathf.Infinity))
            {
                Debug.Log("Hit: " + hitInfo.transform.name);
                Instantiate(_hitMarker, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            }

            _currentAmmo--;
        }
        else
        {
            _muzzleFlash.SetActive(false);
            _weaponSound.Stop();
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(1.5f);
        _currentAmmo = _maxAmmo;
        _isReloading = false;
    }

    void UnHideCursor()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
