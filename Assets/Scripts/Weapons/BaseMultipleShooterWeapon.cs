using UnityEngine;

namespace Weapons
{
    public abstract class BaseMultipleShooterWeapon : BaseShooterWeapon
    {
        [SerializeField] protected int bulletCount;
        
    }
}