Shader "BasicUWShader" {
	Properties{
		_MainTex("Greyscale (R) Alpha (A)", 2D) = "white" {}
		_Color("Main Color", Color) = (1,1,1,1)
	}

		SubShader{
		Pass{
		Tags{ "LightMode" = "ForwardAdd" }
		Name "BasicUWShader"
		CGPROGRAM

		#pragma vertex vert
		#pragma fragment frag
		#pragma multi_compile_fwdadd_fullshadows
		#include "UnityCG.cginc"
		#include "AutoLight.cginc"

		struct v2f {
		float4 pos : SV_POSITION;
		LIGHTING_COORDS(0,1)
			float2 uv : TEXCOORD2;
		};

		v2f vert(appdata_tan v)
		{
			v2f o;
			o.pos = UnityObjectToClipPos(v.vertex);
			o.uv = v.texcoord.xy;
			TRANSFER_VERTEX_TO_FRAGMENT(o);
			return o;
		}

		sampler2D _MainTex;

		float4 frag(v2f i) : COLOR
		{
			//float greyscale = tex2D(_MainTex, i.uv).r;
			float4 result;
			result.rgb = tex2D(_MainTex, i.uv).rgb; //tex2D(_ColorPaletteIn, float2(greyscale, 0.1)).rgb;
			result.a = tex2D(_MainTex, i.uv).a;
			//return result;
			return result *LIGHT_ATTENUATION(i);
			}
			ENDCG
		}
	}
}