using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkShop : MonoBehaviour
{
    // Sound
    [SerializeField]
    private AudioClip _buySound;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Player _player = other.gameObject.GetComponent<Player>();

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (_player._hasCoin)
                {
                    _player.UpdateHasCoin(false);
                    AudioSource.PlayClipAtPoint(_buySound, transform.position, 1f);
                    _player.EnableWeapon();
                }
            }
        }
    }
}
