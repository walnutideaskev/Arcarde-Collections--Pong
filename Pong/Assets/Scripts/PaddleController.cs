using UnityEngine;
using UnityEngine.InputSystem;

namespace WalnutIdeas
{
    public class PaddleController : MonoBehaviour
    {
        [Header("Input")]
        public InputActionReference moveAction;

        [Header("Movement")]
        public float speed = 8f;
        public float minY = -4f;
        public float maxY = 4f;

        private void OnEnable()
        {
            moveAction.action.Enable();
        }

        private void OnDisable()
        {
            moveAction.action.Disable();
        }

        private void Update()
        {
            float input = moveAction.action.ReadValue<float>();

            Vector3 pos = transform.position;
            pos.y += input * speed * Time.deltaTime;
            pos.y = Mathf.Clamp(pos.y, minY, maxY);

            transform.position = pos;
        }
    }
}
