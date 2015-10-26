Shader "ColourReplacement" {
    Properties {
        _MainTex ("Greyscale (R) Alpha (A)", 2D) = "white" {}
        //_ColorPalette ("Colour Palette", 2D) = "gray" {}
    }

    SubShader {
        Pass {
            Name "ColorReplacementPass"
            CGPROGRAM
          
                #pragma vertex vert
                #pragma fragment frag
                #pragma fragmentoption ARB_precision_hint_fastest
                #include "UnityCG.cginc"
               
                struct v2f
                {
                    float4  pos : SV_POSITION;
                    float2  uv : TEXCOORD0;
                };
 
                v2f vert (appdata_tan v)
                {
                    v2f o;
                    o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                    o.uv = v.texcoord.xy;
                    return o;
                }

                sampler2D _MainTex;
                sampler2D _ColorPaletteIn;
 
                float4 frag(v2f i) : COLOR
                {
                // SURFACE COLOUR
                      float greyscale = tex2D(_MainTex, i.uv).r;
                // RESULT
                    float4 result;
                    result.rgb = tex2D(_ColorPaletteIn, float2(greyscale, 0.1)).rgb;
                
                  	result.a = tex2D(_MainTex, i.uv).a;
                    return result;
                }
                
            ENDCG
          
               
        }
     }
    
}