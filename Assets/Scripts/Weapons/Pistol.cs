using System;
using UnityEngine;

namespace Weapons
{
    public class Pistol : BaseSingleShooterWeapon
    {
        private void Start()
        {
            damage = 10f;

            weaponAmmoCount = 10;
            maxAmmoCount = 100;
            clipAmmoCount = 10;
            
            reloadTime = 1f;
            
            fireRate = 0.5f;
            fireRange = 100f;
            
            recoilForce = 10f;
            recoilAngle = 10f;
            
        }

        public override void Fire()
        {
            if (weaponAmmoCount <= 0) return;
            weaponAmmoCount--;
            // draw raycast

            Ray ray = Camera.main.ScreenPointToRay(0.5f * new Vector2(Screen.width, Screen.height));
            if (Physics.Raycast(ray, out RaycastHit hit, fireRange))
            {
                Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.gameObject.TryGetComponent(out IDamageable damageable))
                {
                    damageable.TakeDamage(damage);
                }
            }
            
            // apply recoil
            //todo

        }

        public override void Reload()
        {
            if (weaponAmmoCount == clipAmmoCount) return;
            if (maxAmmoCount <= 0) return;
            // wait for relaod time
            WaitForSeconds waitForSeconds = new WaitForSeconds(reloadTime);
            //todo

            int ammoToReload = clipAmmoCount - weaponAmmoCount;
            if (maxAmmoCount < ammoToReload)
            {
                ammoToReload = maxAmmoCount;
            }
            weaponAmmoCount += ammoToReload;
            maxAmmoCount -= ammoToReload;
        }
    }
}