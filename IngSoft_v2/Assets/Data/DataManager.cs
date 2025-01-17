﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace DataSystem
{
    public static class DataManager
    {

        public static T NewData<T>(string name = "")
        {
            string path = Application.persistentDataPath + "/" + name + "Data.dat";
            T newData;

            if (File.Exists(path))
            {
                Debug.LogWarning("[A file with this path already exists]: " + path);
                return LoadData<T>(name);
            }
            else
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Create);
                newData = Activator.CreateInstance<T>();
                formatter.Serialize(stream, newData);
                stream.Close();
                return newData;
            }
        }
        
        public static T SaveData<T>(T data,string name = "")
        {
            string path = Application.persistentDataPath + "/" + name + "Data.dat";

            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Create);
                formatter.Serialize(stream, data);
                stream.Close();
                return data;
            }
            else
            {
                Debug.LogWarning("[there is no saved information]: " + path);
                return NewData<T>(name);
            }
        }
        
        public static T LoadData<T>(string name = "")
        {
            T instance;

            string path = Application.persistentDataPath + "/"+name+"Data.dat";
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);
                instance = (T)formatter.Deserialize(stream);
                if (instance == null)
                {
                    instance = Activator.CreateInstance<T>();
                    Debug.LogWarning("[Corrupted file]: " + path);
                    return default(T);
                }
                stream.Close();
                return instance;
            }
            else
            {
                Debug.LogWarning("[The file does not exists]: " + path);
                return default(T);
            }
        }
    }
}
