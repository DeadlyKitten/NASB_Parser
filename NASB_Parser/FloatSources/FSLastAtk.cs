using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatSources
{
    public class FSLastAtk : FloatSource
    {
		public Attributes Attribute { get; set; }

		public FSLastAtk()
		{
		}

		internal FSLastAtk(BulkSerializeReader reader) : base(reader)
		{
			Attribute = (Attributes)reader.ReadInt();
		}

		public override void Write(BulkSerializeWriter writer)
		{
			base.Write(writer);
			writer.Write(Attribute);
		}

		public enum Attributes
		{
			Type,
			DamageBase,
			DamageMult,
			KnockbackMult,
			DamageTotal,
			Angle,
			Direction,
			DiType,
			DiIn,
			DiOut,
			Reversible,
			KnockbackType,
			KnockbackBase,
			KnockbackGain,
			ExtraKbAboveKb,
			ExtraKbMult,
			StunCalc,
			StunBase,
			StunGain,
			HitOpponent,
			InteractDirection,
			Blockstun,
			Blockpush,
			Blocklag,
			Hitlag,
			HitlagSelf,
			Launcher,
			LaunchAboveKb,
			LaunchArmorLevel,
			ForceJabReset,
			Grablevel,
			Grabtype,
			Killshot,
			Directionalfx,
			Unblockable,
			Pierceinvincible,
			NoBounce
		}
	}
}
