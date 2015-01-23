using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Microsoft.Xna.Framework.Storage;
using System.IO;

//using System.Runtime.Serialization.Formatters.Binary;

namespace DoozyEngine
{
    public static class FileManager
    {
        //public static StorageDevice Device;
        //public static string OpenContainer;


        //public static bool IfFileExist(string filename)
        //{
        //    StorageContainer container;
        //    IAsyncResult result = FileManager.Device.BeginOpenContainer(FileManager.OpenContainer, null, null);

        //    result.AsyncWaitHandle.WaitOne();

        //    container = FileManager.Device.EndOpenContainer(result);

        //    result.AsyncWaitHandle.Close();

        //    if (!container.FileExists(filename))
        //        return false;

        //    return true;
        //}


        //public static void Serialize(string filename, object data, bool xml)
        //{
        //    StorageContainer container;

        //    IAsyncResult result = FileManager.Device.BeginOpenContainer(FileManager.OpenContainer, null, null);

        //    result.AsyncWaitHandle.WaitOne();

        //    container = FileManager.Device.EndOpenContainer(result);

        //    result.AsyncWaitHandle.Close();

        //    if (container.FileExists(filename))
        //        container.DeleteFile(filename);

        //    Stream stream = container.CreateFile(filename);

        //    if (xml)
        //    {
        //        XmlSerializer serializer = new XmlSerializer(data.GetType());
        //        serializer.Serialize(stream, data);
        //    }
        //    else
        //    {
        //        BinaryFormatter bFormatter = new BinaryFormatter();
        //        bFormatter.Serialize(stream, data);
        //    }


        //    stream.Close();
        //    container.Dispose();
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="filename"></param>
        ///// <param name="xml"></param>
        ///// <returns></returns>
        //public static T Deserialize<T>(string filename, bool xml)
        //{
        //    StorageContainer container;

        //    IAsyncResult result = FileManager.Device.BeginOpenContainer(FileManager.OpenContainer, null, null);

        //    result.AsyncWaitHandle.WaitOne();

        //    container = FileManager.Device.EndOpenContainer(result);

        //    result.AsyncWaitHandle.Close();

        //    T data;
        //    if (!container.FileExists(filename))
        //    {
        //        container.Dispose();
        //        throw new Exception();
        //    }


        //    Stream stream = container.OpenFile(filename, FileMode.Open);

        //    if (xml)
        //    {
        //        XmlSerializer serializer = new XmlSerializer(typeof(T));
        //        data = (T)serializer.Deserialize(stream);
        //    }
        //    else
        //    {
        //        BinaryFormatter bFormatter = new BinaryFormatter();
        //        data = (T)bFormatter.Deserialize(stream);
        //    }


        //    stream.Close();
        //    container.Dispose();
        //    return data;

        //}

    }
}
