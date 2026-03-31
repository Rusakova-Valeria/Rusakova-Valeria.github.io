using System;
using System.Collections.Generic;
using System.IO;

namespace тема_7
{
    [Serializable]
    public class StackMemory
    {
        private readonly int _stackDepth;
        private readonly List<byte[]> _list = new List<byte[]>();

        public int Count => _list.Count;

        public StackMemory(int depth = 20)
        {
            _stackDepth = Math.Max(1, depth);
        }

        public void Push(MemoryStream stream)
        {
            if (_list.Count >= _stackDepth)
                _list.RemoveAt(0);
            _list.Add(stream.ToArray());
        }

        public bool Pop(MemoryStream stream)
        {
            if (_list.Count <= 0) return false;
            var buff = _list[_list.Count - 1];
            _list.RemoveAt(_list.Count - 1);
            stream.SetLength(0);
            stream.Write(buff, 0, buff.Length);
            stream.Position = 0;
            return true;
        }

        public void Clear() => _list.Clear();
    }
}
