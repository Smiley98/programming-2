Shader "Hidden/CircleShader"
{
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            float sdCircle(float2 p, float r)
            {
                return length(p) - r;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 uv = (i.vertex.xy / _ScreenParams.xy) * 2.0 - 1.0;
                uv.x *= (_ScreenParams.x / _ScreenParams.y);

                float circle = sdCircle(uv, 1.0);
                circle = 1.0 - step(0.0, circle);

                float3 rgb = float3(1.0, 0.0, 0.0);
                rgb *= circle;

                return fixed4(rgb, 1.0);
            }
            ENDCG
        }
    }
}
