using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private GameObject _muzzleFlash;
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private float _gravity = 9.81f;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        if (!_controller)
        {
            Debug.LogError("Failed to get component Character Controller on Game Object: Player");
        }
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        CalcMovement();
        Fire();
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

    void Fire()
    {
        Vector3 centerScreen = new Vector3(0.5f, 0.5f, 0);

        if (Input.GetMouseButton(0))
        {
            _muzzleFlash.SetActive(true);

            Ray rayOrigin = Camera.main.ViewportPointToRay(centerScreen);
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo, Mathf.Infinity))
            {
                Debug.Log("Hit: " + hitInfo.transform.name);
            }
        }
        else 
        {
            _muzzleFlash.SetActive(false);
        }
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
