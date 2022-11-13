using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatSources
{
    public class FSJumps : FloatSource
    {
        public Attributes Attribute { get; set; }

        public FSJumps()
        {
        }

        internal FSJumps(BulkSerializeReader reader) : base(reader)
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
			totalAirJumpsLeft = 0,
			totalAirDashesLeft = 1,
			jumpGround = 2,
			jumpAir = 3,
			jumpEdge = 4,
			jumpWall = 5,
			jumpMultiplier = 6,
			delayedEnable = 7,
			delayedSpeedInitial = 8,
			delayedSpeedEnd = 9,
			delayedFrames = 10,
			delayedEase = 11,
			airDashSpeedInitial = 12,
			airDashSpeedEnd = 13,
			airDashSpeedMultUp = 14,
			airDashSpeedMultDown = 15,
			airDashFrames = 16,
			airDashFramesWarmup = 17,
			airDashEase = 18,
			knockbackOnlyFlinch = 27,
			knockbackApproximateDestinationX = 28,
			knockbackApproximateDestinationY = 29,
			knockbackExpectedDistanceX = 30,
			knockbackExpectedDistanceY = 31,
			knockbackExpectedDistanceTotal = 32,
			knockbackTraveledX = 33,
			knockbackTraveledY = 34,
			knockbackTraveledTotal = 35,
			knockbackTraveledAbsoluteX = 36,
			knockbackTraveledAbsoluteY = 37,
			knockbackTraveledAbsoluteTotal = 38,
			knockbackLaunchVelocityX = 39,
			knockbackLaunchVelocityY = 40,
			knockbackLaunchVelocityTotal = 41,
			knockbackLaunchVelocityTrueX = 42,
			knockbackLaunchVelocityTrueY = 43,
			knockbackLaunchVelocityTrueTotal = 44,
			knockbackLaunchLastFrameX = 45,
			knockbackLaunchLastFrameY = 46,
			knockbackLaunchLastFrameTotal = 47,
			knockbackAngle = 48,
			knockbackFrames = 49,
			knockbackDidDI = 50,
			knockbackDiType = 51,
			knockbackDiIn = 52,
			knockbackDiOut = 53,
			knockbackActFallSpeed = 54,
			knockbackActGravity = 55,
			knockbackRate = 56,
			knockbackTargetRate = 57,
			knockbackChangeRate = 58
		}
    }
}