using Unity.Netcode;
using UnityEngine;
using UnityEngine.Serialization;

namespace Weapons
{
    public abstract class BaseWeapon : NetworkBehaviour
    {
        [SerializeField] protected float damage;
        
        public abstract void Fire();
    }
}