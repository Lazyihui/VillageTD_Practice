using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TD {

    public class InputEntity {
        public InputController Player1;


        public Vector2 moveAxis;

        public InputEntity() {
            Player1 = new InputController();
            Player1.Enable();
        }

        public void Process(float dt) {
            
            var world = Player1.World;

            // move
            {
                float kbx = world.KB_MoveUp.ReadValue<float>() + world.KB_MoveDown.ReadValue<float>();
                float kby = world.KB_MoveRight.ReadValue<float>() + world.KB_MoveLeft.ReadValue<float>();
                moveAxis.x = kbx;
                moveAxis.y = kby;


            }

             // - Move
            // {
            //     float kbX = world.KB_MoveRight.ReadValue<float>() + world.KB_MoveLeft.ReadValue<float>();
            //     float kbY = world.KB_MoveUp.ReadValue<float>() + world.KB_MoveDown.ReadValue<float>();
            //     moveAxis.x = kbX;
            //     moveAxis.y = kbY;
            //     if (kbX != 0 || kbY != 0) {
            //         currentDevice = DEVICE_KB;
            //     }

            //     float jsX = world.JS_MoveRight.ReadValue<float>().ToOne() + world.JS_MoveLeft.ReadValue<float>().ToOne();
            //     float jsY = world.JS_MoveUp.ReadValue<float>().ToOne() + world.JS_MoveDown.ReadValue<float>().ToOne();
            //     moveAxis.x += jsX;
            //     moveAxis.y += jsY;
            //     if (jsX != 0 || jsX != 0) {
            //         currentDevice = DEVICE_JS;
            //     }

            //     if (world.KB_MoveLeft.WasPerformedThisFrame() || world.JS_MoveLeft.WasPerformedThisFrame()) {
            //         directionKey = InputKeyFlag.MoveLeft;
            //     } else if (world.KB_MoveRight.WasPerformedThisFrame() || world.JS_MoveRight.WasPerformedThisFrame()) {
            //         directionKey = InputKeyFlag.MoveRight;
            //     } else if (world.KB_MoveUp.WasPerformedThisFrame() || world.JS_MoveUp.WasPerformedThisFrame()) {
            //         directionKey = InputKeyFlag.MoveUp;
            //     } else if (world.KB_MoveDown.WasPerformedThisFrame() || world.JS_MoveDown.WasPerformedThisFrame()) {
            //         directionKey = InputKeyFlag.MoveDown;
            //     }
            // }
        }
    }
}