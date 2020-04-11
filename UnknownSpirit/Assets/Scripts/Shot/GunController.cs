using Assets.Scripts.Shot.TypesOfGuns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    Gun _currentGun;
    public BulletController bullet;
    public Transform firePoint;
    public bool isFiring;

    private void Start()
    {
        _currentGun = new Pistol(this);
    }

    void Update()
    {
        if (_currentGun != null)
        {
            _currentGun.Update();
        }
    }

    public void setMachineGun()
    {
        _currentGun = new MachineGun(this);
    }

    public void setShotGun()
    {
        _currentGun = new ShotGun(this);
    }

    public void setPistol()
    {
        _currentGun = new Pistol(this);
    }
}
