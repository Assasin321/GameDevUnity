using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Health
{
    public class Health
    {
        private float health;

        private float armor;
        public float GetHealth => health;
        public float GetArmor => armor;

        public float SetHealth(float health)
        {
            this.health = health;

            return GetHealth;
        }
        public float SetArmor(float armor)
        {
            this.armor = armor;

            return GetArmor;
        }


        public void DamageHealth(float damage)
        {
            this.health -= damage;
        }

        public void CareHealth(float care)
        {
            this.health += care;
        } 
        
        public void DamageArmor(float damage)
        {
            this.armor -= damage;
        }

        public void CareArmor(float care)
        {
            this.armor += care;
        }
    }

    public class HealthScript : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}

