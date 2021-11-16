using UnityEngine;

namespace Frog1997 {

namespace Colors {
    /// an hsv color
    public struct Hsv {
        // -- props --
        /// the hue
        public readonly float H;

        /// the saturation
        public readonly float S;

        /// the value
        public readonly float V;

        // -- lifetime --
        public Hsv(Color c) {
            Color.RGBToHSV(c, out H, out S, out V);
        }

        public Hsv(float h, float s, float v) {
            H = h;
            S = s;
            V = v;
        }

        // -- operators --
        /// add to each component
        public Hsv Add(float h = 0.0f, float s = 0.0f, float v = 0.0f) {
            return new Hsv(H + h, S + s, V + v);
        }

        /// multiply each component
        public Hsv Mul(float h = 1.0f, float s = 1.0f, float v = 1.0f) {
            return new Hsv(H * h, S * s, V * v);
        }

        /// set the hue
        public Hsv Hue(float h) {
            return new Hsv(h, S, V);
        }

        // -- queries --
        /// get rgb color from hsv
        public Color ToRgb(float a = 1.0f) {
            var color = Color.HSVToRGB(Mathf.Repeat(H, 1.0f), S, V);
            color.a = a;
            return color;
        }
    }
}

}