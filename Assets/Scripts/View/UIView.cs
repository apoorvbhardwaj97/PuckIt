﻿using System.Collections;
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
        pucksLeftText.text = pucksLeft.ToString();
    }
}