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

namespace Internal.Codebase.LocalStorage
{
    public interface IStorageService
    {
        public string GetDataPath { get; }
        public void Save(string key, object data, Action<bool> onCallback = null);
        public void Load<TData>(string key, Action<TData> onCallback);
    }
}