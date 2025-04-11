Shader "Hidden/SpiralShader"
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

            float3 palette(float t, float3 a, float3 b, float3 c, float3 d)
            {
                return a + b * cos(6.283185 * (c * t + d));
            }

            float3 customColor(float t)
            {
                float3 a = float3(0.500, 0.500, 0.500);
                float3 b = float3(0.500, 0.500, 0.500);
                float3 c = float3(3.138, 3.138, 3.138);
                float3 d = float3(1.000, 0.333, 0.667);
                return palette(t, a, b, c, d);
            }

            float4 frag (v2f i) : SV_Target
            {
                float2 uv = (i.vertex.xy / _ScreenParams.xy) * 2.0 - 1.0;
                uv.x *= (_ScreenParams.x / _ScreenParams.y);
                
                float d = length(uv);
                float3 col = customColor(d + _Time.y * 0.2);
                
                d = sin(d * 8.0 + _Time.y) / 8.0;
                d = abs(d);
                d = 0.02 / d;
                
                float3 rgb = col * d;
                return float4(rgb, 1.0);
            }
            ENDCG
        }
    }
}
