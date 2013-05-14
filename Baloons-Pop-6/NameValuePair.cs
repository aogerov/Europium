using System;

namespace BalloonBoobsGame
{
    public class NameValuePair : IComparable<NameValuePair>
    {
        public NameValuePair(string name, int value)
        {
            this.Name = name;
            this.Value = value;
        }

        public string Name
        {
            get
            {
                return this.Name;
            }
            private set
            {
                //implement exeptions!!!
                this.Name = value;
            }
        }

        public int Value
        {
            get
            {
                return this.Value;
            }
            private set
            {
                //implement exeptions!!!
                this.Value = value;
            }
        }

        public int CompareTo(NameValuePair other)
        {
            return Value.CompareTo(other.Value);
        }
    }
}