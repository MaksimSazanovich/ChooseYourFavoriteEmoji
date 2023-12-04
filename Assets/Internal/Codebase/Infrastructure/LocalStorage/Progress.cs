using System;

namespace Internal.Codebase.LocalStorage
{
    [Serializable]
    public class Progress
    {
        public int index;

        public Progress(int index)
        {
            this.index = index;
        }
    }
}