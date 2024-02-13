using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinText : MonoBehaviour
{
    [SerializeField] private GameObject _winText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            _winText.SetActive(true);
        }
    }
}
