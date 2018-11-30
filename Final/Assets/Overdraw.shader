Shader "Hidden/Overdraw"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		// No culling or depth
	   Tags { 
        "Queue" = "Transparent" 
        }
        ZTest Always
        ZWrite Off
        Blend One One
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

	   struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float depth : DEPTH;
            }

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }
            
            half4 _OverDrawColor; 

            fixed4 frag (v2f i) : SV_Target
            { 
                return __OverDrawColor;
            }
			}
			ENDCG
		}
	}
