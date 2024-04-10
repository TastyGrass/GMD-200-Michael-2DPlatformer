using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Ammo : MonoBehaviour
{
    public int ammo = 0;
    public GameObject ammo1;
    public GameObject ammo2;
    public GameObject ammo3;
    public GameObject player;


    // Update is called once per frame
    void Update()
    {
        if (ammo == 0)
        {
            noAmmo();
            player.GetComponent<Shoot>().shoot = false;
        }
        else if (ammo > 0)
        {
            player.GetComponent<Shoot>().shoot = true;
        }

        if (ammo == 1)
        {
            oneAmmo();
        }
        else if (ammo == 2)
        {
            twoAmmo();
        }
        else if (ammo == 3)
        {
            threeAmmo();
        }
    }

    private void oneAmmo()
    {
        ammo1.SetActive(true);
        ammo2.SetActive(false);
        ammo3.SetActive(false);
    }
    private void twoAmmo()
    {
        ammo1.SetActive(true);
        ammo2.SetActive(true);
        ammo3.SetActive(false);
    }
    private void threeAmmo()
    {
        ammo1.SetActive(true);
        ammo2.SetActive(true);
        ammo3.SetActive(true);
    }
    private void noAmmo()
    {
        ammo1.SetActive(false);
        ammo2.SetActive(false);
        ammo3.SetActive(false);
    }

}
