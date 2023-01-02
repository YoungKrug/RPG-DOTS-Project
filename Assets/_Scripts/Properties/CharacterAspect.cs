using _Scripts.Interfaces;
using Unity.Entities;
using Unity.Transforms;

namespace _Scripts.Properties
{
    public readonly partial struct CharacterAspect : IAspect
    {
        public readonly RefRO<CharacterProperties> CharacterProperties;
        public readonly RefRO<CharacterMovementProperties> CharacterMovementProperties;
        public readonly Entity Entity;
      
    }
}