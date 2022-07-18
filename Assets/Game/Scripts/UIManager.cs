using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _ammoCounter;

    public void UpdateAmmo(int count)
    {
        _ammoCounter.text = "Ammo: " + count;
    }
}
