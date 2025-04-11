Shader "Unlit/NormalsShader"
{
    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // include file that contains UnityObjectToWorldNormal helper function
            #include "UnityCG.cginc"

            struct v2f {
                // we'll output world space normal as one of regular ("texcoord") interpolators
                half3 worldNormal : TEXCOORD0;
                float4 pos : SV_POSITION;
            };

            // vertex shader: takes object space normal as input too
            v2f vert (float4 vertex : POSITION, float3 normal : NORMAL)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(vertex);
                o.worldNormal = UnityObjectToWorldNormal(normal);   // <-- world-space
                //o.worldNormal = normal;                           // <-- object-space
                return o;
            }
            
            fixed4 frag (v2f i) : SV_Target
            {
                // [-1, 1] by default. Can convert to [0, 1] via * 0.5 + 0.5 if we want.
                // Best left in [-1, 1] to debug topology.
                fixed4 c = 0;
                c.rgb = i.worldNormal;
                return c;
            }
            ENDCG
        }
    }
}
