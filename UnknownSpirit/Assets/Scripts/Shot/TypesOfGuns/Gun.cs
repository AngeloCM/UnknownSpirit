using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Shot.TypesOfGuns
{
    public abstract class Gun : ScriptableObject, IShotable
    {
        public GunController gunController;

        public BulletController bullet;

        public float bulletSpeed;

        public float timeBetweenShots;

        public int amountOfBullets;

        protected float shotCounter;

        public Transform firePoint;

        public abstract void Shoot();

        public abstract void Update();
    }
}
