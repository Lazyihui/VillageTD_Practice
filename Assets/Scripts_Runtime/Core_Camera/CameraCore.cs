using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace TD {


    public class CameraCore {
        public Camera cam;

        public void Inject(Camera camera) {
            this.cam = camera;
        }

        public void Follow(Vector2 target) {
            Vector3 camPos = cam.transform.position;
            cam.transform.position = PFCamera.Follow(camPos, target);
            Debug.Log("CameraCore.Follow: " + cam.transform.position);
        }

    }
}