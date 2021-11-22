using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Frog2011 {

    public class FrogInputCombined : FrogInput
    {
        public FrogInputWiimote wiimoteInput;
        public FrogInputKeyboard keyboardInput;

        public override float GetDX() {
            return Mathf.Clamp(wiimoteInput.GetDX() + keyboardInput.GetDX(), -1f, 1f);
        }

        public override float GetDY() {
            return Mathf.Clamp(wiimoteInput.GetDY() + keyboardInput.GetDY(), -1f, 1f);
        }

        public override float GetViolence() {
            return Mathf.Clamp(wiimoteInput.GetViolence() + keyboardInput.GetViolence(), 0f, 1f);
        }
    }

}