using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class DataLoader
{
    private static string fileName = "save.txt";

    public static void Save(BinaryWriter writer, LevelData data)
    {
        writer.Write((int)data.State);
    }

    public static LevelState Read(BinaryReader reader)
    {
        return (LevelState)reader.ReadInt32();
    }
}
