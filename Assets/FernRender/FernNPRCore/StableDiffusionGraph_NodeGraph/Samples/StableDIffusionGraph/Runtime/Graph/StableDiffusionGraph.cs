using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GraphProcessor;
using UnityEditor;
using UnityEngine;

namespace FernNPRCore.SDNodeGraph
{
    public enum NodeInheritanceMode
    {
        InheritFromGraph = -1,
        InheritFromParent = -2,
        InheritFromChild = -3,
    }

    [Serializable]
    public class StableDiffusionGraph : BaseGraph
    {
        public SDNodeSetting settings = new SDNodeSetting()
        {
            // Default graph values:
            width = 1024,
            height = 1024,
            depth = 1,
            widthScale = 1,
            heightScale = 1,
            depthScale = 1,
            dimension = OutputDimension.Texture2D,
            outputChannels = OutputChannel.RGBA,
            outputPrecision = OutputPrecision.Half,
        };

        public string mainAssetPath
        {
            get
            {
#if UNITY_EDITOR
                return AssetDatabase.GetAssetPath(this);
#else
                return null;
#endif
            }
        }

        // Important: note that order is not guaranteed 
        [SerializeField] List<Texture> _outputTextures = null;

        public List<Texture> outputTextures
        {
            get
            {
#if UNITY_EDITOR
                if (_outputTextures == null || _outputTextures.Count == 0)
                    _outputTextures = AssetDatabase.LoadAllAssetsAtPath(mainAssetPath).OfType<Texture>().ToList();
#endif
                _outputTextures.RemoveAll(t => t == null);

                return _outputTextures;
            }
        }

        Texture _mainOutputTexture;

        public Texture mainOutputTexture
        {
            get
            {
#if UNITY_EDITOR
                if (_mainOutputTexture == null)
                    _mainOutputTexture = AssetDatabase.LoadAssetAtPath<Texture>(mainAssetPath);
#endif
                return _mainOutputTexture;
            }
            set
            {
                outputTextures.Remove(_mainOutputTexture);
                outputTextures.Add(value);
                _mainOutputTexture = value;
            }
        }

        public NodeInheritanceMode defaultNodeInheritanceMode = NodeInheritanceMode.InheritFromParent;

        protected override void OnEnable()
        {
            SanitizeSettings();
            base.OnEnable();
        }

        void SanitizeSettings()
        {
            // Avoid undefined values in settings
            if (settings.outputChannels.Inherits())
                settings.outputChannels = OutputChannel.RGBA;
            if (settings.outputPrecision.Inherits())
                settings.outputPrecision = OutputPrecision.Half;
            if (settings.dimension.Inherits())
                settings.dimension = OutputDimension.Texture2D;
            if (settings.wrapMode.Inherits())
                settings.wrapMode = OutputWrapMode.Mirror;
            if (settings.filterMode.Inherits())
                settings.filterMode = OutputFilterMode.Trilinear;
            if (settings.sizeMode.Inherits())
                settings.sizeMode = OutputSizeMode.Absolute;
            if (settings.potSize == 0)
                settings.SetPOTSize(1024);
            if (settings.widthScale == 0)
                settings.widthScale = 1;
            if (settings.heightScale == 0)
                settings.heightScale = 1;
            if (settings.depthScale == 0)
                settings.depthScale = 1;

            settings.editFlags = EditFlags.TargetFormat;
        }
    }
}