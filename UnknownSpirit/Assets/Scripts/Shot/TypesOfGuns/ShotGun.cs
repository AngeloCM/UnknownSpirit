using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Shot.TypesOfGuns
{
    class ShotGun : Gun
    {
        float shotsAngle = 25f;

        public ShotGun(GunController gController)
        {
            gunController = gController;
            bulletSpeed = 15f;
            timeBetweenShots = 0.5f;
            amountOfBullets = 20;
            Damage = 10;
        }

        public override void Update()
        {
            if (gunController.isFiring)
            {
                shotCounter -= Time.deltaTime;
                if (shotCounter <= 0)
                {
                    shotCounter = timeBetweenShots;
                    Shoot();
                }
            }
            else
            {
                shotCounter = 0;
            }
        }

        public override void Shoot()
        {
            if (amountOfBullets > 0)
            {
                BulletController newBullet = Instantiate(gunController.bullet, gunController.firePoint.position, gunController.firePoint.rotation) as BulletController;
                newBullet.speed = bulletSpeed;
                newBullet.GetComponent<Renderer>().material.color = new Color(255, 255, 0, 255);

                BulletController newBullet2 = Instantiate(gunController.bullet, gunController.firePoint.position, gunController.firePoint.rotation) as BulletController;
                newBullet2.gameObject.transform.Rotate(new Vector3(0, shotsAngle, 0));
                newBullet2.speed = bulletSpeed;
                newBullet2.GetComponent<Renderer>().material.color = new Color(255, 255, 0, 255);

                BulletController newBullet3 = Instantiate(gunController.bullet, gunController.firePoint.position, gunController.firePoint.rotation) as BulletController;
                newBullet3.gameObject.transform.Rotate(new Vector3(0, -shotsAngle, 0));
                newBullet3.speed = bulletSpeed;
                newBullet3.GetComponent<Renderer>().material.color = new Color(255, 255, 0, 255);

                amountOfBullets -= 1;

                newBullet.transform.parent = gunController.BulletsBeingShot.transform;
                newBullet2.transform.parent = gunController.BulletsBeingShot.transform;
                newBullet3.transform.parent = gunController.BulletsBeingShot.transform;
            }
            else
            {
                Debug.Log("Out of ammo!");
            }
        }
    }
}
