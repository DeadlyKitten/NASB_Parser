using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatSources
{
    public class FSGrabs : FloatSource
    {
        public Attributes Attribute { get; set; }

        public FSGrabs()
        {
        }

        internal FSGrabs(BulkSerializeReader reader) : base(reader)
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
            HardSyncPos,
            AllowGrabEscape,
            AllowedToEscape,
            GrabbedAgentWeight,
            GrabbedByPlayerIndex,
            GrabbedByAttackTeam,
			GroundGrabRadius,
			GroundGrabHitbox1X,
			GroundGrabHitbox1Y,
			GroundGrabHitbox2X,
			GroundGrabHitbox2Y,
			GroundGrabHit,
			GroundGrabTime,
			GroundThrowUpOffsetX,
			GroundThrowUpOffsetY,
			GroundThrowMidOffsetX,
			GroundThrowMidOffsetY,
			GroundThrowDownOffsetX,
			GroundThrowDownOffsetY,
			GroundThrowUpRelease,
			GroundThrowUpTime,
			AirGrabRadius,
			AirGrabHitbox1X,
			AirGrabHitbox1Y,
			AirGrabHitbox2X,
			AirGrabHitbox2Y,
			AirGrabHit,
			AirGrabTime,
			AirThrowUpOffsetX,
			AirThrowUpOffsetY,
			AirThrowMidOffsetX,
			AirThrowMidOffsetY,
			AirThrowDownOffsetX,
			AirThrowDownOffsetY,
			AirThrowUpRelease,
			AirThrowUpTime,
			GroundGrabHitAnim,
			GroundThrowUpReleaseAnim,
			GroundThrowMidRelease,
			GroundThrowMidReleaseAnim,
			GroundThrowMidTime,
			GroundThrowDownRelease,
			GroundThrowDownReleaseAnim,
			GroundThrowDownTime,
			AirGrabHitAnim,
			AirThrowUpReleaseAnim,
			AirThrowMidRelease,
			AirThrowMidReleaseAnim,
			AirThrowMidTime,
			AirThrowDownRelease,
			AirThrowDownReleaseAnim,
			AirThrowDownTime
		}
	}
}