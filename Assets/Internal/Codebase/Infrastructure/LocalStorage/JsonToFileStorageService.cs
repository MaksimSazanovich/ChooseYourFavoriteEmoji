// **************************************************************** //
//
//   Copyright (c) RimuruDev. All rights reserved.
//   Contact me: 
//          - Gmail:    rimuru.dev@gmail.com
//          - GitHub:   https://github.com/RimuruDev
//          - LinkedIn: https://www.linkedin.com/in/rimuru/
//          - GitHub Organizations: https://github.com/Rimuru-Dev
//
// **************************************************************** //

using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Internal.Codebase.LocalStorage;
using UnityEngine;

namespace Internal.Codebase.Infrastructure.LocalStorage
{
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public sealed class JsonToFileStorageService : IStorageService
    {
        public string GetDataPath => Application.persistentDataPath + "/Database";

        public void Save(string key, object data, Action<bool> onCallback = null)
        {
            var path = BuildPath(key);

            if (!Directory.Exists(GetDataPath))
                Directory.CreateDirectory(GetDataPath);

            if (!File.Exists(path))
                File.Create(path).Dispose();

            var json = JsonUtility.ToJson(data);

            using var fileStream = new StreamWriter(path);

            fileStream.Write(json);

            onCallback?.Invoke(true);
        }


        public void Load<TData>(string key, Action<TData> onCallback)
        {
            var path = BuildPath(key);

            if (!Directory.Exists(GetDataPath))
                Directory.CreateDirectory(GetDataPath);

            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                onCallback?.Invoke(default);
                return;
            }

            using var fileStream = new StreamReader(path);

            var json = fileStream.ReadToEnd();
            var data = JsonUtility.FromJson<TData>(json);

            onCallback?.Invoke(data);
        }

        private string BuildPath(string key) =>
            Path.Combine(GetDataPath, key);
    }
}