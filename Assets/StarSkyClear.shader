Shader "Custom/StarSkyClear" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
	}
	SubShader {
		Pass {
			Cull Off
			Tags { "RenderType"="Opaque" }
			
			CGPROGRAM
			 	#pragma vertex vert
	            #pragma fragment frag
	            
	            #include "UnityCG.cginc"

	            struct vertexInput {
	                float4 vertex : POSITION;
	                float4 texcoord0 : TEXCOORD0;
	            };

	            struct fragmentInput{
	                float4 position : SV_POSITION;
	                float4 texcoord0 : TEXCOORD0;
	            };
	            
	            uniform fixed4 _Color;
	            uniform sampler2D _MainTex;

	            fragmentInput vert(vertexInput i)
	            {
	                fragmentInput o;
	                o.position = mul (UNITY_MATRIX_MVP, i.vertex);
	                o.texcoord0 = i.texcoord0;
	                return o;
	            }
	            
	            fixed4 frag(fragmentInput i) : SV_Target {
	                return tex2D(_MainTex, i.texcoord0);
	            }
			ENDCG
		}
	} 
	FallBack "Diffuse"
}
