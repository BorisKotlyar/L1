using System;
using UnityEngine;

namespace Lesson1.Model
{
    /// <summary>
    /// Basic class for all entities that can apply damage
    /// </summary>
    [Serializable]
    public class DamagebleData 
    {
        // Entity ID
        public int ID => _id;
        [SerializeField] protected int _id;

        // current health, available only for read
        public float Health => _health;
        [SerializeField] protected float _health;

        // current armor, available only for read
        public float Armor => _armor;
        [SerializeField] protected float _armor;

        /// <summary>
        /// Generate entity with initial data.
        /// </summary>
        /// <param name="health">Health on start.</param>
        /// <param name="armor">Armor on start</param>
        /// <param name="id">Unique entity ID</param>
        public DamagebleData(float health, float armor, int id)
        {
            _id = id;
            _health = health;
            _armor = armor;

            EntityHolder.RegisterEntity(this);
        }

        /// <summary>
        /// Apply damage to entity.
        /// </summary>
        /// <param name="damage">damage counter</param>
        public virtual void ApplyDamage(float damage)
        {
            // check damage limits
            var healthDelta = Mathf.Clamp(damage - _armor, 0, damage);
            _health -= healthDelta;

            // ??? =)
            _armor /= 2; 

            Debug.Log("[DamagebleData::ApplyDamage] ID:" + _id + " recieved " + healthDelta + " damage.");
        }

        public void DebugData()
        {
            Debug.Log("[DamagebleData] ID:" + _id + " HP:" + _health + " DEF:" + _armor);
        }
    }
}