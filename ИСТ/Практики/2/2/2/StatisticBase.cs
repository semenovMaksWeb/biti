
namespace _2
{
    internal class StatisticBase
    {
        public StatisticBase()
        {
            countTrue = 0;
            countFalse = 0;
        }

        public int countTrue { get; set; }
        public int countFalse { get; set; }
        public float relationships { get; set; }

        public void addcountTrue()
        {
            countTrue++;
        }

        public void addcountFalse()
        {
            countFalse++;
        }
    }
}
