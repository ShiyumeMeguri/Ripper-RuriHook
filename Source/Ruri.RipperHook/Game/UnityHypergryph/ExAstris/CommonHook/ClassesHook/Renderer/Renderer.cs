﻿using AssetRipper.IO.Endian;
using AssetRipper.SourceGenerated.Classes.ClassID_120;
using AssetRipper.SourceGenerated.Classes.ClassID_137;
using AssetRipper.SourceGenerated.Classes.ClassID_199;
using AssetRipper.SourceGenerated.Classes.ClassID_212;
using AssetRipper.SourceGenerated.Classes.ClassID_227;
using AssetRipper.SourceGenerated.Classes.ClassID_23;
using AssetRipper.SourceGenerated.Classes.ClassID_25;
using AssetRipper.SourceGenerated.Classes.ClassID_331;
using AssetRipper.SourceGenerated.Classes.ClassID_483693784;
using AssetRipper.SourceGenerated.Classes.ClassID_96;
using AssetRipper.SourceGenerated.Subclasses.PPtr_Material;
using Mono.Cecil;
using Mono.Cecil.Cil;
using MonoMod.Cil;

namespace Ruri.RipperHook.ExAstrisCommon;

public partial class ExAstrisCommon_Hook
{
    [RetargetMethodFunc(typeof(TrailRenderer_2020_2_0_a13))]
    [RetargetMethodFunc(typeof(TilemapRenderer_2020_2_0_a13))]
    [RetargetMethodFunc(typeof(SpriteMask_2020_2_0_a13))]
    [RetargetMethodFunc(typeof(ParticleSystemRenderer_2020_2_0_a13))]
    [RetargetMethodFunc(typeof(MeshRenderer_2020_2_0_a13))]
    [RetargetMethodFunc(typeof(BillboardRenderer_2020_2_0_a13))]
    [RetargetMethodFunc(typeof(SpriteRenderer_2020_2_0_a13))]
    [RetargetMethodFunc(typeof(SkinnedMeshRenderer_2020_2_0_a13))]
    [RetargetMethodFunc(typeof(LineRenderer_2020_2_0_a13))]
    private static bool RendererReadRelease(ILContext il)
    {
        var ilCursor = new ILCursor(il);
        var startIndex = ilCursor.Index;
        if (ilCursor.TryGotoNext(MoveType.After, instr => instr.OpCode == OpCodes.Stfld && ((FieldReference)instr.Operand).Name == "m_SortingOrder"))
        {
            var targetLabel = ilCursor.MarkLabel();
            ilCursor.Goto(startIndex);
            ilCursor.Emit(OpCodes.Br, targetLabel);
            ilCursor.GotoLabel(targetLabel);
            var destMethod = typeof(ExAstrisCommon_Hook).GetMethod(nameof(Renderer_2020_1_0_a19_ReadRelease));
            ilCursor.Emit(OpCodes.Ldarg_0);
            ilCursor.Emit(OpCodes.Ldarg_1);
            ilCursor.Emit(OpCodes.Call, destMethod);
            return true;
        }

        return false;
    }

    public void Renderer_2020_1_0_a19_ReadRelease(ref EndianSpanReader reader)
    {
        var _this = (object)this as Renderer_2020_1_0_a19;
        var type = typeof(Renderer_2020_1_0_a19);

        _this.GameObject_C25.ReadRelease(ref reader);
        _this.Enabled_C25 = reader.ReadBoolean();
        _this.CastShadows_C25_Byte = reader.ReadByte();
        _this.ReceiveShadows_C25_Byte = reader.ReadByte();
        _this.DynamicOccludee_C25 = reader.ReadByte();
        var m_UsedWithDynamicReflection = reader.ReadByte();
        var m_UsedWithDistortion = reader.ReadByte();
        var m_UsedWithSmokeDepth = reader.ReadByte();
        var m_UsedShadingRateLowLevel = reader.ReadByte();
        _this.MotionVectors_C25 = reader.ReadByte();
        _this.LightProbeUsage_C25 = reader.ReadByte();
        _this.ReflectionProbeUsage_C25_Byte = reader.ReadByte();
        _this.RayTracingMode_C25 = reader.ReadByte();
        _this.RayTraceProcedural_C25= reader.ReadRelease_ByteAlign();
        var m_RenderLayer = reader.ReadUInt32();
        _this.RenderingLayerMask_C25 = reader.ReadUInt32();
        _this.RendererPriority_C25 = reader.ReadInt32();
        _this.LightmapIndex_C25_UInt16 = reader.ReadUInt16();
        _this.LightmapIndexDynamic_C25 = reader.ReadUInt16();
        _this.LightmapTilingOffset_C25.ReadRelease(ref reader);
        _this.LightmapTilingOffsetDynamic_C25.ReadRelease(ref reader);
        SetAssetListField<PPtr_Material_5>(type, "m_Materials", ref reader);
        _this.StaticBatchInfo_C25.ReadRelease(ref reader);
        _this.StaticBatchRoot_C25.ReadRelease(ref reader);
        _this.ProbeAnchor_C25.ReadRelease(ref reader);
        _this.LightProbeVolumeOverride_C25.ReadRelease_AssetAlign(ref reader);
        _this.SortingLayerID_C25_Int32 = reader.ReadInt32();
        _this.SortingLayer_C25 = reader.ReadInt16();
        _this.SortingOrder_C25 = reader.ReadRelease_Int16Align();
    }
}