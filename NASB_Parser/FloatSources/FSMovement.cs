﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatSources
{
    public class FSMovement : FloatSource
    {
        public Attributes Attribute { get; set; }

        public FSMovement()
        {
        }

        internal FSMovement(BulkSerializeReader reader) : base(reader)
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
            Vel_X = 0,
            Vel_X_raw = 1,
            Vel_Y = 2,
            Direction = 3,
            IncreaseMoveDT = 4,
            IncreaseMoveDTFalloff = 5,
            AllowCtrl = 6,
            RootPosReset = 7,
            ForceNextFloorCheck = 8,
            CheckFloorFromMid = 9,
            FallSpeed = 10,
            Gravity = 11,
            FloorFriction = 12,
            FloorAcc = 13,
            FloorBrake = 14,
            FloorSpeed = 15,
            AirAcc = 16,
            AirBrake = 17,
            AirSpeed = 18,
            AirDecay = 19,
            RootMotionMult_X = 20,
            RootMotionMult_Y = 21,
            ResizeCollision = 22,
            MinColH = 23,
            MinColW = 24,
            ExtendBottom = 25,
            GetParented = 26,
            LeaveEdges = 27,
            FallThrough = 28,
            IgnoreMovingStage = 29,
            Bounce = 30,
            Stop = 31,
            LeaveParent = 32,
            InheritParentVel = 33,
            FloorTilt = 34,
            SolidGround = 35,
            Grounded = 36,
            CrowdPushing = 37,
            CrowdPushRadius = 38,
            GrabEdge = 39,
            GrabEdgeExtendFwd = 40,
            GrabEdgeExtendBack = 41,
            GrabEdgeExtendUp = 42,
            GrabEdgeExtendDown = 43,
            FallSpeedMultiplier = 44,
            XSpeedMultiplier = 45,
            PassThrough = 46,
            LeaveEdgeRestrict = 47,
            CrowdPushWeight = 48,
            ParentOrderAdded = 49,
            Last_move_X_raw = 50,
            Last_move_Y = 51,
            CrowdPushMaxDistPerFrame = 52,
            CheckFloorThickness = 53,
            SimpleFreeMovement = 54,
            SimpleRadius = 55,
            DisableMovement = 56,
            BottomCollisionWorldPos = 57,
            ExtendFloorCheckToMid = 58,
            DisableCollision = 59,
            ClosestParentEdge = 60,
            FloorDec = 61,
            AirDec = 62,
            AirFriction = 63,
            FloorDecay = 64,
            Antigravity = 65,
            CrowdPushingFromLedge = 66,
            DisableSink = 67,
            clampInitial = 68,
            crowdPushMaxDistOverride = 69,
            clampMovement = 70,
            clampRemain = 71,
            GrabRadius = 72,
            GrabX1 = 73,
            GrabX2 = 74,
            GrabY1 = 75,
            GrabY2 = 76,
            ThrowUpX = 77,
            ThrowUpY = 78,
            ThrowMidX = 79,
            ThrowMidY = 80,
            ThrowDownX = 81,
            ThrowDownY = 82,
            GravityMultiplier = 83,
        }
    }
}