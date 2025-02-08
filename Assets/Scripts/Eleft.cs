using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Eleft : MonoBehaviour
{
    Text Text;

    public static int enemyLeft = 5;
    void Start()
    {
        Text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Text.text = "1 vs " + enemyLeft ; 

        if(enemyLeft <= 0)
        {
            SceneManager.LoadScene("SampleScene");
            enemyLeft = 5;
        }
    }
}
