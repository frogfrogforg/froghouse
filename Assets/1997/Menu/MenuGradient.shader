Shader "Frog1997/MenuGradient" {
    Properties {
        _Src ("Src Color", Color) = (1.0, 1.0, 1.0, 1.0)
        _Dst ("Dst Color", Color) = (0.0, 0.0, 0.0, 1.0)
        [Toggle] _Vertical ("Is Vertical", Float) = 0

        _StencilComp ("Stencil Comparison", Float) = 8
        _Stencil ("Stencil ID", Float) = 0
        _StencilOp ("Stencil Operation", Float) = 0
        _StencilWriteMask ("Stencil Write Mask", Float) = 255
        _StencilReadMask ("Stencil Read Mask", Float) = 255

        _ColorMask ("Color Mask", Float) = 15

        [Toggle(UNITY_UI_ALPHACLIP)] _UseUIAlphaClip ("Use Alpha Clip", Float) = 0
    }

    SubShader {
        Tags {
            "Queue"="Transparent"
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True"
        }

        Stencil {
            Ref [_Stencil]
            Comp [_StencilComp]
            Pass [_StencilOp]
            ReadMask [_StencilReadMask]
            WriteMask [_StencilWriteMask]
        }

        Cull Off
        Lighting Off
        ZWrite Off
        ZTest [unity_GUIZTestMode]
        Blend SrcAlpha OneMinusSrcAlpha
        ColorMask [_ColorMask]

        Pass {
            CGPROGRAM
            #pragma vertex DrawVert
            #pragma fragment DrawFrag
            #pragma target 2.0

            #include "UnityCG.cginc"
            #include "UnityUI.cginc"

            #pragma multi_compile_local _ UNITY_UI_CLIP_RECT
            #pragma multi_compile_local _ UNITY_UI_ALPHACLIP

            // -- types --
            struct VertIn {
                float4 pos   : POSITION;
                float2 uv    : TEXCOORD0;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct FragIn {
                float4 vPos  : SV_POSITION;
                float4 wPos  : TEXCOORD1;
                fixed4 color : COLOR;
                UNITY_VERTEX_OUTPUT_STEREO
            };

            // -- props --
            /// the source color
            fixed4 _Src;

            /// the destination color
            fixed4 _Dst;

            /// if the gradient is vertical
            float _Vertical;

            /// the mask rect
            float4 _ClipRect;

            // -- program --
            FragIn DrawVert(VertIn i) {
                FragIn o;

                UNITY_SETUP_INSTANCE_ID(i);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

                o.wPos = i.pos;
                o.vPos = UnityObjectToClipPos(o.wPos);

                float pct = i.uv.x;
                if (_Vertical != 0.0f) {
                    pct = 1.0f - i.uv.y;
                }

                o.color = lerp(_Src, _Dst, pct);

                return o;
            }

            fixed4 DrawFrag(FragIn i) : SV_Target {
                fixed4 c = i.color;

                #ifdef UNITY_UI_CLIP_RECT
                c.a *= UnityGet2DClipping(i.wPos.xy, _ClipRect);
                #endif

                #ifdef UNITY_UI_ALPHACLIP
                clip(c.a - 0.001f);
                #endif

                return c;
            }
            ENDCG
        }
    }
}
