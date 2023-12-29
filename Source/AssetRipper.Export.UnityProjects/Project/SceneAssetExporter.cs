﻿using AssetRipper.Assets;
using AssetRipper.Assets.Collections;
using AssetRipper.Assets.Export;
using AssetRipper.IO.Files;
using AssetRipper.SourceGenerated.Classes.ClassID_1032;

namespace AssetRipper.Export.UnityProjects.Project
{
	public sealed class SceneAssetExporter : IAssetExporter
	{
		public bool TryCreateCollection(IUnityObjectBase asset, TemporaryAssetCollection temporaryFile, [NotNullWhen(true)] out IExportCollection? exportCollection)
		{
			if (asset is ISceneAsset sceneAsset)
			{
				exportCollection = new SceneAssetExportCollection(sceneAsset);
				return true;
			}
			else
			{
				exportCollection = null;
				return false;
			}
		}

		public AssetType ToExportType(IUnityObjectBase asset)
		{
			return AssetType.Meta;
		}

		public bool ToUnknownExportType(Type type, out AssetType assetType)
		{
			assetType = AssetType.Meta;
			return true;
		}
	}
}
