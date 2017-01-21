Shader "WFTO/JackAlphaBlended"
{
	Properties 
	{
_MainTex("Main_Texture", 2D) = "white" {}
_Color01("Color", Color) = (1,1,1,1)
_LightenMain("Brightness_Main", Float) = 1
	}
	SubShader 
	{
		Tags
		{
"Queue"="Transparent"
"IgnoreProjector"="False"
"RenderType"="Transparent"
		}	
Cull Off
ZWrite On
ZTest LEqual
ColorMask RGBA
Fog{
}
		CGPROGRAM
#pragma surface surf BlinnPhongEditor  alpha decal:blend vertex:vert
#pragma target 2.0

sampler2D _MainTex;
float4 _Color01;
sampler2D _Blend_Texture;
float4 _Color02;
sampler2D _Blend_Texture01;
float4 _Color03;
float _Speed01;
float _Speed02;
float _LightenMain;
float _Lighten;

			struct EditorSurfaceOutput {
				half3 Albedo;
				half3 Normal;
				half3 Emission;
				half3 Gloss;
				half Specular;
				half Alpha;
				half4 Custom;
			};
			
			inline half4 LightingBlinnPhongEditor_PrePass (EditorSurfaceOutput s, half4 light)
			{
half3 spec = light.a * s.Gloss;
half4 c;
c.rgb = (s.Albedo * light.rgb + light.rgb * spec);
c.a = s.Alpha;
return c;
			}

			inline half4 LightingBlinnPhongEditor (EditorSurfaceOutput s, half3 lightDir, half3 viewDir, half atten)
			{
				half3 h = normalize (lightDir + viewDir);				
				half diff = max (0, dot ( lightDir, s.Normal ));				
				float nh = max (0, dot (s.Normal, h));
				float spec = pow (nh, s.Specular*128.0);				
				half4 res;
				res.rgb = _LightColor0.rgb * diff;
				res.w = spec * Luminance (_LightColor0.rgb);
				res *= atten * 2.0;
				return LightingBlinnPhongEditor_PrePass( s, res );
			}			
			struct Input {
				float2 uv_MainTex;
				float4 color : COLOR;
			};
			void vert (inout appdata_full v, out Input o) {
				UNITY_INITIALIZE_OUTPUT(Input,o);
				float4 VertexOutputMaster0_0_NoInput = float4(0,0,0,0);
				float4 VertexOutputMaster0_1_NoInput = float4(0,0,0,0);
				float4 VertexOutputMaster0_2_NoInput = float4(0,0,0,0);
				float4 VertexOutputMaster0_3_NoInput = float4(0,0,0,0);
			}			
			void surf (Input IN, inout EditorSurfaceOutput o) {
				UNITY_INITIALIZE_OUTPUT(EditorSurfaceOutput,o);
				o.Normal = float3(0.0,0.0,1.0);
				o.Alpha = 1.0;
				o.Albedo = 0.0;
				o.Emission = 0.0;
				o.Gloss = 0.0;
				o.Specular = 0.0;
				o.Custom = 0.0;
				
				float4 Tex2D0=tex2D(_MainTex,(IN.uv_MainTex.xyxy).xy);
				float4 Multiply5=_Color01 * Tex2D0;
				float4 Add0=Multiply5;
				float4 Multiply11=_LightenMain.xxxx * Add0;
				float4 Multiply2=Multiply11 * IN.color;
				float4 SplatAlpha0=IN.color.w;
				float4 Multiply4=Multiply11 * SplatAlpha0;
				o.Emission = Multiply2;
				o.Alpha = Multiply4;
				o.Normal = normalize(o.Normal);
			}
		ENDCG
	}
	Fallback "Diffuse"
}