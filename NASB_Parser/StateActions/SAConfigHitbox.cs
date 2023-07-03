using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
	[Serializable]
    public class SAConfigHitbox : StateAction
    {
        public int Hitbox { get; set; }
        public bool ForceZ0 { get; set; }
        public FloatSource Radius { get; set; }
        public Vector3 LocalOffset { get; set; }
        public Vector3 WorldOffset { get; set; }
        public string Prop { get; set; }
        public string Bone { get; set; }
        public string FxId { get; set; }
        public string SfxId { get; set; }
        public bool Inactive { get; set; }
        public bool SecondTrack { get; set; }
        public string Bone2 { get; set; }
        public Vector3 LocalOffset2 { get; set; }
        public Vector3 WorldOffset2 { get; set; }

        public SAConfigHitbox()
        {
        }

        internal SAConfigHitbox(BulkSerializeReader reader) : base(reader)
        {
            Hitbox = reader.ReadInt();
            Inactive = reader.ReadBool();
            if (Version > 1)
            {
                Radius = FloatSource.Read(reader);
                LocalOffset = reader.ReadVector3(true);
                WorldOffset = reader.ReadVector3(true);
            }
            else
            {
                Radius = new FSValue(reader.ReadFloat());
                LocalOffset = reader.ReadVector3();
                WorldOffset = reader.ReadVector3();
            }
            Prop = reader.ReadString();
            Bone = reader.ReadString();
            FxId = reader.ReadString();
            SfxId = reader.ReadString();
            if (Version != 0)
            {
                SecondTrack = reader.ReadBool();
                if (SecondTrack)
                {
                    Bone2 = reader.ReadString();
                    LocalOffset2 = reader.ReadVector3(true);
                    WorldOffset2 = reader.ReadVector3(true);
                }
            }
        }

        public override void Write(BulkSerializeWriter writer)
        {
            writer.Write(TID);
            writer.Write(2);
            writer.Write(Hitbox);
            writer.Write(Inactive);
            writer.Write(Radius);
            writer.Write(LocalOffset);
            writer.Write(WorldOffset);
            writer.Write(Prop);
            writer.Write(Bone);
            writer.Write(FxId);
            writer.Write(SfxId);
            writer.Write(SecondTrack);
            if (SecondTrack)
            {
                writer.Write(Bone2);
                writer.Write(LocalOffset2);
                writer.Write(WorldOffset2);
            }
        }
    }
}
