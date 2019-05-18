Shader "Unlit/Blindness"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_time ("Time", Float ) = 0
		_seeDist ("SeeDist", Float) = 0.5
    }
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

            sampler2D _MainTex;
			float _time;
			float _seeDist;

			float calcVisibility(float2 uv, float2 eyeCentre)
			{
				float2 diff = (uv - eyeCentre) * float2(1, .7);
				float dist = length(diff);
			
				const float start = _seeDist + .01f * sin(_time * 10);// sin(_time % 3.14159 * 2);
				const float end = start + 0.05f;//0.45f;//;

				float amt = 1 - ((max(dist - start, 0) / (end - start)) * .5);
				return amt;
			}

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);

				
				//float amt = max(calcVisibility(i.uv, float2(.4, .5)), calcVisibility(i.uv, float2(0.6, 0.5)));
				float amt = calcVisibility(i.uv, float2(.5, .5));

                col = (col * amt);
                return col;
            }
            ENDCG
        }
    }
}
