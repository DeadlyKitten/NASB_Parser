using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class HurtBone : ISerializable
    {
        public HurtType Type { get; set; }
        public FloatSource Armor { get; set; }
        public FloatSource KnockbackArmor { get; set; }
        public bool ForceZ0 { get; set; }
        public bool IgnoreGrab { get; set; }
        public string BoneA { get; set; }
        public string BoneB { get; set; }
        public FloatSource Radius { get; set; }
        public Vector3 LocalOffsetA { get; set; }
        public Vector3 WorldOffsetA { get; set; }
        public Vector3 LocalOffsetB { get; set; }
        public Vector3 WorldOffsetB { get; set; }

        public HurtBone()
        {
        }

        internal HurtBone(BulkSerializeReader reader)
        {
            int version = reader.ReadInt();
            Type = (HurtType)reader.ReadInt();
            if (version > 1)
            {
                Armor = FloatSource.Read(reader);
                KnockbackArmor = FloatSource.Read(reader);
            }
            else
            {
                Armor = new FSValue(reader.ReadFloat());
                KnockbackArmor = new FSValue(reader.ReadFloat());
            }
            ForceZ0 = reader.ReadBool();
            BoneA = reader.ReadString();
            BoneB = reader.ReadString();
            if (version > 1)
            {
                Radius = FloatSource.Read(reader);
                LocalOffsetA = reader.ReadVector3(true);
                WorldOffsetA = reader.ReadVector3(true);
                LocalOffsetB = reader.ReadVector3(true);
                WorldOffsetB = reader.ReadVector3(true);
            }
            else
            {
                Radius = new FSValue(reader.ReadFloat());
                LocalOffsetA = reader.ReadVector3();
                WorldOffsetA = reader.ReadVector3();
                LocalOffsetB = reader.ReadVector3();
                WorldOffsetB = reader.ReadVector3();
            }
        }

        public void Write(BulkSerializeWriter writer)
        {
            writer.Write(2);
            writer.Write(Type);
            writer.Write(Armor);
            writer.Write(KnockbackArmor);
            writer.Write(IgnoreGrab);
            writer.Write(BoneA);
            writer.Write(BoneB);
            writer.Write(Radius);
            writer.Write(LocalOffsetA);
            writer.Write(WorldOffsetA);
            writer.Write(LocalOffsetB);
            writer.Write(WorldOffsetB);
        }
    }
}