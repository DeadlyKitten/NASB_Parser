using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatSources
{
	[Serializable]
    public class FSOnHit : FloatSource
    {
        public OnHitParam Param { get; set; }

        public FSOnHit()
        {
        }

        internal FSOnHit(BulkSerializeReader reader) : base(reader)
        {
            Param = (OnHitParam)reader.ReadInt();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Param);
        }

        public enum OnHitParam
        {
            Hitpos_x,
            Hitpos_y,
            Hitpos_z,
            Hitwasinvincible,
            Hitwasblock,
            Hurtdamage,
            Hitwellblocked,
            Hitperfectblocked,
            Hurtperfectblocked,
            Hitdamage,
            Hurtattacktype,
            Hurtwellblocked,
            Hurtknockback,
            HitWasClean,
        }
    }
}
