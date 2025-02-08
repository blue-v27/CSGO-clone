using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    public GameObject buyMenu;

    public void AWP()
    {
        if (Money.money >= 4700)
        {
            Money.money -= 4700;
            Movementy.gun = 0;
            buyMenu.SetActive(false);
            Time.timeScale = 1f;
            LockMouse();
        }
    }
    public void AR()
    {
        if (Money.money >= 2700)
        {
            Money.money -= 2700;
            Movementy.gun = 1;
            buyMenu.SetActive(false);
            Time.timeScale = 1f;
            LockMouse();
        }
    }
    public void SMG()
    {
        if (Money.money >= 2300)
        {
            Money.money -= 2300;
            Movementy.gun = 2;
            buyMenu.SetActive(false);
            Time.timeScale = 1f;
            LockMouse();
        }
    }
    public void SG()
    {
        if (Money.money >= 1200)
        {
            Money.money -= 1200;
            Movementy.gun = 3;
            buyMenu.SetActive(false);
            Time.timeScale = 1f;
            LockMouse();
            Input.GetKeyDown(KeyCode.Alpha3);
        }
    }
    public void SMOKE()
    {
        if (Money.money >= 300)
        {
            Money.money -= 300;
            buyMenu.SetActive(false);
            Time.timeScale = 1f;
            LockMouse();
        }
    }
    public void MOLIA()
    {
        if (Money.money >= 500)
        {
            Money.money -= 500;
        }
    }
    public void FLASH()
    {
        if (Money.money >= 200)
        {
            Money.money -= 200;
        }
    }
    public void HE()
    {
        if (Money.money >= 300)
        {
            Money.money -= 300;
        }
    }

    void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }
}


