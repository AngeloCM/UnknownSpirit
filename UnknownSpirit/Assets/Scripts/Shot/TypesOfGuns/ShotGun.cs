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
        float shotsAngle = 15f;

        public ShotGun(GunController gController)
        {
            gunController = gController;
            bulletSpeed = 15f;
            timeBetweenShots = 0.3f;
            amountOfBullets = 300;
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

                BulletController newBullet2 = Instantiate(gunController.bullet, gunController.firePoint.position, gunController.firePoint.rotation) as BulletController;
                newBullet2.gameObject.transform.Rotate(new Vector3(0, shotsAngle, 0));
                newBullet2.speed = bulletSpeed;

                BulletController newBullet3 = Instantiate(gunController.bullet, gunController.firePoint.position, gunController.firePoint.rotation) as BulletController;
                newBullet3.gameObject.transform.Rotate(new Vector3(0, -shotsAngle, 0));
                newBullet3.speed = bulletSpeed;

                amountOfBullets -= 3;
            }
            else
            {
                Debug.Log("Out of ammo!");
            }
        }
    }
}
