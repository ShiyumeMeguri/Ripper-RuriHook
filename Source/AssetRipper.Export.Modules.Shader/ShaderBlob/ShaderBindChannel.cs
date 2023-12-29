using AssetRipper.SourceGenerated.Extensions.Enums.Shader;

namespace AssetRipper.Export.Modules.Shaders.ShaderBlob
{
	public sealed class ShaderBindChannel
	{
		public ShaderBindChannel() { }

		public ShaderBindChannel(uint source, VertexComponent target)
		{
			Source = source;
			Target = target;
		}

		/// <summary>
		/// ShaderChannel enum
		/// </summary>
		public uint Source { get; set; }
		public VertexComponent Target { get; set; }
	}
}
