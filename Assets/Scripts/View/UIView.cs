using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIView : MonoBehaviour
{
    //private variables
    [SerializeField] private TextMeshProUGUI pucksLeftText;
    void Start()
    {

    }

    void Update()
    {

    }

    //public functions
    public void UpdateUI(int pucksLeft)
    {
        if (pucksLeft >= 0)
        { pucksLeftText.text = pucksLeft.ToString(); }
    }
}
