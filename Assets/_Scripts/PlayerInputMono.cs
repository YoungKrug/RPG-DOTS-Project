using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts
{
    public class PlayerInputMono : MonoBehaviour
    {
        [SerializeField] private float speed = 4f;
        private Vector3 _movePos = Vector3.zero;
        public void Move(InputAction.CallbackContext context)
        {
            Vector2 val = context.ReadValue<Vector2>();
            _movePos = new Vector3(val.x,0, val.y);
        }
        private void Update()
        {
            transform.Translate(_movePos * (speed * Time.deltaTime));
        }
    }
}