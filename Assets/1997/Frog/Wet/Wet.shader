Shader "Frog1997/Wet" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color", Color) = (1.0, 0.0, 1.0, 1.0)
        _Intensity ("Intensity", Range(1.0, 3.0)) = 1.0
    }

    SubShader {
        Tags {
            "Queue" = "Transparent"
            "IgnoreProjector" = "True"
            "RenderType" = "Transparent"
        }

        Cull Off
        ZWrite Off
        Blend One OneMinusSrcAlpha
        LOD 100

        Pass {
            CGPROGRAM
            #pragma vertex DrawVert
            #pragma fragment DrawFrag

            #include "UnityCG.cginc"

            // -- types --
            struct VertIn {
                float4 pos : POSITION;
                float3 normal : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct FragIn {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : TEXCOORD1;
            };

            // -- props --
            /// the texture
            sampler2D _MainTex;

            /// the texture SomeThing
            float4 _MainTex_ST;

            /// the effect color
            fixed4 _Color;

            /// the effect intensity (brightness)
            float _Intensity;

            // -- program --
            FragIn DrawVert(VertIn i) {
                FragIn o;
                o.pos = UnityObjectToClipPos(i.pos);
                o.uv = TRANSFORM_TEX(i.uv, _MainTex);
                o.normal = i.normal;

                // offset uv.x
                o.uv.x += _Time;

                return o;
            }

            fixed4 DrawFrag(FragIn i) : SV_Target {
                fixed4 c = fixed4(1.0f, 1.0f, 1.0f, 1.0f);

                if (i.normal.y != 0.0f || i.uv.y > 0.99f) {
                    discard;
                } else {
                    c = tex2D(_MainTex, i.uv).x * _Intensity * _Color;
                }

                return c;
            }
            ENDCG
        }
    }
}
