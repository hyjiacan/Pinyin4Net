﻿using System.Collections.Generic;

namespace hyjiacan.py4n
{
    /// <summary>
    /// 调用 GetPinyinArray 时的返回项数据结构
    /// </summary>
    public class PinyinItem : List<string>
    {
        /// <summary>
        /// 原始字符
        /// </summary>
        public char RawChar { get; set; }
        /// <summary>
        /// 是否是汉字
        /// </summary>
        public bool IsHanzi { get; private set; }

        public PinyinItem() { }
        public PinyinItem(char character)
        {
            RawChar = character;
            IsHanzi = PinyinUtil.IsHanzi(character);
        }

        public override string ToString()
        {
            if(IsHanzi) {
                return $"[{string.Join(",", this)}]";
            }

            return RawChar.ToString();
        }

        public override int GetHashCode()
        {
            return RawChar.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if(obj == null) {
                return false;
            }

            var other = obj as PinyinItem;
            if(other == null) {
                return false;
            }

            if(RawChar != other.RawChar) {
                return false;
            }

            if(Count != other.Count) {
                return false;
            }

            for (int i = 0; i < Count; i++)
            {
                if(this[i] != other[i]) {
                    return false;
                }
            }

            return true;
        }
    }
}
