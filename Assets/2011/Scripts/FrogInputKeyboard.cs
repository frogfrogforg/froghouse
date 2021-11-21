using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Frog2011 {

    public class FrogInputKeyboard : FrogInput
    {
        public string xAxis;
        public string yAxis;
        public override float GetDX() {
            return Input.GetAxis(xAxis);
        }

        public override float GetDY() {
            return Input.GetAxis(yAxis);
        }
    }

}