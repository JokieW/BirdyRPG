Shader "Toon Shader" {
    Properties {
		_Color ("Color", Color) = (1,1,1,1) 
        _MainTex ("MainTex", 2D) = "white" {}
        _LightThreshold ("Light Threshold", Range(0, 1)) = 0.5
		_LightOpacity ("Light Opacity", Range(1, 10)) = 7
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0

            uniform float4 _LightColor0;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
			uniform float _LightThreshold;
			uniform float _LightOpacity;
			uniform float4 _Color;

            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Vectors:
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 diffuseColor = _MainTex_var.rgb;
				float3 diffuse = float3(0,0,0);
				if(NdotL <= _LightThreshold)
				{
					diffuse = float3(0.1,0.1,0.1)*_LightOpacity* UNITY_LIGHTMODEL_AMBIENT.rgb;// * ( * 2);
				}
				else
				{
					diffuse = float3(1,1,1) * (UNITY_LIGHTMODEL_AMBIENT.rgb * 2);
				}
/// Final Color:
                float3 finalColor = float4(diffuse, 1) * diffuseColor;
                fixed4 finalRGBA = fixed4(finalColor,1) * _Color;
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}