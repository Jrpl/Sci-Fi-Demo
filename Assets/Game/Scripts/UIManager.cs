using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _ammoCounter;
    [SerializeField]
    private GameObject _coinImage;

    void Start()
    {
        _coinImage.SetActive(false);
    }

    public void UpdateAmmo(int count)
    {
        _ammoCounter.text = "Ammo: " + count;
    }

    public void DisplayCoin()
    {
        _coinImage.SetActive(true);
    }
}
