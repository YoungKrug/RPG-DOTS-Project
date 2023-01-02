using _Scripts.Properties;
using Unity.Transforms;

namespace _Scripts.Interfaces
{
    interface IModifyMovement
    {
        public WorldToLocal TranslateToLocalPosition(UniformScaleTransform transform);
    }
}