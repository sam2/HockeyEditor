﻿using System;
using System.Linq;


namespace HockeyEditor
{
    public static class HQMEditor
    {
        private static bool IsServer = false;

        /// <summary>
        /// Must be called before any other functions in this class.
        /// </summary>
        /// <param name="isServer">If you are attaching to dedicatedserver.exe set this to true</param>
        public static void Init(bool isServer = false)
        {
            IsServer = isServer;
            MemoryWriter.Init(isServer);
        }

        public static HQMVector PuckPosition
        {
            get { return MemoryWriter.ReadHQMVector(HQMAddresses.PUCK_POS); }
            set { MemoryWriter.WriteHQMVector(value, HQMAddresses.PUCK_POS); }
        }

        public static HQMVector PuckVelocity
        {
            get { return MemoryWriter.ReadHQMVector(HQMAddresses.PUCK_VELOCITY); }
            set { MemoryWriter.WriteHQMVector(value, HQMAddresses.PUCK_VELOCITY); }
        }

        public static HQMVector PuckRotationalVelocity
        {
            get { return MemoryWriter.ReadHQMVector(HQMAddresses.PUCK_ROT_VELOCITY); }
            set { MemoryWriter.WriteHQMVector(value, HQMAddresses.PUCK_ROT_VELOCITY); }
        }

        public static HQMVector PlayerPosition
        {
            get { return MemoryWriter.ReadHQMVector(HQMAddresses.PLAYER_POS); }
            //set { if (value.Length == 3) WriteVector3(value, HQMClientAddresses.PLAYER_POS); }
        }

        public static HQMVector PlayerStickPosition
        {
            get { return MemoryWriter.ReadHQMVector(HQMAddresses.PLAYER_STICK_POS); }
            //set { if (value.Length == 3) MemoryWriter.WriteVector3(value, HQMClientAddresses.PLAYER_STICK_POS); }
        }

       

        //should probably read these in from file.
        public static class HQMAddresses
        {
            public static int PUCK_POS          { get { if (!IsServer) return 0x07D1C290; else return 0x00000000; } }
            public static int PUCK_VELOCITY     { get { if (!IsServer) return 0x07D1C2CC; else return 0x00000000; } }
            public static int PUCK_ROT_VELOCITY { get { if (!IsServer) return 0x07D1C2E4; else return 0x00000000; } }
            public static int PLAYER_POS        { get { if (!IsServer) return 0x04C25258; else return 0x00000000; } }
            public static int PLAYER_STICK_POS  { get { if (!IsServer) return 0X07D1CEF8; else return 0x00000000; } }
        }                                                   
    }
    
    public class HQMVector
    {
        public float X;
        public float Y;
        public float Z;

        public HQMVector(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}