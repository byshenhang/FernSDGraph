using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using GraphProcessor;
using System.Linq;
using NodeGraphProcessor.Examples;
using Unity.VisualScripting;
using Debug = UnityEngine.Debug;

namespace FernNPRCore.SDNodeGraph
{
	[System.Serializable, NodeMenuItem("Stable Diffusion Graph/SD Preview")]
	public class SDPreviewNode : BaseNode
	{
		[Input(name = "Image"), ShowAsDrawer]
		public Texture inputImage;
		[Input(name = "Seed")]
		public long seed;
		[Output(name = "Image")]
		public Texture outImage;

		public override string name => "SD Preview";

		protected override void Enable()
		{
			base.Enable();
		}

		protected override void Process()
		{
			base.Process();
			GetPort(nameof(inputImage), null).PushData();
		}
	}
}