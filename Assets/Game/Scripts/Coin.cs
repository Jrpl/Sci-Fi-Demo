using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Sound
    [SerializeField]
    private AudioClip _pickupSound;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player _player = other.gameObject.GetComponent<Player>();
                _player.UpdateHasCoin(true);
                AudioSource.PlayClipAtPoint(_pickupSound, transform.position, 1f);
                Destroy(this.gameObject);
            }
        }
    }
}
