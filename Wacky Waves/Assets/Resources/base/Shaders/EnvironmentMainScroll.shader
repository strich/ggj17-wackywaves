// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Upgrade NOTE: commented out 'float4 unity_DynamicLightmapST', a built-in variable
// Upgrade NOTE: commented out 'float4 unity_LightmapST', a built-in variable

// Shader created with Shader Forge v1.04 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.04;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,limd:1,uamb:True,mssp:True,lmpd:False,lprd:False,rprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,rpth:1,hqsc:False,hqlp:False,tesm:0,blpr:0,bsrc:0,bdst:1,culm:0,dpts:2,wrdp:True,dith:2,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:1,x:34747,y:32712,varname:node_1,prsc:2|diff-7-OUT,emission-3689-OUT,clip-827-OUT;n:type:ShaderForge.SFN_Tex2d,id:5,x:33997,y:31898,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:node_7357,prsc:2,tex:4328c4993e1176c42af7c3504a62faa8,ntxv:0,isnm:False|UVIN-4681-UVOUT;n:type:ShaderForge.SFN_Color,id:6,x:33997,y:32126,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_330,prsc:2,glob:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:7,x:34276,y:32117,varname:node_7,prsc:2|A-5-RGB,B-6-RGB,C-1115-OUT;n:type:ShaderForge.SFN_Multiply,id:65,x:33788,y:32704,varname:node_65,prsc:2|A-478-RGB,B-2466-OUT,C-7645-RGB;n:type:ShaderForge.SFN_Tex2d,id:478,x:33415,y:32514,ptovrint:False,ptlb:Emissive,ptin:_Emissive,varname:node_1846,prsc:2,tex:cca43e1c19f446049a48587c94535d5b,ntxv:2,isnm:False|UVIN-257-UVOUT;n:type:ShaderForge.SFN_ValueProperty,id:2466,x:33415,y:32706,ptovrint:False,ptlb:Emissive Strength,ptin:_EmissiveStrength,varname:node_2466,prsc:2,glob:False,v1:1;n:type:ShaderForge.SFN_Color,id:7645,x:33415,y:32803,ptovrint:False,ptlb:Glow Color,ptin:_GlowColor,varname:node_7645,prsc:2,glob:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:3689,x:34556,y:32975,varname:node_3689,prsc:2|A-65-OUT,B-8444-OUT;n:type:ShaderForge.SFN_Tex2d,id:979,x:34012,y:32890,ptovrint:False,ptlb:Glow Blend,ptin:_GlowBlend,varname:node_979,prsc:2,tex:4328c4993e1176c42af7c3504a62faa8,ntxv:0,isnm:False|UVIN-8680-UVOUT;n:type:ShaderForge.SFN_ValueProperty,id:9817,x:34012,y:33113,ptovrint:False,ptlb:Glow Blend Strength,ptin:_GlowBlendStrength,varname:node_9817,prsc:2,glob:False,v1:1;n:type:ShaderForge.SFN_Color,id:8002,x:34012,y:33219,ptovrint:False,ptlb:Glow Blend Color,ptin:_GlowBlendColor,varname:node_8002,prsc:2,glob:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Time,id:5463,x:32492,y:32495,varname:node_5463,prsc:2;n:type:ShaderForge.SFN_Multiply,id:7526,x:32758,y:32590,varname:node_7526,prsc:2|A-5463-T,B-1378-OUT;n:type:ShaderForge.SFN_Panner,id:257,x:33006,y:32684,varname:node_257,prsc:2,spu:0,spv:1|UVIN-3718-UVOUT,DIST-7526-OUT;n:type:ShaderForge.SFN_TexCoord,id:3718,x:32758,y:32760,varname:node_3718,prsc:2,uv:0;n:type:ShaderForge.SFN_Time,id:8111,x:33149,y:32939,varname:node_8111,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:7500,x:33149,y:33127,ptovrint:False,ptlb:GlowBlend Scroll Speed,ptin:_GlowBlendScrollSpeed,varname:node_141,prsc:2,glob:False,v1:-0.2;n:type:ShaderForge.SFN_Multiply,id:8814,x:33415,y:33034,varname:node_8814,prsc:2|A-8111-T,B-7500-OUT;n:type:ShaderForge.SFN_Panner,id:8680,x:33663,y:33128,varname:node_8680,prsc:2,spu:0,spv:-1|UVIN-487-UVOUT,DIST-8814-OUT;n:type:ShaderForge.SFN_TexCoord,id:487,x:33415,y:33204,varname:node_487,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:8444,x:34280,y:33008,varname:node_8444,prsc:2|A-979-RGB,B-9817-OUT,C-8002-RGB;n:type:ShaderForge.SFN_ValueProperty,id:1378,x:32492,y:32650,ptovrint:False,ptlb:Emissive Scroll,ptin:_EmissiveScroll,varname:node_1373,prsc:2,glob:False,v1:0.4;n:type:ShaderForge.SFN_Multiply,id:827,x:34281,y:32397,varname:node_827,prsc:2|A-5-A,B-3129-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3129,x:33997,y:32483,ptovrint:False,ptlb:Alpha Cutoff,ptin:_AlphaCutoff,varname:node_3129,prsc:2,glob:False,v1:2;n:type:ShaderForge.SFN_Time,id:5890,x:33295,y:31729,varname:node_5890,prsc:2;n:type:ShaderForge.SFN_Multiply,id:7678,x:33530,y:31804,varname:node_7678,prsc:2|A-5890-T,B-2618-OUT;n:type:ShaderForge.SFN_Panner,id:4681,x:33778,y:31898,varname:node_4681,prsc:2,spu:0,spv:1|UVIN-9561-UVOUT,DIST-7678-OUT;n:type:ShaderForge.SFN_TexCoord,id:9561,x:33530,y:31974,varname:node_9561,prsc:2,uv:0;n:type:ShaderForge.SFN_ValueProperty,id:2618,x:33295,y:31884,ptovrint:False,ptlb:Main Scroll,ptin:_MainScroll,varname:node_1375,prsc:2,glob:False,v1:0.6;n:type:ShaderForge.SFN_ValueProperty,id:1115,x:33997,y:32304,ptovrint:False,ptlb:Main Multiplier,ptin:_MainMultiplier,varname:node_1115,prsc:2,glob:False,v1:1;proporder:6-5-1115-2618-478-7645-2466-1378-979-8002-9817-7500-3129;pass:END;sub:END;*/

Shader "Environment/EnvironmentMainScroll" {
    Properties {
        _Color ("Color", Color) = (1,1,1,1)
        _Diffuse ("Diffuse", 2D) = "white" {}
        _MainMultiplier ("Main Multiplier", Float ) = 1
        _MainScroll ("Main Scroll", Float ) = 0.6
        _Emissive ("Emissive", 2D) = "black" {}
        _GlowColor ("Glow Color", Color) = (1,1,1,1)
        _EmissiveStrength ("Emissive Strength", Float ) = 1
        _EmissiveScroll ("Emissive Scroll", Float ) = 0.4
        _GlowBlend ("Glow Blend", 2D) = "white" {}
        _GlowBlendColor ("Glow Blend Color", Color) = (1,1,1,1)
        _GlowBlendStrength ("Glow Blend Strength", Float ) = 1
        _GlowBlendScrollSpeed ("GlowBlend Scroll Speed", Float ) = -0.2
        _AlphaCutoff ("Alpha Cutoff", Float ) = 2
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "PrePassBase"
            Tags {
                "LightMode"="PrePassBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_PREPASSBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fog
            #pragma exclude_renderers xbox360 ps3 flash 
            #pragma target 3.0
            uniform fixed4 unity_Ambient;
            uniform float4 _TimeEditor;
            // float4 unity_LightmapST;
            #ifdef DYNAMICLIGHTMAP_ON
                // float4 unity_DynamicLightmapST;
            #endif
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float _AlphaCutoff;
            uniform float _MainScroll;
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
                #ifndef LIGHTMAP_OFF
                    float4 uvLM : TEXCOORD3;
                #else
                    float3 shLight : TEXCOORD3;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(unity_ObjectToWorld, float4(v.normal,0)).xyz;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Vectors:
                float3 normalDirection = i.normalDir;
                float4 node_5890 = _Time + _TimeEditor;
                float2 node_4681 = (i.uv0+(node_5890.g*_MainScroll)*float2(0,1));
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(node_4681, _Diffuse));
                clip((_Diffuse_var.a*_AlphaCutoff) - 0.5);
                return fixed4( normalDirection * 0.5 + 0.5, max(0.5,0.0078125) );
            }
            ENDCG
        }
        Pass {
            Name "PrePassFinal"
            Tags {
                "LightMode"="PrePassFinal"
            }
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_PREPASSFINAL
            #include "UnityCG.cginc"
            #pragma multi_compile_prepassfinal
            #pragma multi_compile_fog
            #pragma exclude_renderers xbox360 ps3 flash 
            #pragma target 3.0
            uniform sampler2D _LightBuffer;
            #if defined (SHADER_API_XBOX360) && defined (HDR_LIGHT_PREPASS_ON)
                sampler2D _LightSpecBuffer;
            #endif
            uniform fixed4 unity_Ambient;
            uniform float4 _TimeEditor;
            // float4 unity_LightmapST;
            #ifdef DYNAMICLIGHTMAP_ON
                // float4 unity_DynamicLightmapST;
            #endif
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float4 _Color;
            uniform sampler2D _Emissive; uniform float4 _Emissive_ST;
            uniform float _EmissiveStrength;
            uniform float4 _GlowColor;
            uniform sampler2D _GlowBlend; uniform float4 _GlowBlend_ST;
            uniform float _GlowBlendStrength;
            uniform float4 _GlowBlendColor;
            uniform float _GlowBlendScrollSpeed;
            uniform float _EmissiveScroll;
            uniform float _AlphaCutoff;
            uniform float _MainScroll;
            uniform float _MainMultiplier;
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
                float4 projPos : TEXCOORD3;
                UNITY_FOG_COORDS(4)
                #ifndef LIGHTMAP_OFF
                    float4 uvLM : TEXCOORD5;
                #else
                    float3 shLight : TEXCOORD5;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(unity_ObjectToWorld, float4(v.normal,0)).xyz;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Vectors:
                float3 normalDirection = i.normalDir;
                float4 node_5890 = _Time + _TimeEditor;
                float2 node_4681 = (i.uv0+(node_5890.g*_MainScroll)*float2(0,1));
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(node_4681, _Diffuse));
                clip((_Diffuse_var.a*_AlphaCutoff) - 0.5);
////// Lighting:
                half4 lightAccumulation = tex2Dproj(_LightBuffer, UNITY_PROJ_COORD(i.projPos));
                #if defined (SHADER_API_GLES) || defined (SHADER_API_GLES3)
                    lightAccumulation = max(lightAccumulation, half4(0.001));
                #endif
                #ifndef HDR_LIGHT_PREPASS_ON
                    lightAccumulation = -log2(lightAccumulation);
                #endif
                #if defined (SHADER_API_XBOX360) && defined (HDR_LIGHT_PREPASS_ON)
                    lightAccumulation.w = tex2Dproj (_LightSpecBuffer, UNITY_PROJ_COORD(i.projPos)).r;
                #endif
/////// Diffuse:
                float3 indirectDiffuse = float3(0,0,0);
                float3 directDiffuse = lightAccumulation.rgb * 0.5;
                indirectDiffuse += unity_Ambient.rgb*0.5; // Ambient Light
                float3 diffuse = (directDiffuse + indirectDiffuse) * (_Diffuse_var.rgb*_Color.rgb*_MainMultiplier);
////// Emissive:
                float4 node_5463 = _Time + _TimeEditor;
                float2 node_257 = (i.uv0+(node_5463.g*_EmissiveScroll)*float2(0,1));
                float4 _Emissive_var = tex2D(_Emissive,TRANSFORM_TEX(node_257, _Emissive));
                float4 node_8111 = _Time + _TimeEditor;
                float2 node_8680 = (i.uv0+(node_8111.g*_GlowBlendScrollSpeed)*float2(0,-1));
                float4 _GlowBlend_var = tex2D(_GlowBlend,TRANSFORM_TEX(node_8680, _GlowBlend));
                float3 emissive = ((_Emissive_var.rgb*_EmissiveStrength*_GlowColor.rgb)*(_GlowBlend_var.rgb*_GlowBlendStrength*_GlowBlendColor.rgb));
/// Final Color:
                float3 finalColor = diffuse + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ForwardBase"
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
            #pragma exclude_renderers xbox360 ps3 flash 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            // float4 unity_LightmapST;
            #ifdef DYNAMICLIGHTMAP_ON
                // float4 unity_DynamicLightmapST;
            #endif
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float4 _Color;
            uniform sampler2D _Emissive; uniform float4 _Emissive_ST;
            uniform float _EmissiveStrength;
            uniform float4 _GlowColor;
            uniform sampler2D _GlowBlend; uniform float4 _GlowBlend_ST;
            uniform float _GlowBlendStrength;
            uniform float4 _GlowBlendColor;
            uniform float _GlowBlendScrollSpeed;
            uniform float _EmissiveScroll;
            uniform float _AlphaCutoff;
            uniform float _MainScroll;
            uniform float _MainMultiplier;
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
                #ifndef LIGHTMAP_OFF
                    float4 uvLM : TEXCOORD6;
                #else
                    float3 shLight : TEXCOORD6;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(unity_ObjectToWorld, float4(v.normal,0)).xyz;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Vectors:
                float3 normalDirection = i.normalDir;
                float4 node_5890 = _Time + _TimeEditor;
                float2 node_4681 = (i.uv0+(node_5890.g*_MainScroll)*float2(0,1));
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(node_4681, _Diffuse));
                clip((_Diffuse_var.a*_AlphaCutoff) - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 indirectDiffuse = float3(0,0,0);
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float3 diffuse = (directDiffuse + indirectDiffuse) * (_Diffuse_var.rgb*_Color.rgb*_MainMultiplier);
////// Emissive:
                float4 node_5463 = _Time + _TimeEditor;
                float2 node_257 = (i.uv0+(node_5463.g*_EmissiveScroll)*float2(0,1));
                float4 _Emissive_var = tex2D(_Emissive,TRANSFORM_TEX(node_257, _Emissive));
                float4 node_8111 = _Time + _TimeEditor;
                float2 node_8680 = (i.uv0+(node_8111.g*_GlowBlendScrollSpeed)*float2(0,-1));
                float4 _GlowBlend_var = tex2D(_GlowBlend,TRANSFORM_TEX(node_8680, _GlowBlend));
                float3 emissive = ((_Emissive_var.rgb*_EmissiveStrength*_GlowColor.rgb)*(_GlowBlend_var.rgb*_GlowBlendStrength*_GlowBlendColor.rgb));
/// Final Color:
                float3 finalColor = diffuse + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ForwardAdd"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers xbox360 ps3 flash 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            // float4 unity_LightmapST;
            #ifdef DYNAMICLIGHTMAP_ON
                // float4 unity_DynamicLightmapST;
            #endif
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float4 _Color;
            uniform sampler2D _Emissive; uniform float4 _Emissive_ST;
            uniform float _EmissiveStrength;
            uniform float4 _GlowColor;
            uniform sampler2D _GlowBlend; uniform float4 _GlowBlend_ST;
            uniform float _GlowBlendStrength;
            uniform float4 _GlowBlendColor;
            uniform float _GlowBlendScrollSpeed;
            uniform float _EmissiveScroll;
            uniform float _AlphaCutoff;
            uniform float _MainScroll;
            uniform float _MainMultiplier;
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
                #ifndef LIGHTMAP_OFF
                    float4 uvLM : TEXCOORD5;
                #else
                    float3 shLight : TEXCOORD5;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(unity_ObjectToWorld, float4(v.normal,0)).xyz;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Vectors:
                float3 normalDirection = i.normalDir;
                float4 node_5890 = _Time + _TimeEditor;
                float2 node_4681 = (i.uv0+(node_5890.g*_MainScroll)*float2(0,1));
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(node_4681, _Diffuse));
                clip((_Diffuse_var.a*_AlphaCutoff) - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 diffuse = directDiffuse * (_Diffuse_var.rgb*_Color.rgb*_MainMultiplier);
/// Final Color:
                float3 finalColor = diffuse;
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCollector"
            Tags {
                "LightMode"="ShadowCollector"
            }
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCOLLECTOR
            #define SHADOW_COLLECTOR_PASS
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcollector
            #pragma multi_compile_fog
            #pragma exclude_renderers xbox360 ps3 flash 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            // float4 unity_LightmapST;
            #ifdef DYNAMICLIGHTMAP_ON
                // float4 unity_DynamicLightmapST;
            #endif
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float _AlphaCutoff;
            uniform float _MainScroll;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_COLLECTOR;
                float2 uv0 : TEXCOORD5;
                #ifndef LIGHTMAP_OFF
                    float4 uvLM : TEXCOORD6;
                #else
                    float3 shLight : TEXCOORD6;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_SHADOW_COLLECTOR(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
/////// Vectors:
                float4 node_5890 = _Time + _TimeEditor;
                float2 node_4681 = (i.uv0+(node_5890.g*_MainScroll)*float2(0,1));
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(node_4681, _Diffuse));
                clip((_Diffuse_var.a*_AlphaCutoff) - 0.5);
                SHADOW_COLLECTOR_FRAGMENT(i)
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Cull Off
            Offset 1, 1
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma exclude_renderers xbox360 ps3 flash 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            // float4 unity_LightmapST;
            #ifdef DYNAMICLIGHTMAP_ON
                // float4 unity_DynamicLightmapST;
            #endif
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float _AlphaCutoff;
            uniform float _MainScroll;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                #ifndef LIGHTMAP_OFF
                    float4 uvLM : TEXCOORD2;
                #else
                    float3 shLight : TEXCOORD2;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
/////// Vectors:
                float4 node_5890 = _Time + _TimeEditor;
                float2 node_4681 = (i.uv0+(node_5890.g*_MainScroll)*float2(0,1));
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(node_4681, _Diffuse));
                clip((_Diffuse_var.a*_AlphaCutoff) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
