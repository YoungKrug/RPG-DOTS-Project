using Unity.Entities;

namespace _Scripts.Properties
{
    public partial struct CharacterProperties : IComponentData
    {
        public float Health;
        public float Intellect;
        public float Dexterity;
        public float Vitality;
        public float BaseDamage;
        public Entity Character;
    }
}