using System.Collections;
using UnityEngine;
using TarodevController;
using UnityEngine.InputSystem;

namespace Assets._Scripts.Player {
    public class NewPlayerController : PlayerController {
        protected InputAction m_MoveAction;
        protected InputAction m_JumpAction;

        protected override void Awake() {
            m_MoveAction = InputSystem.actions.FindAction("Move");
            m_JumpAction = InputSystem.actions.FindAction("Jump");
            base.Awake();
        }

        protected override FrameInput GatherFrameInput() {
            Vector2 move = m_MoveAction.ReadValue<Vector2>();

            bool jumpPressed = m_JumpAction.WasPressedThisFrame();
            bool jumpHeld = m_JumpAction.IsPressed();

            return new FrameInput {
                JumpDown = jumpPressed,
                JumpHeld = jumpHeld,
                Move = move
            };
        }
    }
}