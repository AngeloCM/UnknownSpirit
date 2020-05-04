using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Shot.TypesOfGuns
{
    public class RocketLauncher : Gun
    {
        public RocketLauncher(GunController gController)
        {
            gunController = gController;
            bulletSpeed = 15f;
            timeBetweenShots = 0.5f;
            amountOfBullets = 20;
            Damage = 5;
        }

        public override void Shoot()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
