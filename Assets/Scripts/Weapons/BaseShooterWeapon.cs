using Unity.Netcode;
using UnityEngine;

namespace Weapons
{
    public abstract class BaseShooterWeapon : BaseWeapon
    {
        [SerializeField] protected int weaponAmmoCount;
        [SerializeField] protected int maxAmmoCount;
        [SerializeField] protected int clipAmmoCount;
        [SerializeField] protected float reloadTime;
        
        [SerializeField] protected float fireRate;
        [SerializeField] protected float fireRange;
        
        [SerializeField] protected float recoilForce;
        [SerializeField] protected float recoilAngle;
        
        public abstract void Reload();
    }
}