using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;
using XDiffGui;

namespace FernShaderGraph
{
    static class FernSG_Field
    {
        [GenerateBlocks("Fern")]
        public struct SurfaceDescription
        {
            private static string name = "SurfaceDescription";

            public static BlockFieldDescriptor Shininess = new BlockFieldDescriptor(FernSG_Field.SurfaceDescription.name, "Shininess", "Shininess", "SURFACEDESCRIPTION_SHININESS",
                new FloatControl(0.5f), ShaderStage.Fragment);

            public static BlockFieldDescriptor Glossiness = new BlockFieldDescriptor(FernSG_Field.SurfaceDescription.name, "Glossiness", "Glossiness", "SURFACEDESCRIPTION_GLOSSINESS",
                new FloatControl(0.5f), ShaderStage.Fragment);
            
            public static BlockFieldDescriptor SpecularIntensity = new BlockFieldDescriptor(FernSG_Field.SurfaceDescription.name, "SpecularIntensity", "SpecularIntensity", 
                "SURFACEDESCRIPTION_SPECULARINTENSITY", new FloatControl(1), ShaderStage.Fragment);
            
            public static BlockFieldDescriptor CellThreshold = new BlockFieldDescriptor(FernSG_Field.SurfaceDescription.name, "CellThreshold", "Cell Threshold", 
                "SURFACEDESCRIPTION_CELLTHRESHOLD", new FloatControl(1), ShaderStage.Fragment);
            
            public static BlockFieldDescriptor CellSmoothness = new BlockFieldDescriptor(FernSG_Field.SurfaceDescription.name, "CellSmoothness", "Cell Smoothness", 
                "SURFACEDESCRIPTION_CELLSMOOTHNESS", new FloatControl(1), ShaderStage.Fragment);
            
            public static BlockFieldDescriptor RampColor = new BlockFieldDescriptor(FernSG_Field.SurfaceDescription.name, "RampColor", "Ramp Color", 
                "SURFACEDESCRIPTION_RAMPCOLOR", new ColorControl(Color.white, false), ShaderStage.Fragment); 
            
            public static BlockFieldDescriptor SpecularColor = new BlockFieldDescriptor(FernSG_Field.SurfaceDescription.name, "SpecularColor", "Specular Color", 
                "SURFACEDESCRIPTION_SPECULARCOLOR", new ColorControl(Color.white, false), ShaderStage.Fragment);
            
            public static BlockFieldDescriptor StylizedSpecularSize = new BlockFieldDescriptor(FernSG_Field.SurfaceDescription.name, "StylizedSpecularSize", "Stylized SpecularSize", 
                "SURFACEDESCRIPTION_STYLIZESPECULARSIZE", new FloatControl(0.2f), ShaderStage.Fragment);
            
            public static BlockFieldDescriptor StylizedSpecularSoftness = new BlockFieldDescriptor(FernSG_Field.SurfaceDescription.name, "StylizedSpecularSoftness", "Stylized Specular Softness", 
                "SURFACEDESCRIPTION_STYLIZEDSPECULARSOFTNESS", new FloatControl(0.1f), ShaderStage.Fragment);
        }
    }
}

