using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TD {
    // TODO: 这个应该叫InputCore 不是InputEntity
    public class InputEntity {
        public InputController Player1;
        public Vector2 moveAxis;
        public Vector2 mousePositionScreen;
        public Vector2 mousePositionWorld;
        public Vector2Int mousePositionGrid;
        public bool mouseLeftClick;
        public bool mouseRightClick;
        public bool ispressF;

        public InputEntity() {
            Player1 = new InputController();
            Player1.Enable();
        }

        public void Process(float dt) {

            var world = Player1.World;

            // move
            {
                float kbxUp = world.KB_MoveUp.ReadValue<float>();
                float kbxDown = world.KB_MoveDown.ReadValue<float>();

                float kbxRight = world.KB_MoveRight.ReadValue<float>();
                float kbxLeft = world.KB_MoveLeft.ReadValue<float>();

                Vector2 pos = new Vector2(kbxRight - kbxLeft, kbxUp - kbxDown);
                moveAxis = pos;

            }
            // mouse
            {
                mousePositionScreen = Input.mousePosition;
                // 屏幕坐标转换为世界坐标
                mousePositionWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                Vector2 worldPos = mousePositionWorld;
                // (-0.5, 0) -> (-1, 0)
                // (-1.5, 0) -> (-1, 0)
                if (worldPos.x < 0) {
                    worldPos.x -= 0.5f;
                } else {
                    worldPos.x += 0.5f;
                }
                if (worldPos.y < 0) {
                    worldPos.y -= 0.5f;
                } else {
                    worldPos.y += 0.5f;
                }
                // 世界坐标转换为格子坐标
                mousePositionGrid = new Vector2Int((int)worldPos.x, (int)worldPos.y);

            }
            // mouse click
            {
                float left = world.MouseLeft.ReadValue<float>();
                if (left > 0) {
                    mouseLeftClick = true;
                } else {
                    mouseLeftClick = false;
                }
                float right = world.MouseRight.ReadValue<float>();
                if (right > 0) {
                    mouseRightClick = true;
                } else {
                    mouseRightClick = false;
                }
            }
            {
                float f = world.KB_PressF.ReadValue<float>();
                if (f > 0) {
                    ispressF = true;
                } else {
                    ispressF = false;
                }
            }
        }
    }
}