using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Moneyu : MonoBehaviour
{
    Text Text;
    float display;

    void Start()
    {
        Text = GetComponent<Text>();

    }

    
    void Update()
    {
        display = Money.money;
        Text.text =display + "$";
    }
}
