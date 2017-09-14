Shader "JawsShaders/SpriteShaderDeluxe"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
        _GrayNess("GrayNess", Float) = 0.0
    }
        SubShader
        {
			Tags{ "RenderType" = "Transparent" }
			Blend SrcAlpha OneMinusSrcAlpha
            LOD 100

            Pass
            {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                // make fog work
                #pragma multi_compile_fog

                #include "UnityCG.cginc"

                float _GrayNess;

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv);
				float alpha = col.a;
				float f = _GrayNess; // desaturate by 20%
				float L = 0.3f*col.r + 0.6f*col.g + 0.1f*col.b;
				fixed4 cNew;
				cNew.r = col.r + f * (L - col.r);
				cNew.g = col.g + f * (L - col.g);
				cNew.b = col.b + f * (L - col.b);
				cNew.a = 1.0f;
				//cNew *= 0.5f;
				col = cNew;
				col.a = alpha;

				//col.a = 0.2f;
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
			}
			ENDCG
		}
	}
}
