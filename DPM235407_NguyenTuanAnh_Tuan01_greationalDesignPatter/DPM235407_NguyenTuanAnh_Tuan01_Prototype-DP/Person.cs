using System;

namespace DPM235407_NguyenTuanAnh_Tuan01_Prototype_DP
{
    public class Person
    {
        public int Age;
        public DateTime BirthDate;
        public string Name = string.Empty;
        public IdInfo? IdInfo;

        public Person ShallowCopy()
        {
            return (Person)this.MemberwiseClone();
        }

        public Person DeepCopy()
        {
            Person clone = (Person)this.MemberwiseClone();
            clone.IdInfo = new IdInfo(IdInfo != null ? IdInfo.IdNumber : 0);
#pragma warning disable CS0618
            clone.Name = String.Copy(Name);
#pragma warning restore CS0618
            return clone;
        }
    }
}
