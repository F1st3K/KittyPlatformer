using System;
using KittyPlatformer.Base;
using KittyPlatformer.Interfaces;
using UnityEngine;

namespace KittyPlatformer.Weapons
{
    public class WeaponReplacer : StateVariableEntity
    {
        [SerializeField] private Weapon weapon;
        
        private protected override void OnActivate()
        {
            if (Entity is IAttacker attacker)
            {
                attacker.ReplaceWeapon(weapon);
                if (attacker.Weapon is Weapon weaponry)
                    weapon = (Weapon) weaponry;
            }
            DeActivate();
        }
    }
}