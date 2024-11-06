using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TD {

    public class InputEntity {
        public InputController Player1;


        public Vector2 moveAxis;

        public Vector2 mousePositionScreen;

        public Vector2 mousePositionWorld;

        public Vector2Int mousePositionGrid;

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
                mousePositionScreen = world.Mouse_Pos.ReadValue<Vector2>();
                // 屏幕坐标转换为世界坐标
                mousePositionWorld = Camera.main.ScreenToWorldPoint(new Vector3(mousePositionScreen.x, mousePositionScreen.y, 0));
                // 世界坐标转换为格子坐标
                mousePositionGrid = new Vector2Int((int)mousePositionWorld.x, (int)mousePositionWorld.y);
            }

        }
    }
}