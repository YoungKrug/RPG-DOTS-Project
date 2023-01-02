using _Scripts.Interfaces;
using Unity.Entities;
using Unity.Transforms;

namespace _Scripts.Properties
{
    public partial struct CharacterMovementAspect : IComponentData, IModifyMovement
    {
        public readonly RefRO<CharacterMovementProperties> CharacterMovementProperties;
        public Entity Entity;
        public WorldToLocal TranslateToLocalPosition(UniformScaleTransform transform)
        {
            WorldToLocal worldToLocal = new WorldToLocal();
            return worldToLocal;
        }
    }
}