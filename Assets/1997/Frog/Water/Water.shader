Shader "Frog1997/Water" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
    }

    SubShader {
        Tags {
            "RenderType" = "Opaque"
        }
        LOD 100

        Pass {
            CGPROGRAM
            #pragma vertex DrawVert
            #pragma fragment DrawFrag

            #include "UnityCG.cginc"

            // -- types --
            struct VertIn {
                float4 pos : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct FragIn {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
                float2 p0 : TEXCOORD1;
            };

            // -- props --
            /// the texture
            sampler2D _MainTex;

            /// the texture SomeThing
            float4 _MainTex_ST;

            // -- program --
            FragIn DrawVert(VertIn v) {
                FragIn o;
                o.pos = UnityObjectToClipPos(v.pos);
                o.p0 = TRANSFORM_TEX(v.uv, _MainTex);

                o.uv = o.p0;
                o.uv.x += cos(_Time);
                o.uv.y += sin(_Time);

                return o;
            }

            fixed4 DrawFrag(FragIn i) : SV_Target {
                fixed4 c = fixed4(1.0f, 1.0f, 1.0f, 1.0f);

                if (length(2.0f * i.p0 - 1.0f) > 1.0f) {
                    discard;
                } else {
                    c = tex2D(_MainTex, i.uv);
                }

                return c;
            }
            ENDCG
        }
    }
}
